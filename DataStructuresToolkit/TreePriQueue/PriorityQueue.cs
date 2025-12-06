namespace DataStructuresToolkit.TreePriQUeue;

/// <summary>
/// Custom priority queue with ints. Had to be renamed to not conflict with native type.
/// </summary>
public class IntPriorityQueue
{
	/// <summary>
	/// Internal heap storage.
	/// </summary>
	private List<int> pq_Heap = new();

	/// <summary>
	/// Adds an item to the queue.
	/// </summary>
	/// <param name="newValue">The item to add, also acts as a priority.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(log n) - Splits heap traversals for optimization.
	/// 		Space: O(1) - Only creates an index regardless of heap size.
	/// 	</complexity>
	/// </remarks>
	public void Enqueue(int newValue)
	{
		pq_Heap.Add(newValue);
		int idx = pq_Heap.Count - 1;
		while (idx > 0 && pq_Heap[(idx-1)/2] > pq_Heap[idx])
		{
			(pq_Heap[idx], pq_Heap[(idx-1)/2]) = (pq_Heap[(idx-1)/2], pq_Heap[idx]); // Index Swapping
			idx = (idx-1)/2;
		}
	}
	
	/// <summary>
	/// Removes the item from the top of the queue.
	/// </summary>
	/// <returns>The highest priority item.</returns>
	/// <exception cref="InvalidOperationException">Thrown if the heap is empty when attempting to dequeue.</exception>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Grabs the first item directly.
	/// 		Space: O(1) - Only holds reference to the front of the queue.
	/// 	</complexity>
	/// </remarks>
	public int Dequeue()
	{
		if (pq_Heap.Count == 0)
			throw new InvalidOperationException("Heap cannot be empty.");
		int root = pq_Heap[0];
		pq_Heap[0] = pq_Heap[^1];
		pq_Heap.RemoveAt(pq_Heap.Count - 1);
		Heapify(0);
		return root;
	}

	/// <summary>
	/// Sorts the heap to fit the expected format.
	/// </summary>
	/// <param name="index">The lower bounds to index from/</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(log n) - Performs a type of sorting.
	/// 		Space: O(1) - Only holds 3 indexes regardless of size.
	/// 	</complexity>
	/// </remarks>
	private void Heapify(int index)
	{
		int smallest = index;
		int left_index = 2 * index + 1;
		int right_index = 2 * index + 2;

		if (left_index < pq_Heap.Count && pq_Heap[left_index] < pq_Heap[smallest])
			smallest = left_index;
		if (right_index < pq_Heap.Count && pq_Heap[right_index] < pq_Heap[smallest])
			smallest = right_index;

		if (smallest != index) {
			(pq_Heap[index], pq_Heap[smallest]) = (pq_Heap[smallest], pq_Heap[index]);
			Heapify(smallest);
		}
	}
}