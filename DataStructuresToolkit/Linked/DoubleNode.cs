
namespace DataStructuresToolkit.Linked;

/// <summary>
/// An item that handles Data, pointing to the next item, and pointing to the previous item.
/// </summary>
/// <typeparam name="T">Type of the data.</typeparam>
public class DoubleNode<T> : Node<T>
{
	/// <summary>
	/// The previous item.
	/// </summary>
	public DoubleNode<T>? Prev { get; set; }
	/// <summary>
	/// The next item.
	/// </summary>
	public new DoubleNode<T>? Next { get; set; }
	public DoubleNode(T startingData) : base(startingData){}
}