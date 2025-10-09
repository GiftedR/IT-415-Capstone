namespace DataStructuresToolkit.StackQueues;

/// <summary>
/// Custom implementation of the built in queue.
/// </summary>
/// <typeparam name="T">The type of item the queue can hold.</typeparam>
public class CustomQueue<T>
{
	private T[] _items;
	private const int minimumItems = 25;
	private int _head;
	private int _tail;

	/// <summary>
	/// Shows the number of items the queue can hold.
	/// </summary>
	public int Capacity { get => _items.Length; }
	/// <summary>
	/// The amount of items currently in the queue.
	/// </summary>
	public int Count { get => _tail - _head; }

	/// <summary>
	/// Creates a queue with the default capacity.
	/// </summary>
	public CustomQueue() : this(25) { }

	/// <summary>
	/// Creates a queue with the specified capacity.
	/// </summary>
	/// <param name="capacity">The starting capactiy of the queue</param>
	public CustomQueue(uint capacity = minimumItems) { _items = new T[capacity]; }

	/// <summary>
	/// Creates a queue with a starting set of items.
	/// </summary>
	/// <param name="items">The items that start within the queue.</param>
	public CustomQueue(T[] items) { _items = items; }

	/// <summary>
	/// Adds a new item to the queue.
	/// </summary>
	/// <param name="newitem">The item that gets put at the back of the queue.</param>
	public void Enqueue(T newitem)
	{
		if (_tail == Capacity)
			if (Count < Capacity)
				_ShiftItems();
			else
				Array.Resize(ref _items, _items.Length * 2);
		_items[_tail] = newitem;
		_tail++;
	}

	/// <summary>
	/// Removes an item from the queue.
	/// </summary>
	/// <returns>The item at the from of the queue.</returns>
	/// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
	public T Dequeue()
	{
		if (Count == 0)
			throw new InvalidOperationException("Unable to dequeue an empty queue.");
		T dqitem = _items[_head];
		_items[_head] = default!;
		_head++;
		return dqitem;
	}

	/// <summary>
	/// Views the next item in the queue.
	/// </summary>
	/// <returns>The next item in the queue.</returns>
	/// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
	public T Peek() => Count > 0 ? _items[_head] : throw new InvalidOperationException("Unable to peek an empty queue.");

	private void _ShiftItems()
	{
		int currentCount = Count;
		T[] newitems = new T[Capacity];
		Array.Copy(_items, _head, newitems, 0, currentCount);
		_head = 0;
		_tail = currentCount - 1;
	}
}