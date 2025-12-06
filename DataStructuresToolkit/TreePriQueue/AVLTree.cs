using System.Text;

namespace DataStructuresToolkit.TreePriQUeue;

public class AVLTree
{
	public AVLNode? Root { get; set; }

	private int getHeight(AVLNode? startingNode) => startingNode?.Height ?? 0;
	public int GetBalance(AVLNode? thisNode) => thisNode == null ? 0 : getHeight(thisNode.Left) - getHeight(thisNode.Right);

	private AVLNode RotateRight(AVLNode root)
	{
		AVLNode left = root.Left!;
		AVLNode left_right = left.Right!;

		left.Right = root;
		root.Left = left_right;

		root.Height = Math.Max(getHeight(root.Left), getHeight(root.Right)) + 1;
		left.Height = Math.Max(getHeight(left.Left), getHeight(left.Right)) + 1;

		return left;
	}

	private AVLNode RotateLeft(AVLNode root)
	{
		AVLNode right = root.Right!;
		AVLNode right_left = right.Left!;

		right.Left = root;
		root.Right = right_left;

		root.Height = Math.Max(getHeight(root.Left), getHeight(root.Right)) + 1;
		right.Height = Math.Max(getHeight(right.Left), getHeight(right.Right)) + 1;

		return right;
	}

	public void TryBalance(AVLNode? thisNode = null)
	{
		if (thisNode == null)
			thisNode = Root;
		
		
	}

	public AVLNode Insert(int nodeValue, AVLNode? node = null)
	{
		if (Root == null)
			return Root = new AVLNode(nodeValue);

		if (node == null)
			node = Root;

		if (nodeValue < node.Value)
			return node.Left == null ? node.Left = new AVLNode(nodeValue) : Insert(nodeValue, node.Left);
		if (nodeValue > node.Value)
			return node.Right == null ? node.Right = new AVLNode(nodeValue) : Insert(nodeValue, node.Right);

		node.Height = 1 + Math.Max(getHeight(node.Left), getHeight(node.Right));
		
		if (nodeValue == node.Value)
			throw new InvalidOperationException("Duplicate values are not allowed");
		
		return node;
	}

	public AVLNode InsertBalanced(int nodeValue, AVLNode? node = null)
	{if (node == null) return new AVLNode(nodeValue);

		if (nodeValue < node.Value)
			node.Left = InsertBalanced(nodeValue, node.Left);
		else if (nodeValue > node.Value)
			node.Right = InsertBalanced(nodeValue, node.Right);

		node.Height = 1 + Math.Max(getHeight(node.Left), getHeight(node.Right));
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

	public override string ToString()
	{
		return PrintTree(Root);
	}
}

public class AVLNode
{
	public AVLNode? Left { get; set; }
	public AVLNode? Right { get; set; }
	public int Value { get; set; }
	public int Height { get; set; } = 1;

	public AVLNode(int value)
	{
		Value = value;
	}
}