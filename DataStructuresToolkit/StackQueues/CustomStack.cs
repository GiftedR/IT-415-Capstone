namespace DataStructuresToolkit.Stackstacks;

/// <summary>
/// Custom implementation of the built in stack.
/// </summary>
/// <typeparam name="T">The type of item the stack can hold.</typeparam>
public class CustomStack<T>
{
	private T[] _items;
	private const int minimumItems = 25;
	private int _count = 0;

	/// <summary>
	/// Shows the number of items the stack can hold.
	/// </summary>
	public int Capacity { get => _items.Length; }
	/// <summary>
	/// The amount of items currently in the stack.
	/// </summary>
	public int Count { get => _count; }

	/// <summary>
	/// Creates a stack with the default capacity.
	/// </summary>
	public CustomStack() : this(25) { }

	/// <summary>
	/// Creates a stack with the specified capacity.
	/// </summary>
	/// <param name="capacity">The starting capactiy of the stack</param>
	public CustomStack(uint capacity = minimumItems) { _items = new T[capacity]; }

	/// <summary>
	/// Creates a stack with a starting set of items.
	/// </summary>
	/// <param name="items">The items that start within the stack.</param>
	public CustomStack(T[] items) { _items = items; }

	/// <summary>
	/// Adds a new item to the top of the stack.
	/// </summary>
	/// <param name="newItem">The item to be put on the stack.</param>
	public void Push(T newItem)
	{
		if (_count == _items.Length)
			Array.Resize(ref _items, _items.Length * 2);
		_items[_count] = newItem;
		_count++;
	}

	/// <summary>
	/// Removes an item from the stack.
	/// </summary>
	/// <returns>The item on the top of the stack.</returns>
	/// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
	public T Pop()
	{
		if (_count == 0)
			throw new InvalidOperationException("Unable to pop an empty stack.");
		T popitem = _items[_count - 1];
		_items[_count - 1] = default!;
		_count--;
		return popitem;
	}

	/// <summary>
	/// Views the next item on the stack.
	/// </summary>
	/// <returns>The next item on the stack.</returns>
	/// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
	public T Peek() => _count > 0 ? _items[_count - 1] : throw new InvalidOperationException("Unable to peek an empty stack.");
}