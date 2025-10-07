namespace DataStructuresToolkit.StackQueues;

public class CustomQueue<T>
{
	private T[] _items;
	private const int minimumItems = 25;
	private int _head;
	private int _tail;

	public int Capacity { get => _items.Length; }
	public int Count { get => _tail - _head; }

	public CustomQueue() : this(25) { }
	public CustomQueue(uint capacity = minimumItems) { _items = new T[capacity]; }
	public CustomQueue(T[] items) { _items = items; }

	public void Enqueue(T newitem)
	{
		if (_tail == Capacity - 1)
			if (Count < Capacity)
				_ShiftItems();
			else
				Array.Resize(ref _items, _items.Length * 2);
		_items[_tail] = newitem;
		_tail++;
	}

	public T Dequeue()
	{
		T dqitem = _items[_head];
		_items[_head] = default!;
		_head++;
		return dqitem;
	}

	public T Peek() => Count > 0 ? _items[_head] : throw new InvalidOperationException("Unable to peek an empty stack.");

	private void _ShiftItems()
	{
		int shiftamount = Capacity - Count;
		for (int idx = 0; idx < Capacity; idx++)
		{
			if (idx < Capacity - shiftamount)
				_items[idx] = _items[idx + shiftamount];
			else
				_items[idx] = default!;
		}
		_head -= shiftamount;
		_tail -= shiftamount;
	}
}