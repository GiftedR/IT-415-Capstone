
namespace DataStructuresToolkit.Linked;

public class DoubleNode<T> : Node<T>
{
	public DoubleNode<T>? Prev { get; set; }
	public new DoubleNode<T>? Next { get; set; }
	public DoubleNode(T startingData) : base(startingData){}
}