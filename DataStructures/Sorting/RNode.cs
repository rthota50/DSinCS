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
		public override string ToString()
		{
			return string.Format("[RNode: Key={0}, Left={1}, Right={2}, NextRight={3}]", Key, Left, Right, NextRight);
		}
	}
}
