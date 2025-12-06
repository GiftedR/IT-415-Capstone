using System.Text;

namespace DataStructuresToolkit.TreePriQUeue;

public class AVLTree
{
	public AVLNode? Root { get; set; }

	public int GetHeight(AVLNode? startingNode) => startingNode?.Height ?? 0;
	public int GetBalance(AVLNode? thisNode) => thisNode == null ? 0 : GetHeight(thisNode.Left) - GetHeight(thisNode.Right);

	private AVLNode RotateRight(AVLNode root)
	{
		AVLNode left = root.Left!;
		AVLNode left_right = left.Right!;

		left.Right = root;
		root.Left = left_right;

		root.Height = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
		left.Height = Math.Max(GetHeight(left.Left), GetHeight(left.Right)) + 1;

		return left;
	}

	private AVLNode RotateLeft(AVLNode root)
	{
		AVLNode right = root.Right!;
		AVLNode right_left = right.Left!;

		right.Left = root;
		root.Right = right_left;

		root.Height = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
		right.Height = Math.Max(GetHeight(right.Left), GetHeight(right.Right)) + 1;

		return right;
	}

	public AVLNode Insert(int nodeValue, AVLNode? node = null)
	{
		if (Root == null) return Root = new AVLNode(nodeValue);

		// if (node == null)
		// 	node = Root;

		// if (nodeValue < node.Value)
		// 	if (node.Left == null)
		// 		return node.Left = new AVLNode(nodeValue);
		// 	else
		// 		node.Left = Insert(nodeValue, node.Left);
		// else if (nodeValue > node.Value)
		// 	if (node.Right == null)
		// 		return node.Right = new AVLNode(nodeValue);
		// 	else
		// 		node.Right = Insert(nodeValue, node.Right);

		if (node == null)
			return new AVLNode(nodeValue);

		if (nodeValue < node.Value)
			node.Left = Insert(nodeValue, node.Left);
		else if (nodeValue > node.Value)
			node.Right = Insert(nodeValue, node.Right);

		node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
		int balance = GetBalance(node);

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
	public int Height { get; set; } = 1;

	public AVLNode(int value)
	{
		Value = value;
	}
}