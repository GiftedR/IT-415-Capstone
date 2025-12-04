
namespace DataStructuresToolkit.Linked;

/// <summary>
/// An item that handles Data and pointing to the next item.
/// </summary>
/// <typeparam name="T">Type of the data.</typeparam>
public class Node<T>
{
	/// <summary>
	/// The next item.
	/// </summary>
	public Node<T>? Next { get; set; }
	/// <summary>
	/// The data within the node.
	/// </summary>
	public T Data { get; set; }
	public Node(T startingData) => Data = startingData;
	public override string ToString()
	{
		if (Data == null) return "NULL";
		else return Data.ToString()!;
	}
}