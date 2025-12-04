namespace DataStructuresToolkit.Graphs;

/// <summary>
/// Creates a graph
/// </summary>
/// <typeparam name="T">Type of graph, must be comparable</typeparam>
public class Graph<T> where T : IComparable
{
	private Dictionary<T, List<T>> p_Graph = new();

	private HashSet<T> p_SearchHistory = new();

	/// <summary>
	/// Adds an item to the graph with no connections
	/// </summary>
	/// <param name="newitem">The item to add.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Just calls other AddItem
	/// 		Space: O(1) - Uses No Variables
	/// 	</complexity>
	/// </remarks>
	public void AddItem(T newitem) => AddItem(newitem, []);
	/// <summary>
	/// Adds an item to the graph with connections.
	/// </summary>
	/// <param name="newitem">The item to add.</param>
	/// <param name="connections">The connections of the item.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Calls dictionary's add method
	/// 		Space: O(1) - Doesnt create any variables
	/// 	</complexity>
	/// </remarks>
	public void AddItem(T newitem, List<T> connections) => p_Graph.Add(newitem, connections);

	/// <summary>
	/// Check if the item is in the graph.
	/// </summary>
	/// <param name="item">The item to look for.</param>
	/// <returns>Weither the item is in the graph.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Calls dictionary's ContainsKey method
	/// 		Space: O(1) - Doesnt create any variables
	/// 	</complexity>
	/// </remarks>
	public bool Contains(T item) => p_Graph.ContainsKey(item);

	/// <summary>
	/// Performs a depth first traversal
	/// </summary>
	/// <param name="staringitem">The item to start with.</param>
	/// <returns>A list of items in depth first approach.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(n) - Loops through each connecting node.
	/// 		Space: O(n) - List expands to meet the amount of items in the graph
	/// 	</complexity>
	/// </remarks>
	public List<T> DFS(T staringitem)
	{
		List<T> items = new();
		p_SearchHistory.Add(staringitem);
		items.Add(staringitem);
		foreach (T connection in p_Graph[staringitem])
		{
			if (!p_SearchHistory.Contains(connection))
				items.AddRange(DFS(connection));
		}

		return items;
	}

	/// <summary>
	/// Gets the connections of a node.
	/// </summary>
	/// <param name="item">The item to get the connections.</param>
	/// <returns>The listed connections.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Single indexed operation
	/// 		Space: O(1) - No variables used
	/// 	</complexity>
	/// </remarks>
	public List<T> GetConnections(T item) => p_Graph[item];
}