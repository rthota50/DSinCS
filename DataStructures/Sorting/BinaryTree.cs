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
                    if(root.Left != null)
                    {
                        s2.Push(root.Left);
                    }
                    if(root.Right != null)
                    {
                        s2.Push(root.Right);
                    }
                }
                while(s2.Count != 0)
                {
                    root = s2.Pop();
                    order[i++] = root.Key;
                    if(root.Right != null)
                    {
                        s1.Push(root.Right);
                    }
                    if(root.Left != null)
                    {
                        s1.Push(root.Left);
                    }
                }
            }
            return order;
        }
        #endregion
    }
}
