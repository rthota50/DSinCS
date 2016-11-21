using System;
using System.Collections.Generic;
using System.Linq;
using DS.Utils;

namespace Graphs
{
    public class DGraph<T> : Graph<T>
    {
        protected override Map<T, int> Map { get; set; }
        protected override Dictionary<int, List<Edge>> Adj { get; set; }
        protected bool[] visited;
        protected Queue<int> postOrder;
        private int[] prev;
        public DGraph(uint v) : base(v)
        {
            this.Map = new Map<T, int>();
            this.Adj = new Dictionary<int, List<Edge>>();
        }

        public override void AddEdge(T u, T w, int weight)
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

        public bool HasCycle(T source)
        {
            visited = new bool[this.V];
            prev = new int[this.V];
            prev.PopulateWith(-1);
            var v = Map.Forward[source];
            return DfsCheckCycle(v);
        }

        private bool DfsCheckCycle(int v)
        {
            var cyclic = false;
            visited[v] = true;
            foreach (var e in this.Adj[v].Where(e => prev[v] != -1? prev[v] != e.Other(v) : true))
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
    }

}
