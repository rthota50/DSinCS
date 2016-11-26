using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Node
    {
        private int size;
        public int Key;
        public Node Left;
        public Node Right;
        public Node Parent;
        public int Size
        {
            get { return size; }
            set
            {
                if(this.Parent != null)
                {
                    this.Parent.Size = this.Parent.Size + 1;
                }
                size = value;
            }
        }
        public Node(int key, Node parent)
        {
            this.Parent = parent;
            this.Size = 0;
            this.Key = key;
        }
        public override string ToString() => $"Node {{Key : {this.Key}, Size: {this.Size}}}";
    }
}
