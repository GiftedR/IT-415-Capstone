
namespace DataStructuresToolkit.Linked;

public class Node<T>
{
	public Node<T>? Next { get; set; }
	public T Data { get; set; }
	public Node(T startingData) => Data = startingData;
	public override string ToString()
	{
		if (Data == null) return "NULL";
		else return Data.ToString()!;
	}
}