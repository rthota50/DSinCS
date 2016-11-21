using DS.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    public abstract class Graph<T>
    {
        protected abstract Map<T, int> Map { get; set; }
        protected abstract Dictionary<int, List<Edge>> Adj { get; set; }
        private Queue<int> preOrder;
        private Queue<int> postOrder;
        private int[] prev;
        private bool[] visited;
        private int[] distTo;
        private Edge[] edgeTo;
        public uint V { get; private set; }
        public abstract void AddEdge(T u, T w, int weight);
        public abstract void AddEdge(T u, T w);

        public Graph(uint v)
        {
            this.V = v;
        }

        public IEnumerable<T> BfsPathTo(T source, T end)
        {
            var q = new Queue<int>();
            var v = Map.Forward[source];
            var p = Map.Forward[end];
            visited = new bool[this.V];
            q.Enqueue(v);
            visited[v] = true;
            var list = new List<T>();
            prev = Array.CreateWithCapacity(this.V, -1);
            
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
            var temp = Map.Reverse;
            for (int i = p; i != v; i = prev[i])
            {
                list.Add(temp[i]);
            }
            list.Add(source);
            list.Reverse();
            return list;
        }

        public IEnumerable<T> DfsPathTo(T source, T end)
        {
            var q = new Queue<int>();
            var v = Map.Forward[source];
            var p = Map.Forward[end];
            visited = new bool[this.V];
            visited[v] = true;
            var list = new List<T>();
            prev = (new int[this.V]);
            prev.PopulateWith(-1);
            distTo = new int[this.V];
            distTo[v] = 0;
            Dfs(v);
            if (!visited[p]) { return list; }
            var temp = Map.Reverse;
            for (int i = p; i != v; i = prev[i])
            {
                list.Add(temp[i]);
            }
            list.Add(source);
            list.Reverse();
            return list;
        }

        private HashSet<T> Dfs(int v) => Dfs(v, new HashSet<T>());

        private HashSet<T> Dfs(int v, HashSet<T> set)
        {
            visited[v] = true;
            set.Add(Map.Reverse[v]);
            foreach (var e in Adj[v].Where(e => !visited[e.Other(v)]))
            {
                int w = e.Other(v);
                prev[w] = v;
                Dfs(w, set);
            }
            return set;
        }

        public IEnumerable<T> DfsPathToNon(T source, T end)
        {
            var s = new Stack<int>();
            visited = new bool[this.V];
            prev = Array.CreateWithCapacity(this.V, -1);
            s.Push(Map.Forward[source]);
            visited[Map.Forward[source]] = true;
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
            var temp = Map.Reverse;
            for (var i = Map.Forward[end]; i != Map.Forward[source]; i = prev[i])
            {
                list.Add(temp[i]);
            }
            list.Add(source);
            return list;
        }
     
        public List<IEnumerable<T>> FindCC()
        {
            var components = new List<IEnumerable<T>>();
            prev = Array.CreateWithCapacity(this.V, -1);
            visited = Array.CreateWithCapacity<bool>(this.V);
            for(int i=0; i<this.V; i++)
            {
                if(!visited[i])
                {
                    var set = Dfs(i);
                    components.Add(set.AsEnumerable());
                }
            }
            return components;
        }

        public List<T> ShortestPathTo(T source, T end)
        {
            distTo = Array.CreateWithCapacity(this.V, int.MaxValue);
            edgeTo = Array.CreateWithCapacity<Edge>(this.V);
            return null;

        }
    }
}
