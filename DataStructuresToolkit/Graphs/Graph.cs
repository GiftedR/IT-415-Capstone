namespace DataStructuresToolkit.Graphs;

public class Graph<T> where T : IComparable
{
	private Dictionary<T, List<T>> p_Graph = new();

	private HashSet<T> p_SearchHistory = new();

	public void AddItem(T newitem) => AddItem(newitem, []);
	public void AddItem(T newitem, List<T> connections) => p_Graph.Add(newitem, connections);

	public bool Contains(T item) => p_Graph.ContainsKey(item);

	public List<T> DFS(T staringitem)
	{
		List<T> items = new();
		p_SearchHistory.Add(staringitem);
		foreach (T connection in p_Graph[staringitem])
		{
			if (!p_SearchHistory.Contains(connection))
				items.AddRange(DFS(connection));
		}

		return items;
	}

	public List<T> GetConnections(T item) => p_Graph[item];
}