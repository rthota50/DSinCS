using System;
using System.Collections.Generic;
namespace Sorting
{
	public class BinaryTree
	{
		#region InOrder Traversal
		public static int[] Inorder(Node root)
		{
			var order = new List<int>(root.Size + 1);
			InorderTraversal(root, order);
			return order.ToArray();
		}
		private static void InorderTraversal(Node root, List<int> order)
		{
			if (root == null)
			{ return; }
			InorderTraversal(root.Left, order);
			order.Add(root.Key);
			InorderTraversal(root.Right, order);
		}
		public static int[] InorderIterative(Node root)
		{
			var s = new Stack<Node>();
			var curr = root;
			s.Push(curr);
			while (curr.Left != null)
			{
				s.Push(curr.Left);
				curr = curr.Left;
			}
			int i = 0;
			var order = new int[root.Size + 1];
			while (s.Count != 0)
			{
				var node = s.Pop();
				order[i++] = node.Key;
				if (node.Right != null)
				{
					var localNode = node.Right;
					s.Push(localNode);
					while (localNode.Left != null)
					{
						s.Push(localNode.Left);
						localNode = localNode.Left;
					}
				}
			}
			return order;
		}
		#endregion

		#region PreOrder Traversal
		public static int[] PreOrder(Node root)
		{
			var order = new List<int>(root.Size + 1);
			PreOrderRecursive(root, order);
			return order.ToArray();
		}
		private static void PreOrderRecursive(Node root, List<int> order)
		{
			if (root == null) { return; }
			order.Add(root.Key);
			PreOrderRecursive(root.Left, order);
			PreOrderRecursive(root.Right, order);
		}

		public static int[] PreOrderIterative(Node root)
		{
			var order = new int[root.Size + 1];
			int i = 0;
			var q = new Stack<Node>();
			q.Push(root);
			while (q.Count != 0)
			{
				var node = q.Pop();
				order[i++] = node.Key;

				if (node.Right != null)
				{ q.Push(node.Right); }
				if (node.Left != null)
				{ q.Push(node.Left); }
			}
			return order;
		}
		#endregion

		#region PostOrder Traversal
		public static int[] PostOrder(Node root)
		{
			var order = new List<int>(root.Size + 1);
			PostOrderRecursive(root, order);
			return order.ToArray();
		}
		private static void PostOrderRecursive(Node root, List<int> order)
		{
			if (root == null) { return; }
			PostOrderRecursive(root.Left, order);
			PostOrderRecursive(root.Right, order);
			order.Add(root.Key);
		}

		public static int[] PostOrderIterative(Node root)
		{
			var order = new int[root.Size + 1];
			int i = 0;
			var s = new Stack<Node>();
			do
			{
				while (root != null)
				{
					if (root.Right != null)
					{ s.Push(root.Right); }
					s.Push(root);
					root = root.Left;
				}
				root = s.Pop();
				if (root.Right != null && s.Count > 0 && s.Peek() == root.Right)
				{
					s.Pop();
					s.Push(root);
					root = root.Right;
				}
				else
				{
					order[i++] = root.Key;
					root = null;
				}

			} while (s.Count != 0);
			return order;
		}
		#endregion

		#region Level Order Traversal
		public static int[] LevelOrder(Node root)
		{
			if (root == null) { return new int[0]; }
			var order = new int[root.Size + 1];
			var q = new Queue<Node>();
			int i = 0;
			q.Enqueue(root);
			while (q.Count != 0)
			{
				root = q.Dequeue();
				order[i++] = root.Key;
				if (root.Left != null)
				{
					q.Enqueue(root.Left);
				}
				if (root.Right != null)
				{
					q.Enqueue(root.Right);
				}
			}
			return order;
		}

		#endregion

		#region Zigzag Traversal

		public static int[] ZigzagOrder(Node root)
		{
			if (root == null) { return new int[0]; }
			var order = new int[root.Size + 1];
			var s1 = new Stack<Node>();
			var s2 = new Stack<Node>();
			s1.Push(root);
			int i = 0;
			while (s1.Count != 0 || s2.Count != 0)
			{
				while (s1.Count != 0)
				{
					root = s1.Pop();
					order[i++] = root.Key;
					if (root.Left != null)
					{
						s2.Push(root.Left);
					}
					if (root.Right != null)
					{
						s2.Push(root.Right);
					}
				}
				while (s2.Count != 0)
				{
					root = s2.Pop();
					order[i++] = root.Key;
					if (root.Right != null)
					{
						s1.Push(root.Right);
					}
					if (root.Left != null)
					{
						s1.Push(root.Left);
					}
				}
			}
			return order;
		}


		#endregion

		#region Diameter
		public static uint FindHeight(Node root)
		{
			if (root == null) { return 0; }
			return Math.Max(FindHeight(root.Left), FindHeight(root.Right)) + 1;
		}

		public static uint FindHeightIter(Node root)
		{
			if (root == null) { return 0; }
			var q = new Queue<Node>();
			q.Enqueue(root);
			q.Enqueue(null);
			uint height = 0;
			while (q.Count > 1)
			{
				root = q.Dequeue();
				if (root == null)
				{
					height++;
					q.Enqueue(null);
					continue;
				}
				if (root.Left != null)
				{
					q.Enqueue(root.Left);
				}
				if (root.Right != null)
				{
					q.Enqueue(root.Left);
				}

			}
			return height + 1;
		}

		public static uint FindMaxDiameter(Node root)
		{
			if (root == null) return 0;
			var lheight = FindHeight(root.Left);
			var rheight = FindHeight(root.Right);
			var ldiameter = FindMaxDiameter(root.Left);
			var rdiameter = FindMaxDiameter(root.Right);
			return Math.Max(lheight + rheight + 1, Math.Max(ldiameter, rdiameter));
		}
		#endregion

		#region Sub Tree
		public static bool IsSubtree(Node root, Node find)
		{
			if (root == null || find == null) { return false; }
			var q = new Queue<Node>();
			q.Enqueue(root);
			var found = false;
			while (q.Count > 0 && !found)
			{
				root = q.Dequeue();
				if (root.Key == find.Key)
				{
					found = AreSameTrees(root, find);
				}
				if (root.Left != null)
				{
					q.Enqueue(root.Left);
				}
				if (root.Right != null)
				{
					q.Enqueue(root.Right);
				}
			}
			return found;
		}

		private static bool AreSameTrees(Node a, Node b)
		{
			if (a == null && b == null) { return true; }
			if ((a == null && b != null) || (a != null && b == null))
			{
				return false;
			}
			if (a.Key == b.Key)
			{
				return AreSameTrees(a.Left, b.Left) && AreSameTrees(a.Right, b.Right);
			}
			return false;
		}
		#endregion

		#region Invert Tree
		public static Node InvertTree(Node root)
		{
			if (root == null) { throw new ArgumentNullException(); }

			var q = new Queue<Node>();
			q.Enqueue(root);
			Node node;
			while (q.Count > 0)
			{
				node = q.Dequeue();
				//queue if exists
				if (node.Left != null)
				{
					q.Enqueue(node.Left);
				}
				if (node.Right != null)
				{
					q.Enqueue(node.Right);
				}
				//swap
				var temp = node.Right;
				if (node.Right != null) { node.Right = node.Left; }
				if (temp != null) { node.Left = temp; }
			}
			return root;
		}

		public static Node InvertTreeRecurse(Node root)
		{
			if (root == null) { return null; }
			var right = InvertTreeRecurse(root.Right);
			var left = InvertTreeRecurse(root.Left);
			root.Left = right;
			root.Right = left;
			return root;
		}

		#endregion

		#region Connect nodes to right
		public static RNode ConnectToRightLevelOrder(RNode root)
		{
			if (root == null) return null;
			var ret = root;
			var q = new Queue<RNode>();
			q.Enqueue(root);
			q.Enqueue(null);
			while (q.Count > 1)
			{
				root = q.Dequeue();
				if (root == null) { q.Enqueue(null); continue;}
				root.NextRight = q.Peek();
				if (root.Left != null) { q.Enqueue(root.Left); }
				if (root.Right != null) { q.Enqueue(root.Right); }
			}

			return ret;
		}
		#endregion
	}
}
