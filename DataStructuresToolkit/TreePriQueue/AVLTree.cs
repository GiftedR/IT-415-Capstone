using System.Text;

namespace DataStructuresToolkit.TreePriQUeue;

/// <summary>
/// Auto balancing binary tree.
/// </summary>
public class AVLTree
{
	/// <summary>
	/// The root node of the tree.
	/// </summary>
	public AVLNode? Root { get; set; }

	/// <summary>
	/// Gets the height of the specified node.
	/// </summary>
	/// <param name="whichNode">The node to get the height of.</param>
	/// <returns>The height of the node.</returns>
	public int GetHeight(AVLNode? whichNode) => whichNode?.Height ?? 0;
	/// <summary>
	/// Gets the tree balance factor
	/// </summary>
	/// <param name="thisNode">The node to act as a root.</param>
	/// <returns>The balance factor, left heigh - right heigh.</returns>
	public int GetBalanceFactor(AVLNode? thisNode) => thisNode == null ? 0 : GetHeight(thisNode.Left) - GetHeight(thisNode.Right);

	/// <summary>
	/// Rotates a set of 3 nodes right.
	/// </summary>
	/// <param name="root">The pivot point.</param>
	/// <returns>The nodes with fixed rotation.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - No loops, performs the same actions.
	/// 		Space: O(1) - Only uses two variables regardless of arrangement.
	/// 	</complexity>
	/// </remarks>
	private AVLNode RotateRight(AVLNode root) {
		AVLNode left = root.Left!;
		AVLNode left_right = left.Right!;
		left.Right = root;
		root.Left = left_right;
		root.Height = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
		left.Height = Math.Max(GetHeight(left.Left), GetHeight(left.Right)) + 1;
		return left;
	}
	/// <summary>
	/// Rotates a set of 3 nodes left.
	/// </summary>
	/// <param name="root">The pivot point.</param>
	/// <returns>The nodes with fixed rotation.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - No loops, performs the same actions.
	/// 		Space: O(1) - Only uses two variables regardless of arrangement.
	/// 	</complexity>
	/// </remarks>
	private AVLNode RotateLeft(AVLNode root) {
		AVLNode right = root.Right!;
		AVLNode right_left = right.Left!;
		right.Left = root;
		root.Right = right_left;
		root.Height = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
		right.Height = Math.Max(GetHeight(right.Left), GetHeight(right.Right)) + 1;
		return right;
	}

	/// <summary>
	/// Inserts a node into the AVL tree.
	/// </summary>
	/// <param name="nodeValue">The value of the node.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Calls InsertBalanced.
	/// 		Space: O(1) - Calls InsertBalanced.
	/// 	</complexity>
	/// </remarks>
	public void Insert(int nodeValue)
	{
		Root = InsertBalanced(nodeValue, Root);
	}

	/// <summary>
	/// Inserts a new node then balances the tree.
	/// </summary>
	/// <param name="nodeValue"></param>
	/// <param name="node"></param>
	/// <returns>The entire tree but balanced.</returns>
	/// <exception cref="InvalidOperationException">Throws when duplicate values are inserted.</exception>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursive, only calls iteself when needed. No loops.
	/// 		Space: O(1) - Uses same variables regardless of tree structure.
	/// 	</complexity>
	/// </remarks>
	private AVLNode InsertBalanced(int nodeValue, AVLNode? node = null) {
		if (node == null) return new AVLNode(nodeValue);

		if (nodeValue < node.Value)
			node.Left = InsertBalanced(nodeValue, node.Left);
		else if (nodeValue > node.Value)
			node.Right = InsertBalanced(nodeValue, node.Right);
		else if (nodeValue == node.Value)
			throw new InvalidOperationException("AVL Tree cannot have duplicate Data.");

		node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
		int balance = GetBalanceFactor(node);

		// LL
		if (balance > 1 && nodeValue < node.Left!.Value)
			return RotateRight(node);

		// RR
		if (balance < -1 && nodeValue > node.Right!.Value)
			return RotateLeft(node);

		// LR
		if (balance > 1 && nodeValue > node.Left!.Value) {
			node.Left = RotateLeft(node.Left!);
			return RotateRight(node);
		}

		// RL
		if (balance < -1 && nodeValue < node.Right!.Value) {
			node.Right = RotateRight(node.Right!);
			return RotateLeft(node);
		}

		return node;
	}

	/// <summary>
	/// Strigifies the tree.
	/// </summary>
	/// <param name="node">The node to treat as the root.</param>
	/// <param name="indent">The indent character.</param>
	/// <param name="isLeft">Is the tree left by default.</param>
	/// <returns>The string version of the tree.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursive, calls itself and appends to string builder with results.
	/// 		Space: O(1) - Only uses string builder.
	/// 	</complexity>
	/// </remarks>
	public string PrintTree(AVLNode? node, string indent = "", bool isLeft = true)
	{
		if (node == null) return "";

		StringBuilder sb = new();

		sb.Append(indent + (isLeft ? "L-- " : "R-- ")
							+ node.Value + "\n");

		sb.Append(PrintTree(node.Left, indent + "   ", true));
		sb.Append(PrintTree(node.Right, indent + "   ", false));
		return sb.ToString();
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
	private bool Contains(AVLNode? current, int value)
	{
		if (current == null)
			return false;

		if (current.Value == value)
			return true;
		else if (value < current.Value)
			return Contains(current.Left, value);
		else
			return Contains(current.Right, value);
	}

	public override string ToString()
	{
		return PrintTree(Root);
	}
}

/// <summary>
/// Node Used in the AVL tree.
/// </summary>

public class AVLNode
{
	/// <summary>
	/// Node to the left of this one.
	/// </summary>
	public AVLNode? Left { get; set; }
	/// <summary>
	/// Node to the right of this one.
	/// </summary>
	public AVLNode? Right { get; set; }
	/// <summary>
	/// Data contained in the node.
	/// </summary>
	public int Value { get; set; }
	/// <summary>
	/// Stores the height of the node.
	/// </summary>
	public int Height { get; set; }

	public AVLNode(int value)
	{
		Value = value;
		Height = 1;
	}
}