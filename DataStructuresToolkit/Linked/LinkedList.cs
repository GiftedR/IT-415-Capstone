
using System.Text;

namespace DataStructuresToolkit.Linked;

public class LinkedList<T> where T : struct
{
	public Node<T>? Head { get; protected set; }

	public int Count { get; protected set; }

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
