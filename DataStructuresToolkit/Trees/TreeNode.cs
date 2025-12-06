namespace DataStructuresToolkit.Trees;

/// <summary>
/// A node contained in the tree.
/// </summary>
public class TreeNode
{
	/// <summary>
	/// Data contained in the node.
	/// </summary>
	public int Data { get; set; }
	/// <summary>
	/// Node to the left of this one.
	/// </summary>
	public TreeNode? Left { get; set; }
	/// <summary>
	/// Node to the right of this one.
	/// </summary>
	public TreeNode? Right { get; set; }

	public TreeNode(int data) => Data = data;

	/// <summary>
	/// Traverses the tree in order and adds them to a list
	/// </summary>
	/// <param name="node">The starting node</param>
	/// <param name="output">The list that gets added to.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Creates no additional variables.
	/// 	</complexity>
	/// </remarks>
	public static void InOrder(TreeNode node, ref List<TreeNode> output)
	{
		if (node.Left != null)
			InOrder(node.Left, ref output);
		output.Add(node);
		if (node.Right != null)
			InOrder(node.Right, ref output);
	}

	/// <summary>
	/// Traverses the tree in pre order and adds them to a list
	/// </summary>
	/// <param name="node">The starting node</param>
	/// <param name="output">The list that gets added to.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Creates no additional variables.
	/// 	</complexity>
	/// </remarks>
	public static void PreOrder(TreeNode node, ref List<TreeNode> output)
	{
		output.Add(node);
		if (node.Left != null)
			PreOrder(node.Left, ref output);
		if (node.Right != null)
			PreOrder(node.Right, ref output);
	}

	/// <summary>
	/// Traverses the tree in post order and adds them to a list
	/// </summary>
	/// <param name="node">The starting node</param>
	/// <param name="output">The list that gets added too.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Creates no additional variables.
	/// 	</complexity>
	/// </remarks>
	public static void PostOrder(TreeNode node, ref List<TreeNode> output)
	{
		if (node.Left != null)
			PostOrder(node.Left, ref output);
		if (node.Right != null)
			PostOrder(node.Right, ref output);
		output.Add(node);
	}

	/// <summary>
	/// Gets the hight of the tree.
	/// </summary>
	/// <param name="node">The starting point.</param>
	/// <returns>The height.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Only uses left and right variable regardless of size.
	/// 	</complexity>
	/// </remarks>
	public static int GetHeight(TreeNode node)
	{
		if (node == null)
			return -1;
		int leftHeight = GetHeight(node.Left!);
		int rightHeight = GetHeight(node.Right!);
		return 1 + Math.Max(leftHeight, rightHeight);
	}

	/// <summary>
	/// Gets the depth of the specified node.
	/// </summary>
	/// <param name="node">THe starting node.</param>
	/// <param name="target">The item to look for.</param>
	/// <returns>The depth of the item.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recusion, method itself is only used once.
	/// 		Space: O(1) - Only uses 2 variables regardless of size.
	/// 	</complexity>
	/// </remarks>
	public static int GetDepth(TreeNode? node, int target)
	{
		if (node == null)
			return -1;
		if (node.Data == target) 
			return 0;
		int leftDepth = GetDepth(node.Left, target);
		if (leftDepth > -1) 
			return leftDepth + 1;
		int RightDepth = GetDepth(node.Right, target);
		if (RightDepth > -1) 
			return RightDepth + 1;
		return -1;
	}
	public override string ToString() => Data.ToString();
}