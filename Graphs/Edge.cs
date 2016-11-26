using System;

namespace Graphs
{
    public class Edge : IComparable
    {
        private int U { get; set; }
        private int W { get; set; }
        public float Weight { get; private set; }
        #region Constructor
        public Edge(int u, int w, float weight)
        {
            this.U = u; this.W = w; this.Weight = weight;
        }
        public Edge(int u, int w) : this(u, w, 1) { }
        #endregion

        #region API
        public int Either() => this.U;
        public int Other(int u) => this.U == u ? this.W : this.U;
        public override string ToString() => $"Edge: {this.U} => {this.W}";

        public int CompareTo(Object obj)
        {
            var other = obj as Edge;
            return this.Weight.CompareTo(other.Weight);
        } 
        #endregion
    }
}
