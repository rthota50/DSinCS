using System;

namespace Graphs
{
    public class Edge : IComparable
    {
        private int U { get; set; }
        private int W { get; set; }
        public float Weight { get; private set; }
        public Edge(int u, int w, float weight)
        {
            this.U = u; this.W = w; this.Weight = weight;
        }
        public Edge(int u, int w) : this(u, w, 1) { }
        public int Other(int u) { return this.U == u ? this.W : this.U; }
        public override string ToString()
        {
            return $"Edge: {this.U} => {this.W}";
        }

        public int CompareTo(Object obj)
        {
            var other = obj as Edge;
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
