
using System.Text;

namespace DataStructuresToolkit.Linked;

public class LinkedList<T>
{
	public Node<T>? Head { get; protected set; }

	public int Count { get; protected set; }

	public void AddFirst(T data)
	{
		Node<T> newHead = new(data);
		if (Head == null)
		{
			Head = newHead;
			return;
		}
		newHead.Next = Head;

		Head = newHead;
	}
	
	public Node<T>? GetNode(Node<T> node)
	{
		if (Head == null) return null;
		Node<T> _fore = Head!;

		while ( _fore.Next != null )
		{
			if (_fore == node) return node;
			_fore = _fore.Next!;
		}

		return null;
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
			Node<T>? delNode = GetNode(node);
			if (delNode == null) return;
		}
	}

	public string ReadForward(string separator = " -> ")
	{
		if (Head == null) return "";
		StringBuilder sb = new();
		Node<T> _head = Head!;
		Node<T> _point = Head!;

		sb.Append($"[HEAD]:{_point.Data}{separator}");
		while(_point.Next != _head)
		{
			_point = _point.Next!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<HEAD>");

		return sb.ToString();
	}
}
