using System;
using System.Collections.Generic;
using System.Linq;
using DS.Utils;
using Sorting;

namespace Graphs
{
    public class DGraph<T> : Graph<T> where T : IComparable
    {
        protected override Map<T, int> Map { get; set; }
        protected override Dictionary<int, List<Edge>> Adj { get; set; }
        protected bool[] visited;
        protected Queue<int> postOrder;
        private int[] prev;
        private float[] distTo;
        private Edge[] edgeTo;

        #region Constructor
        public DGraph(uint v) : base(v)
        {
            this.Map = new Map<T, int>(v);
            this.Adj = new Dictionary<int, List<Edge>>();
        }
        #endregion

        #region API
        public override void AddEdge(T u, T w, float weight)
        {
            if (!Map.Forward.ContainsKey(u))
            {
                Map.Add(u, Map.Count);
                Adj[Map.Forward[u]] = new List<Edge>();
            }
            if (!Map.Forward.ContainsKey(w))
            {
                Map.Add(w, Map.Count);
                Adj[Map.Forward[w]] = new List<Edge>();
            }
            var mu = Map.Forward[u];
            var mw = Map.Forward[w];
            this.Adj[mu].Add(new Edge(mu, mw, weight));
        }
        public override void AddEdge(T u, T w)
        {
            this.AddEdge(u, w, 1);
        }

        public IEnumerable<T> TopologicalSort()
        {
            //Adj.ToConsole();
            //Map.ToConsole();
            postOrder = new Queue<int>();
            visited = new bool[this.V];
            for (int v = 0; v < this.V; v++)
            {
                if (!visited[v]) { DfsOrder(v); }
            }
            var temp = Map.Reverse;
            return postOrder.Select(i => temp[i]).Reverse();
        }


        public bool HasCycle(T source)
        {
            visited = new bool[this.V];
            prev = new int[this.V];
            prev.PopulateWith(-1);
            var v = Map.Forward[source];
            return DfsCheckCycle(v);
        }

        /// <summary>
        /// diakjstra algorithm
        /// </summary>
        /// <param name="source"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Dictionary<T, float> ShortestPathTree(T source)
        {
            distTo = DS.Utils.Array.CreateWithCapacity(this.V, float.MaxValue);
            edgeTo = DS.Utils.Array.CreateWithCapacity<Edge>(this.V);
            distTo[Map[source]] = 0;
            visited = DS.Utils.Array.CreateWithCapacity<bool>(this.V);
            var pq = new MinIndexPQ<float>(this.V);
            pq.InsertKey(Map[source], 0);
            while (!pq.IsEmpty())
            {
                var v = pq.DelMin();
                foreach (var e in Adj[v])
                {//relax edge
                    var w = e.Other(v);
                    if (distTo[w] > distTo[v] + e.Weight)
                    {
                        distTo[w] = distTo[v] + e.Weight;
                        edgeTo[w] = e;
                        if (pq.Contains(w)) { pq.ChangeKey(w, distTo[w]); }
                        else { pq.InsertKey(w, distTo[w]); }
                    }
                }
            }

            var distToRest = distTo.Select((d, i) => new { K = Map.Reverse[i], V = d })
                .ToDictionary(kv => kv.K, kv => kv.V);

            return distToRest;
        }

        public List<Edge> MST_Kruskal()
        {
            var totalEdges = Adj.Values.Sum(l => l.Count);
            var pq = new MinIndexPQ<Edge>((uint)totalEdges);
            var uf = new BasicDS.DisjointSet(this.V);
            int count = 0;
            var edgeTo = new int[this.V];
            var distTo = new float[V];
            var edges = new List<Edge>((int)V);
            for (int i = 0; i < Adj.Count; i++)
            {
                foreach (var e in Adj[i])
                {
                    pq.InsertKey(count++, e);
                } 
            }
            while(!pq.IsEmpty())
            {
                var e = pq.DelMinKey();
                var u = e.Either();
                var w = e.Other(u);
                if(uf.Connected((uint)u, (uint)w))
                { continue; }

                uf.Union((uint)u, (uint)w);
                edges.Add(e);
            }
            return edges.Select(e =>
            {
                var u = e.Either();
                var w = e.Other(u);
                var uActual = int.Parse(Map.Reverse[u].ToString());
                var wActual = int.Parse(Map.Reverse[w].ToString());
                return new Edge(uActual, wActual, e.Weight);
            }).ToList(); ;
        }
        #endregion

        #region Private
        private void DfsOrder(int v)
        {
            Console.WriteLine(v);
            visited[v] = true;
            foreach (var e in Adj[v])
            {
                var u = e.Other(v);
                if (!visited[u])
                {
                    DfsOrder(u);
                }
            }
            postOrder.Enqueue(v);
        }

        private bool DfsCheckCycle(int v)
        {
            var cyclic = false;
            visited[v] = true;
            foreach (var e in this.Adj[v].Where(e => prev[v] != -1 ? prev[v] != e.Other(v) : true))
            {
                var w = e.Other(v);
                if (visited[w]) { return true; }
                visited[w] = true;
                prev[w] = v;
                cyclic = DfsCheckCycle(w);
                if (cyclic) { break; }
            }
            return cyclic;
        } 
        #endregion
    }

}
