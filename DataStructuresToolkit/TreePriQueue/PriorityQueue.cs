namespace DataStructuresToolkit.TreePriQUeue;

public class PriorityQueue<T>
{
	private List<PQItem<T>> _pqItems = new();
}

internal struct PQItem<T>
{
	#pragma warning disable CS0649
	public int priority;
	public T item;
	#pragma warning restore CS0649
}