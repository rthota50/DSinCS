using NUnit.Framework;
using Sorting;

[TestFixture]
public class BinaryTreeTests
{
	[TestCase]
	public void Binary_tree_inorder_tests()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		Assert.AreEqual(root.Size, 4);
		var recurse = BinaryTree.Inorder(root);
		var iter = BinaryTree.InorderIterative(root);
		Assert.AreEqual(string.Join(",", recurse), "4,2,5,1,3");
		Assert.AreEqual(string.Join(",", iter), "4,2,5,1,3");
	}

	[TestCase]
	public void Binary_tree_pre_order_tests()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		Assert.AreEqual(root.Size, 4);
		var recursive = BinaryTree.PreOrder(root);
		var iter = BinaryTree.PreOrderIterative(root);
		Assert.AreEqual(string.Join(",", recursive), "1,2,4,5,3");
		Assert.AreEqual(string.Join(",", iter), "1,2,4,5,3");
	}

	[TestCase]
	public void Binary_tree_post_order_tests()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		Assert.AreEqual(root.Size, 4);
		var iter = BinaryTree.PostOrderIterative(root);
		var recur = BinaryTree.PostOrder(root);
		Assert.AreEqual(string.Join(",", iter), "4,5,2,3,1");
		Assert.AreEqual(string.Join(",", recur), "4,5,2,3,1");
	}

	[TestCase]
	public void Binary_tree_level_order_traversal()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		Assert.AreEqual(root.Size, 4);
		var order = BinaryTree.LevelOrder(root);
		Assert.AreEqual("1,2,3,4,5", string.Join(",", order));
	}

	[TestCase]
	public void Binary_tree_zig_zag_traversal()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		Assert.AreEqual(root.Size, 4);
		var order = BinaryTree.ZigzagOrder(root);
		Assert.AreEqual("1,3,2,4,5", string.Join(",", order));
	}

	[TestCase]
	public void Binary_tree_height()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		Assert.AreEqual(root.Size, 4);
		uint height = BinaryTree.FindHeight(root);
		Assert.True(height == 3);
		height = BinaryTree.FindHeightIter(root);
		Assert.True(height == 3);
		root = new Node(1, null);
		root.Left = new Node(2, root.Left);
		root.Left.Left = new Node(3, root.Left);
		root.Left.Left.Left = new Node(4, root.Left.Left);
		root.Left.Left.Left.Left = new Node(5, root.Left.Left.Left);
		var h1 = BinaryTree.FindHeight(root);
		var h2 = BinaryTree.FindHeightIter(root);
		Assert.AreEqual(h1, h2);
	}

	[TestCase]
	public void Binary_tree_find_max_diameter()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		Assert.AreEqual(root.Size, 4);
		uint diameter = BinaryTree.FindMaxDiameter(root);
		Assert.AreEqual(4, diameter);
	}

	[TestCase]
	public void BinaryTree_Invert_tree()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		root.Right.Left = new Node(6, root.Right);
		root.Right.Right = new Node(7, root.Left);

		root = BinaryTree.InvertTree(root);
		Assert.AreEqual(root.Key, 1);
		Assert.AreEqual(root.Left.Key, 3);
		Assert.AreEqual(root.Right.Key, 2);
		Assert.AreEqual(root.Left.Left.Key, 7);
		Assert.AreEqual(root.Right.Right.Key, 4);
		Assert.AreEqual(root.Right.Left.Key, 5);
		Assert.AreEqual(root.Left.Right.Key, 6);

	}

	[TestCase]
	public void BinaryTree_Invert_tree_using_recursion()
	{
		var root = new Node(1, null);
		root.Left = new Node(2, root);
		root.Right = new Node(3, root);
		root.Left.Left = new Node(4, root.Left);
		root.Left.Right = new Node(5, root.Left);
		root.Right.Left = new Node(6, root.Right);
		root.Right.Right = new Node(7, root.Left);

		root = BinaryTree.InvertTreeRecurse(root);
		Assert.AreEqual(root.Key, 1);
		Assert.AreEqual(root.Left.Key, 3);
		Assert.AreEqual(root.Right.Key, 2);
		Assert.AreEqual(root.Left.Left.Key, 7);
		Assert.AreEqual(root.Right.Right.Key, 4);
		Assert.AreEqual(root.Right.Left.Key, 5);
		Assert.AreEqual(root.Left.Right.Key, 6);

	}

	[TestCase]
	public void Tree_is_subtree()
	{
		var a = new Node(10, null);
		a.Left = new Node(4, a);
		a.Right = new Node(6, a);
		a.Left.Right = new Node(30, a.Left);
		var b = new Node(26, null);
		b.Left = new Node(10, b);
		b.Right = new Node(3, b);
		b.Left.Left = new Node(4, b.Left);
		b.Left.Right = new Node(6, b.Left);
		b.Left.Left.Right = new Node(30, b.Left.Left);
		b.Right.Right = new Node(3, b.Right);

		var res = BinaryTree.IsSubtree(b, a);
		Assert.False(res);
	}

	[TestCase]
	public void Connect_nodes_in_level_Binary_Tree()
	{
		var root = new RNode(1);
		root.Left = new RNode(2);
		root.Right = new RNode(3);
		root.Left.Left = new RNode(4);
		root.Left.Right = new RNode(5);
		root.Right.Left = new RNode(6);
		root.Right.Right = new RNode(7);
		var res = BinaryTree.ConnectToRightLevelOrder(root);
		Assert.IsNull(res.NextRight);
		Assert.IsNull(res.Right.NextRight);
		Assert.AreEqual(res.Left.NextRight.Key, 3);
		Assert.AreEqual(res.Left.Left.NextRight.Key, 5);
		Assert.AreEqual(res.Left.Right.NextRight.Key, 6);
		Assert.AreEqual(res.Right.Left.NextRight.Key, 7);
	}
}