namespace DataStructuresToolkit;

public static class SortingSearchingHelpers
{
	/// <summary>
	/// Sorts an array using the Insertion Algorithm.
	/// </summary>
	/// <param name="arr">The array to be sorted</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Best:    Ω(n)  - Best case is the array is already sorted.
	/// 		Average: Θ(n²) - Average case increases operations by the amount of items each time.
	/// 		Worst:   O(n²) - Worst case increases operations by the amount of items each time.
	/// 	</complexity>
	/// </remarks>
	public static void InsertionSort(int[] arr)
	{
		int size = arr.Length;

		for (int idx = 1; idx < size; idx++)
		{
			int value = arr[idx];
			int jdx = idx - 1;

			while (jdx >= 0 && arr[jdx] > value)
			{
				arr[jdx + 1] = arr[jdx];
				jdx = jdx - 1;
			}
			arr[jdx + 1] = value;
		}
	}

	/// <summary>
	/// Used for quick sort, swaps to array elements.
	/// </summary>
	/// <param name="arr">The array being sorted</param>
	/// <param name="i">Left swap index</param>
	/// <param name="j">Right swap index</param>
	private static void swap(int[] arr, int i, int j)
	{
		int tmp = arr[i];
		arr[i] = arr[j];
		arr[j] = tmp;
	}

	/// <summary>
	/// Creates a partition for elements to be swapped.
	/// </summary>
	/// <param name="arr">The array affected</param>
	/// <param name="low">Starting position of the pivot</param>
	/// <param name="high">Ending position of the pivot</param>
	/// <returns></returns>
	private static int part(int[] arr, int low, int high)
	{
		int pivot = arr[high];
		int i = low - 1;
		for (int j = low; j <= high - 1; j++)
		{
			if (arr[j] < pivot)
			{
				i++;
				swap(arr, i, j);
			}
		}

		swap(arr, i + 1, high);
		return i + 1;
	}

	/// <summary>
	/// Sorts the input array.
	/// </summary>
	/// <param name="arr">The array to be sorted.</param>
	/// <remarks>
	/// 	Changed to iterative over recursive due to frequent stack overflows with larger arrays.
	/// 	<complexity>
	/// 		Best:    Ω(n log n) - Best case is the array is already sorted.
	/// 		Average: Θ(n log n) - The sorting uses a splitting method, so increases only happen after a certain threshold.
	/// 		Worst:   O(n²)      - Only occurs when the array is in a specific state.
	/// 	</complexity>
	/// </remarks>
	public static void QuickSort(int[] arr)
	{
		int p, startidx = 0, endidx = arr.Length - 1, top = -1;
		int[] stack = new int[arr.Length];

		stack[++top] = startidx;
		stack[++top] = endidx;

		while (top >= 0)
		{
			endidx = stack[top--];
			startidx = stack[top--];

			p = part(arr, startidx, endidx);

			if (p - 1 > startidx)
			{
				stack[++top] = startidx;
				stack[++top] = p - 1;
			}
			if (p + 1 < endidx)
			{
				stack[++top] = p + 1;
				stack[++top] = endidx;
			}
		}
	}

	/// <summary>
	/// Searches an array for a specific value.
	/// </summary>
	/// <param name="arr">The array to be searched</param>
	/// <param name="value">The value to look for</param>
	/// <returns>The value found in the array</returns>
	/// <remarks>
	/// 	Requires the array to be sorted.
	/// 	<complexity>
	/// 		Best:    Ω(1)     - The middle item is the item being found.
	/// 		Average: Θ(log n) - The sorting happens an additional time after a certain threshold.
	/// 		Worst:   O(log n) - The item isnt found, so it goes through each layer.
	/// 	</complexity>
	/// </remarks>
	public static int BinarySearch(int[] arr, int value)
	{
		int lowidx = 0, highidx = arr.Length - 1, mid;
		while (lowidx <= highidx)
		{
			mid = lowidx + (highidx - lowidx) / 2;

			if (arr[mid] == value)
				return arr[mid];

			if (arr[mid] < value)
				lowidx = mid + 1;

			else
				highidx = mid - 1;
		}

		return -1;
	}

	/// <summary>
	/// Searches for a value in the array.
	/// </summary>
	/// <param name="arr">The array to be searched.</param>
	/// <param name="value">The value to look for.</param>
	/// <returns></returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Best:    Ω(1)     - The first item is the correct item.
	/// 		Average: Θ(n / 2) - One additional operation per item, they average out to be the middle.
	/// 		Worst:   O(n) - The item is at the end of the array.
	/// 	</complexity>
	/// </remarks>
	public static int LinearSearch(int[] arr, int value)
	{
		for (int idx = 0; idx < arr.Length; idx++)
			if (arr[idx] == value)
				return arr[idx];

		return -1;
	}
}