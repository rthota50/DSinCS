using Sorting;
using Xunit;

namespace DSTests
{
    public class SortingTests
    {
        [Fact]
        public void Min_index_priority_queue()
        {
            var p = new MinIndexPQ<string>(10);
            p.InsertKey(5,"a");
            p.InsertKey(4,"b");
            p.InsertKey(3,"c");
            p.InsertKey(2,"d");
            p.InsertKey(1,"e");
            p.InsertKey(0,"f");
            Assert.Equal(p.DelMinKey(), "a");
            Assert.Equal(p.DelMinKey(), "b");
            Assert.Equal(p.DelMinKey(), "c");
            Assert.Equal(p.DelMinKey(), "d");
            Assert.Equal(p.DelMinKey(), "e");
        }

        [Fact]
        public void Min_priority_queue()
        {
            var p = new MinPQ<int>(5);
            p.Insert(5);
            Assert.Equal("5", string.Join(",", p.CurrentPQ()));

            p.Insert(4);
            Assert.Equal("4,5", string.Join(",", p.CurrentPQ()));

            p.Insert(99);
            Assert.Equal("4,5,99", string.Join(",", p.CurrentPQ()));

            p.Insert(14);
            Assert.Equal("4,5,99,14", string.Join(",", p.CurrentPQ()));

            p.Insert(0);
            Assert.Equal("0,4,99,14,5", string.Join(",", p.CurrentPQ()));
        }

        [Fact]
        public void Min_pq_delete_tests()
        {
            var p = new MinPQ<int>(5);
            p.Insert(5);
            p.Insert(4);
            p.Insert(99);
            p.Insert(14);
            p.Insert(0);
            Assert.Equal(0, p.DelMin());
            Assert.Equal(4, p.DelMin());
            Assert.Equal(5, p.DelMin());
            Assert.Equal(14, p.DelMin());
            Assert.Equal(99, p.DelMin());
        }

        [Fact]
        public void Binary_tree_inorder_tests()
        {
            var root = new Node(1, null);
            root.Left = new Node(2, root);
            root.Right = new Node(3, root);
            root.Left.Left = new Node(4, root.Left);
            root.Left.Right = new Node(5, root.Left);
            Assert.Equal(root.Size, 4);
            var recurse = BinaryTree.Inorder(root);
            var iter = BinaryTree.InorderIterative(root);
            Assert.Equal(string.Join(",", recurse), "4,2,5,1,3");
            Assert.Equal(string.Join(",", iter), "4,2,5,1,3");
        }

        [Fact]
        public void Binary_tree_pre_order_tests()
        {
            var root = new Node(1, null);
            root.Left = new Node(2, root);
            root.Right = new Node(3, root);
            root.Left.Left = new Node(4, root.Left);
            root.Left.Right = new Node(5, root.Left);
            Assert.Equal(root.Size, 4);
            var recursive = BinaryTree.PreOrder(root);
            var iter = BinaryTree.PreOrderIterative(root);
            Assert.Equal(string.Join(",", recursive), "1,2,4,5,3");
            Assert.Equal(string.Join(",", iter), "1,2,4,5,3");
        }

        [Fact]
        public void Binary_tree_post_order_tests()
        {
            var root = new Node(1, null);
            root.Left = new Node(2, root);
            root.Right = new Node(3, root);
            root.Left.Left = new Node(4, root.Left);
            root.Left.Right = new Node(5, root.Left);
            Assert.Equal(root.Size, 4);
            var iter = BinaryTree.PostOrderIterative(root);
            var recur = BinaryTree.PostOrder(root);
            Assert.Equal(string.Join(",", iter), "4,5,2,3,1");
            Assert.Equal(string.Join(",", recur), "4,5,2,3,1");
        }

        [Fact]
        public void Binary_tree_level_order_traversal()
        {
            var root = new Node(1, null);
            root.Left = new Node(2, root);
            root.Right = new Node(3, root);
            root.Left.Left = new Node(4, root.Left);
            root.Left.Right = new Node(5, root.Left);
            Assert.Equal(root.Size, 4);
            var order = BinaryTree.LevelOrder(root);
            Assert.Equal("1,2,3,4,5", string.Join(",", order));
        }

        [Fact]
        public void Binary_tree_zig_zag_traversal()
        {
            var root = new Node(1, null);
            root.Left = new Node(2, root);
            root.Right = new Node(3, root);
            root.Left.Left = new Node(4, root.Left);
            root.Left.Right = new Node(5, root.Left);
            Assert.Equal(root.Size, 4);
            var order = BinaryTree.ZigzagOrder(root);
            Assert.Equal("1,3,2,4,5", string.Join(",", order));
        }
    }
}
