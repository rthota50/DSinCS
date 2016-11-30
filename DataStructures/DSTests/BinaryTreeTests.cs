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
}