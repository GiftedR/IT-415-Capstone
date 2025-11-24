using System.Text;

namespace DataStructuresToolkit.Linked;

public class DoublyLinkedList<T> where T : struct
{
	public DoubleNode<T>? Head { get; protected set; }
	public DoubleNode<T>? Tail { get; protected set; }
	public int Count { get; protected set; }

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
		Head!.Prev = newHead;
		Head = newHead;
	}
	
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
		Tail!.Next = newTail;
		Tail = newTail;
	}
	
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

	public T? GetValue(T value)
	{
		if (Head == null) return null;
		DoubleNode<T> _fore = Head!;

		do
		{
			if (EqualityComparer<T>.Default.Equals(_fore.Data, value)) return value;
			_fore = _fore.Next!;
		}
		while ( _fore != null );

		return null;
	}

	public void Remove(DoubleNode<T> node)
	{
		if (Head == null && Tail == null) return;

		if (node == Head)
		{
			Head.Next!.Prev = null;
			Head = Head.Next;
		}
		else if (node == Tail)
		{
			Tail.Prev!.Next = null;
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

	public string ReadForward(string separator = " -> ")
	{
		if (Head == null || Tail == null) return "";
		if (Head == Tail) return Head.ToString()!;
		StringBuilder sb = new();
		DoubleNode<T> _point = Head!;

		sb.Append($"[HEAD]:{_point.Data}{separator}");
		while(_point.Next != null)
		{
			_point = _point.Next!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<END>");

		return sb.ToString();
	}

	public string ReadBackward(string separator = " -> ")
	{
		if (Head == null || Tail == null) return "";
		if (Head == Tail) return Tail.ToString()!;
		StringBuilder sb = new();
		DoubleNode<T> _point = Tail!;

		sb.Append($"[TAIL]:{_point.Data}{separator}");
		while(_point.Prev != null)
		{
			_point = _point.Prev!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<END>");

		return sb.ToString();
	}

	public override string ToString() => ReadForward();
}
