using System.Text;

namespace DataStructuresToolkit.Linked;

public class RoundLinkedList<T> where T : struct
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
		newHead.Prev = Tail;
		
		Head!.Prev = newHead;
		Tail!.Next = newHead;
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
		newTail.Next = Head;

		Head!.Prev = newTail;
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
