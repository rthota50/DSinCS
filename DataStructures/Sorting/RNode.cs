using System;
namespace Sorting
{
	public class RNode
	{
		public int Key { get; set; }
		public RNode Left { get; set; }
		public RNode Right { get; set; }
		public RNode NextRight { get; set; }
		
		public RNode(int key)
		{
			this.Key = key;
			this.Left = null; this.Right = null; this.NextRight = null;
		}
	}
}
