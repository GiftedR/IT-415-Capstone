
using System.Text;

namespace DataStructuresToolkit.Linked;

/// <summary>
/// Handles linking of one item to the next, along with the head.
/// </summary>
/// <typeparam name="T">What type of data the nodes will be.</typeparam>
public class LinkedList<T> where T : struct
{
	/// <summary>
	/// The first item.
	/// </summary>
	public Node<T>? Head { get; protected set; }

	/// <summary>
	/// The amount of items in the list.
	/// </summary>
	public int Count { get; protected set; }

	/// <summary>
	/// Attaches item to the beginning of the list.
	/// </summary>
	/// <param name="data">The value contained in the new item.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Always performs the same operations.
	/// 		Space: O(1) - Only contains the new head.
	/// 	</complexity>
	/// </remarks>
	public void AddFirst(T data)
	{
		Node<T> newHead = new(data);
		Count++;
		if (Head == null)
		{
			Head = newHead;
			return;
		}
		newHead.Next = Head;

		Head = newHead;
	}
	
	/// <summary>
	/// Look for a node within the list.
	/// </summary>
	/// <param name="node">The item to search for.</param>
	/// <param name="offset">The number of items before the specified node.</param>
	/// <returns>The found node if found, otherwise null.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(n) - Loops through items once.
	/// 		Space: O(n) - Keeps a history for the offset.
	/// 	</complexity>
	/// </remarks>
	public Node<T>? GetNode(Node<T> node, int offset = 0)
	{
		if (Head == null) return null;
		Node<T> _fore = Head!;
		List<Node<T>> history = new();

		while ( _fore.Next != null )
		{
			history.Add(_fore);
			if (_fore == node)
			{
				if (offset < 1)
					return node;
				else
					return history[^(offset + 1)];
			}
			_fore = _fore.Next!;
		}

		return null;
	}

	/// <summary>
	/// Gets a value from within the list.
	/// </summary>
	/// <param name="value">The value to look for.</param>
	/// <returns>The value if found, otherwise null.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(n) - Loops through each item once.
	/// 		Space: O(1) - Holds a reference to a list item.
	/// 	</complexity>
	/// </remarks>
	public T? GetValue(T value)
	{
		if (Head == null) return default;
		Node<T> _fore = Head!;

		while ( _fore.Next != null )
		{
			if ((dynamic)_fore.Data! == (dynamic)value!) return value;
			_fore = _fore.Next!;
		}

		return default;
	}

	/// <summary>
	/// Removes a node from the list.
	/// </summary>
	/// <param name="node">The item to remove.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Uses GetNode, so no loops used
	/// 		Space: O(1) - Only holds reference to a node.
	/// 	</complexity>
	/// </remarks>
	public void Remove(Node<T> node)
	{
		if (Head == null) return;

		if (node == Head)
		{
			Head = Head.Next;
		}
		else
		{
			Node<T>? prevDelNode = GetNode(node, 1);
			if (prevDelNode == null) return;
			prevDelNode.Next = prevDelNode.Next!.Next;
		}
	}

	/// <summary>
	/// Reads the list forward and makes it into a string.
	/// </summary>
	/// <param name="separator">The characters between each node value.</param>
	/// <returns>A string containing all the nodes, with head and end specifiers.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(n) - Loops once
	/// 		Space: O(1) - Uses stringbuilder and a pointer to the head.
	/// 	</complexity>
	/// </remarks>
	public string ReadForward(string separator = " -> ")
	{
		if (Head == null) return "";
		StringBuilder sb = new();
		Node<T> _point = Head!;

		sb.Append($"[HEAD]:{_point.Data}{separator}");
		while(_point.Next != null)
		{
			_point = _point.Next!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<END>");

		return sb.ToString();
	}
}
