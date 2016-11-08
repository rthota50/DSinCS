using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DSinCS.Graphs
{

    public abstract class Graph<T>
    {
        protected abstract Dictionary<T, int> Map { get; set; }
        protected abstract Dictionary<int, List<Edge>> Adj { get; set; }
        private Dictionary<int, int> prev;
        private bool[] visited;
        private int[] distTo;
        public int V ;
        public abstract void AddEdge(T u, T w, int weight);
        public abstract void AddEdge(T u, T w);

        public Graph(int v)
        {
            this.V  = v;
        }

        public IEnumerable<T> bfsPathTo(T source, T end)
        {
            var q = new Queue<int>();
            var v = Map[source];
            var p = Map[end];
            visited = new bool[this.V];
            q.Enqueue(v);
            visited[v] = true;
            var list = new List<T>();
            prev = new Dictionary<int, int>();
            distTo = new int[this.V];
            distTo[v] = 0;
            while (q.Count > 0)
            {
                var u = q.Dequeue();
                foreach (var e in Adj[u])
                {
                    var w = e.Other(u);
                    if (!visited[w])
                    {
                        prev[w] = u;
                        visited[w] = true;
                        q.Enqueue(w);
                        distTo[w] = distTo[u] + e.Weight;
                    }
                }
            }
            if (!visited[p]) { return list; }
            var temp = Map.Select(kv => new { K = kv.Key, V = kv.Value }).ToDictionary(o => o.V, o => o.K);
            for (int i = p; i != v; i = prev[i])
            {
                list.Add(temp[i]);
            }
            list.Add(source);
            list.Reverse();
            return list;
        }

        public IEnumerable<T> dfsPathTo(T source, T end)
        {
            var q = new Queue<int>();
            var v = Map[source];
            var p = Map[end];
            visited = new bool[this.V];
            visited[v] = true;
            var list = new List<T>();
            prev = new Dictionary<int, int>();
            distTo = new int[this.V];
            distTo[v] = 0;
            dfs(v);
            if (!visited[p]) { return list; }
            var temp = Map.Select(kv => new { K = kv.Key, V = kv.Value }).ToDictionary(o => o.V, o => o.K);
            for (int i = p; i != v; i = prev[i])
            {
                list.Add(temp[i]);
            }
            list.Add(source);
            list.Reverse();
            return list;
        }

        private void dfs(int v)
        {
            visited[v] = true;
            foreach (var e in Adj[v].Where(e => !visited[e.Other(v)]))
            {
                int w = e.Other(v);
                prev[w] = v;
                dfs(w);
            }
        }

        public IEnumerable<T> dfsPathToNon(T source, T end)
        {
            var s = new Stack<int>();
            visited = new bool[this.V];
            prev = new Dictionary<int, int>();
            s.Push(Map[source]);
            visited[Map[source]] = true;
            var adjEnums = this.Adj.ToDictionary(kv => kv.Key, kv => kv.Value.GetEnumerator());

            while (s.Count > 0)
            {
                var v = s.Peek();
                var iter = adjEnums[v];
                if (iter.MoveNext())
                {
                    var e = iter.Current;
                    var w = e.Other(v);
                    if (!visited[w])
                    {
                        prev[w] = v;
                        visited[w] = true;
                        s.Push(w);
                    }
                }
                else { s.Pop(); }
                adjEnums[v] = iter;
            }
            var list = new List<T>();
            var temp = Map.Select(kv => new { K = kv.Key, V = kv.Value }).ToDictionary(kv => kv.V, kv => kv.K);
            for (var i = Map[end]; i != Map[source]; i = prev[i])
            {
                list.Add(temp[i]);
            }
            list.Add(source);
            return list;
        }

        public bool HasCycle(T source)
        {
            visited = new bool[this.V];
            prev = new Dictionary<int, int>();
            var v = Map[source];
            return DfsCheckCycle(v);
        }

        private bool DfsCheckCycle(int v)
        {
            var cyclic = false;
            visited[v] = true;
            foreach (var e in this.Adj[v].Where(e => prev.ContainsKey(v) ? prev[v] != e.Other(v) : true))
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

    public class UGraph<T> : Graph<T>
    {
        protected override Dictionary<T, int> Map { get; set; }
        protected override Dictionary<int, List<Edge>> Adj { get; set; }

        public UGraph(int v) : base(v)
        {
            this.Map = new Dictionary<T, int>();
            this.Adj = new Dictionary<int, List<Edge>>(v);            
        }
        public override void AddEdge(T u, T w, int weight)
        {
            if (!Map.ContainsKey(u))
            {
                Map[u] = Map.Count;
                Adj[Map[u]] = new List<Edge>();
            }
            if (!Map.ContainsKey(w))
            {
                Map[w] = Map.Count;
                Adj[Map[w]] = new List<Edge>();
            }
            var mu = Map[u];
            var mw = Map[w];
            this.Adj[mu].Add(new Edge(mu, mw, weight));
            this.Adj[mw].Add(new Edge(mw, mu, weight));
        }
        public override void AddEdge(T u, T w)
        {
            this.AddEdge(u, w, 1);
        }
        
        public static void Test1()
        {
            UGraph<int> g = null;
            using (var reader = File.OpenText("/Users/rajivthota/dev/cs/DSinCS/Graphs/graph1.txt"))
                while (!reader.EndOfStream)
                {
                    var V = int.Parse(reader.ReadLine().Trim());
                    g = new UGraph<int>(V);
                    while (!reader.EndOfStream)
                    {
                        var inp = reader.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
                        g.AddEdge(inp[0], inp[1]);
                    }
                }
            foreach (var e in g.bfsPathTo(0, 9))
            {
                Console.WriteLine($"{e} ");
            }
            foreach (var e in g.dfsPathTo(0, 4))
            {
                Console.WriteLine($"{e} ");
            }
            Console.WriteLine($"check cycle from a node 7 :{g.HasCycle(7)}");
            Console.WriteLine($"check cycle from a node 0 :{g.HasCycle(0)}");
            foreach (var e in g.dfsPathToNon(0, 4))
            {
                Console.WriteLine($"{e} ");
            }
        }
    }

    public class DGraph<T> : Graph<T>
    {
        protected override Dictionary<T, int> Map { get ; set; }
        protected override Dictionary<int, List<Edge>> Adj { get ; set; }

        public DGraph(int v): base(v)
        {
            this.Map = new Dictionary<T, int>();
            this.Adj = new Dictionary<int, List<Edge>>();
        }

        public override void AddEdge(T u, T w, int weight)
        {
            if (!Map.ContainsKey(u))
            {
                Map[u] = Map.Count;
                Adj[Map[u]] = new List<Edge>();
            }
            if (!Map.ContainsKey(w))
            {
                Map[w] = Map.Count;
                Adj[Map[w]] = new List<Edge>();
            }
            var mu = Map[u];
            var mw = Map[w];
            this.Adj[mu].Add(new Edge(mu, mw, weight));
        }
        public override void AddEdge(T u, T w)
        {
            this.AddEdge(u, w, 1);
        }
    }

    public struct Edge
    {
        private int U { get; set; }
        private int W { get; set; }
        public int Weight { get; private set; }
        public Edge(int u, int w, int weight)
        {
            this.U = u; this.W = w; this.Weight = weight;
        }
        public Edge(int u, int w) : this(u, w, 1) { }
        public int Other(int u) { return this.U == u ? this.W : this.U; }
    }
}