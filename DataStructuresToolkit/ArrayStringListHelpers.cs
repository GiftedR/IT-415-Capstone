using System;
using System.Text;

namespace DataStructuresToolkit;

public class ArrayStringListHelpers
{
	/// <summary>
	/// Inserts into an array and shifts items to the right.
	/// </summary>
	/// <param name="arr">The array to be shifted</param>
	/// <param name="index">The position for the new value.</param>
	/// <param name="value">The value to be inserted at the position.</param>
	/// <returns>An unresized array with the new value.</returns>
	/// <remarks>Time: O(n) - Worst case is beginning and the entire array has to be shifted.</remarks>
	public static int[] InsertIntoArray(int[] arr, int index, int value)
	{
		for (int idx = arr.Length - 1; idx > index; idx--)
		{
			arr[idx] = arr[idx - 1];
		}
		arr[index] = value;
		return arr;
	}

	/// <summary>
	/// Delets from an array and shifts items to the left.
	/// </summary>
	/// <param name="arr">The array to be shifted</param>
	/// <param name="index">The position for the deleted value.</param>
	/// <returns>An unresized array with the value deleted and duplicate data at the end.</returns>
	/// <remarks>Time: O(n) - Worst case is beginning and the entire array has to be shifted.</remarks>
	public static int[] DeleteFromArray(int[] arr, int index)
	{
		for (int idx = index; idx < arr.Length - 1; idx++)
		{
			arr[idx] = arr[idx + 1];
		}
		return arr;
	}

	/// <summary>
	/// Creates one long string from the array of names.
	/// </summary>
	/// <param name="names">The names to be concatenated</param>
	/// <returns>Long string of names, seperated by a comma.</returns>
	/// <remarks>Time: O(n²) - For each iteration of the loop, it has to copy characters from both arrays into the new buffer.</remarks>
	public static string ConcatenateNamesNaive(string[] names)
	{
		string outputstr = "";

		foreach (string name in names)
			outputstr += name + ", ";

		return outputstr;
	}

	/// <summary>
	/// Creates one long string from the array of names.
	/// </summary>
	/// <param name="names">The names to be concatenated</param>
	/// <returns>Long string of names, seperated by a comma.</returns>
	/// <remarks>Time: O(n) - Uses a chunking system that expands when needed. https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Text/StringBuilder.cs</remarks>
	public static string ConcatenateNamesBuilder(string[] names)
	{
		StringBuilder sb = new();
		foreach (string name in names)
			sb.Append(name + ", ");
		return sb.ToString();
	}

	/// <summary>
	/// Inserts a value into the list.
	/// </summary>
	/// <param name="list">The list to be modified.</param>
	/// <param name="index">The position of the item to be inserted.</param>
	/// <param name="value">The item that will be inserted into position.</param>
	/// <returns>The list with the new value inserted.</returns>
	/// <remarks>Time: O(n) - Grows by specific amounts as needed and shifts values into the new sections.</remarks>
	public static List<int> InsertIntoList(List<int> list, int index, int value)
	{
		list.Insert(index, value);
		return list;
	}
}
