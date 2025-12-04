using System.Text;

namespace DataStructuresToolkit.Linked;

/// <summary>
/// Handles linking an item to the next and the previous, along with a head and a tail. And ensures items loop back around.
/// </summary>
/// <typeparam name="T">The value of each node</typeparam>
public class RoundLinkedList<T> where T : struct
{
	/// <summary>
	/// The first item.
	/// </summary>
	public DoubleNode<T>? Head { get; protected set; }
	/// <summary>
	/// The last item.
	/// </summary>

	public DoubleNode<T>? Tail { get; protected set; }
	/// <summary>
	/// The number of items in the list.
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
		Count++;
		if (Head == null && Tail == null)
		{
			Head = Tail = new DoubleNode<T>(data);
			return;
		}
		DoubleNode<T> newHead = new(data);
		newHead.Next = Head;
		newHead.Prev = Tail;
		
		Head!.Prev = newHead;
		Tail!.Next = newHead;
		Head = newHead;
	}
	
	/// <summary>
	/// Attaches item to the end of the list.
	/// </summary>
	/// <param name="data">The value contained in the new item.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Always performs the same operations.
	/// 		Space: O(1) - Only contains the new tail.
	/// 	</complexity>
	/// </remarks>
	public void AddLast(T data)
	{
		Count++;
		if (Head == null && Tail == null)
		{
			Head = Tail = new(data);
			return;
		}
		DoubleNode<T> newTail = new(data);
		newTail.Prev = Tail;
		newTail.Next = Head;

		Head!.Prev = newTail;
		Tail!.Next = newTail;
		Tail = newTail;
	}

	/// <summary>
	/// Look for a node within the list.
	/// </summary>
	/// <param name="node">The item to search for.</param>
	/// <param name="offset">The number of items before the specified node.</param>
	/// <returns>The found node if found, otherwise null.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(2/n) - Loops through items from each end. (Also does extra steps if offset specified)
	/// 		Space: O(1) - Only handles references.
	/// 	</complexity>
	/// </remarks>		
	public DoubleNode<T>? GetNode(DoubleNode<T> node, int offset = 0)
	{
		if (Head == null || Tail == null) return null;
		DoubleNode<T> _fore = Head!;
		DoubleNode<T> _back = Tail!;

		do
		{
			_fore = _fore.Next!;
			_back = _back.Prev!;
			if (_fore == node || _back == node)
			{
				if (offset < 1)
				{
					return node;
				}
				else
				{
					DoubleNode<T> _ptr = node;
					for (int idx = 0; idx < offset; idx++)
						_ptr = _ptr.Prev!;
					return _ptr;
				}
			}
		}
		while (
			_fore != _back &&
			_fore.Prev != _back
		);

		return null;
	}

	/// <summary>
	/// Gets a value from within the list.
	/// </summary>
	/// <param name="value">The value to look for.</param>
	/// <returns>The value if found, otherwise null.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(2/n) - Loops through each item once from each end.
	/// 		Space: O(1) - Holds a reference to a list item from each end.
	/// 	</complexity>
	/// </remarks>
	public T? GetValue(T value)
	{
		if (Head == null || Tail == null) return null;
		DoubleNode<T> _fore = Head!;
		DoubleNode<T> _back = Tail!;
		do
		{
			if (EqualityComparer<T>.Default.Equals(_fore.Data, value))
				return _fore.Data;
			if (EqualityComparer<T>.Default.Equals(_back.Data, value))
				return _back.Data;
			_fore = _fore.Next!;
			_back = _back.Prev!;
		}
		while (
			_fore != _back &&
			_fore.Prev != _back
		);

		return null;
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
	public void Remove(DoubleNode<T> node)
	{
		if (Head == null && Tail == null) return;

		if (node == Head)
		{
			Tail!.Next = Head.Next;
			Head.Next!.Prev = Tail;
			Head = Head.Next;
		}
		else if (node == Tail)
		{
			Tail.Prev!.Next = Head;
			Head!.Prev = Tail.Prev;
			Tail = Tail.Prev;
		}
		else
		{
			DoubleNode<T>? delNode = GetNode(node);
			if (delNode == null) return;
			delNode.Next!.Prev = delNode.Prev;
			delNode.Prev!.Next = delNode.Next;
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
		if (Head == null || Tail == null) return "";
		if (Head == Tail) return Head.ToString()!;
		StringBuilder sb = new();
		DoubleNode<T> _head = Head!;
		DoubleNode<T> _point = Head!;

		sb.Append($"[HEAD]:{_point.Data}{separator}");
		while(_point.Next != _head)
		{
			_point = _point.Next!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<HEAD>");

		return sb.ToString();
	}
	/// <summary>
	/// Reads the list backward and makes it into a string.
	/// </summary>
	/// <param name="separator">The characters between each node value.</param>
	/// <returns>A string containing all the nodes, with head and end specifiers.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(n) - Loops once
	/// 		Space: O(1) - Uses stringbuilder and a pointer to the tail.
	/// 	</complexity>
	/// </remarks>
	public string ReadBackward(string separator = " -> ")
	{
		if (Head == null || Tail == null) return "";
		if (Head == Tail) return Tail.ToString()!;
		StringBuilder sb = new();
		DoubleNode<T> _tail = Tail!;
		DoubleNode<T> _point = Tail!;

		sb.Append($"[TAIL]:{_point.Data}{separator}");
		while(_point.Prev != _tail)
		{
			_point = _point.Prev!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<TAIL>");

		return sb.ToString();
	}

	public override string ToString() => ReadForward();
}
