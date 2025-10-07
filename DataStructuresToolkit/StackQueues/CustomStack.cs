namespace DataStructuresToolkit.StackQueues;

public class CustomStack<T>
{
	private T[] _items;
	private const int minimumItems = 25;
	private int _count = 0;

	public int Capacity { get => _items.Length; }
	public int Count { get => _count; }

	public CustomStack() : this(25) { }
	public CustomStack(uint capacity = minimumItems) { _items = new T[capacity]; }
	public CustomStack(T[] items) { _items = items; }

	public void Push(T newItem)
	{
		if (_count == _items.Length)
			Array.Resize(ref _items, _items.Length * 2);
		_items[_count] = newItem;
		_count++;
	}

	public T Pop()
	{
		T popitem = _items[_count - 1];
		_items[_count - 1] = default!;
		_count--;
		return popitem;
	}

	public T Peek() => _count > 0 ? _items[_count - 1] : throw new InvalidOperationException("Unable to peek an empty stack.");
}