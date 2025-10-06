using System;
using System.Text;

namespace DataStructuresToolkit;

public class ArrayStringListHelpers
{
	public static int[] InsertIntoArray(int[] arr, int index, int value)
	{
		for (int idx = arr.Length - 1; idx > index; idx--)
		{
			arr[idx] = arr[idx - 1];
		}
		arr[index] = value;
		return arr;
	}

	public static int[] DeleteFromArray(int[] arr, int index, int value)
	{
		for (int idx = index; idx < arr.Length; idx++)
		{
			arr[idx] = arr[idx + 1];
		}
		return arr;
	}

	public static string ConcatenateNamesNaive(string[] names)
	{
		string outputstr = "";

		foreach (string name in names)
			outputstr += name + ", ";

		return outputstr;
	}

	public static string ConcatenateNamesBuilder(string[] names)
	{
		StringBuilder sb = new();
		foreach (string name in names)
			sb.Append(name + ", ");
		return sb.ToString();
	}

	public static List<int> InsertIntoList(List<int> list, int index, int value)
	{
		list.Insert(index, value);
		return list;
	}
}
