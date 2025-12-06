namespace DataStructuresToolkit.Trees;

/// <summary>
/// Binary Tree data structure. Assumes that it is sorted.
/// </summary>
public class BST
{
	/// <summary>
	/// The Root of the BST.
	/// </summary>
	public TreeNode? Root { get; set; }

	/// <summary>
	/// Inserts a new value into the tree.
	/// </summary>
	/// <param name="value">The value to insert.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursive, only calls self.
	/// 		Space: O(1) - Creates no new variables.
	/// 	</complexity>
	/// </remarks>
	public void Insert(int value)
	{
		if (Root == null)
			Root = new TreeNode(value);
		else
			Insert(Root, value);
	}

	/// <summary>
	/// Inserts a new node into the tree.
	/// </summary>
	/// <param name="current">The root of the tree.</param>
	/// <param name="value">The value to be inserted.</param>
	/// <exception cref="InvalidOperationException">Thrown when value is a duplicate value.</exception>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursive, only calls self.
	/// 		Space: O(1) - Creates no new variables.
	/// 	</complexity>
	/// </remarks>
	private void Insert(TreeNode current, int value)
	{
		if (value < current.Data)
			if (current.Left == null)
				current.Left = new TreeNode(value);
			else
				Insert(current.Left, value);
		else if (value > current.Data)
			if (current.Right == null)
				current.Right = new TreeNode(value);
			else
				Insert(current.Right, value);
		else if (value == current.Data)
			throw new InvalidOperationException("BST cannot contain duplicate values");
	}

	/// <summary>
	/// Searches for a value in the tree.
	/// </summary>
	/// <param name="value">The value to search for.</param>
	/// <returns>Wether it is found or not.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Calls other search.
	/// 		Space: O(1) - Calls other search.
	/// 	</complexity>
	/// </remarks>
	public bool Contains(int value)
	{
		return Contains(Root, value);
	}

	/// <summary>
	/// Searches for a new in the tree.
	/// </summary>
	/// <param name="current">The root node.</param>
	/// <param name="value">The value to search for.</param>
	/// <returns>Wether the node is found or not.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursive, only calls self.
	/// 		Space: O(1) - Creates no new variables.
	/// 	</complexity>
	/// </remarks>
	private bool Contains(TreeNode? current, int value)
	{
		if (current == null)
			return false;

		if (current.Data == value)
			return true;
		else if (value < current.Data)
			return Contains(current.Left, value);
		else
			return Contains(current.Right, value);
	}

	/// <summary>
	/// Creates a sample tree for use with traversals, depth and height.
	/// </summary>
	/// <returns>Sample Tree</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Only makes a new object.
	/// 		Space: O(1) - Only called once.
	/// 	</complexity>
	/// </remarks>
	public static BST CreateTeachingTree() => new BST
	{
		Root = new TreeNode(38)
		{
			Left = new TreeNode(27)
			{
				Left = new TreeNode(3),
				Right = new TreeNode(9)
			},
			Right = new TreeNode(43)
		}
	};

	/// <summary>
	/// Gets the height of the tree.
	/// </summary>
	/// <param name="tree">The tree.</param>
	/// <returns>The height.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Calls GetHeight on root node.
	/// 		Space: O(1) - Calls GetHeight on root node.
	/// 	</complexity>
	/// </remarks>
	#pragma warning disable CS8604
	public static int GetHeight(BST tree) => TreeNode.GetHeight(tree.Root);

	/// <summary>
	/// Gets the depth of the tree.
	/// </summary>
	/// <param name="tree">The tree.</param>
	/// <param name="target">The item to look for.</param>
	/// <returns>The depth.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Calls GetDepth on root node.
	/// 		Space: O(1) - Calls GetDepth on root node.
	/// 	</complexity>
	/// </remarks>
	public static int GetDepth(BST tree, int target) => TreeNode.GetDepth(tree.Root, target);
	#pragma warning restore CS8604
}