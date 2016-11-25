using System;
using System.Collections.Generic;
using System.Linq;
using DS.Utils;

namespace Graphs
{
    public class UGraph<T> : Graph<T>
    {
        protected override Map<T, int> Map { get; set; }
        protected override Dictionary<int, List<Edge>> Adj { get; set; }

        public UGraph(uint v) : base(v)
        {
            this.Map = new Map<T, int>();
            this.Adj = new Dictionary<int, List<Edge>>((int)v);
        }
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
            this.Adj[mw].Add(new Edge(mw, mu, weight));
        }
        public override void AddEdge(T u, T w)
        {
            this.AddEdge(u, w, 1);
        }
        
    }
}
