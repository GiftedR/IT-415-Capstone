using System.Net.Http.Headers;
using System.Text;

namespace DataStructuresToolkit;

public static class RecursiveHelper
{
	/// <summary>
	/// Gets all folders recursively.
	/// </summary>
	/// <param name="startingDir">The starting Location of the recursion.</param>
	/// <returns>A string containing all the folders.</returns>
	/// <remarks>Try Catch is used in case of broken dirs or links on linux.
	/// Time: O(n) - Adds one operation per new directory
	/// Base: Base case is empty directory
	/// Recursive: Calls self for each child dir.
	/// </remarks>
	public static string GetFolders(string startingDir = "")
	{
		if (string.IsNullOrEmpty(startingDir))
			startingDir = Directory.GetCurrentDirectory();

		string[] dirs = [];
		try
		{
			dirs = Directory.GetDirectories(startingDir);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
		if (dirs.Length == 0)
			return startingDir.Substring(Directory.GetCurrentDirectory().Length) + "\n";
		StringBuilder sb = new();

		for (int idx = 0; idx < dirs.Length; idx++)
		{
			sb.Append(GetFolders(dirs[idx]));
		}
		return sb.ToString();
	}

	/// <summary>
	/// Checks if the word is a panindrome.
	/// </summary>
	/// <param name="word">The word to be checked.</param>
	/// <param name="index">The starting position of the checker.</param>
	/// <returns>Wheither or not the word is a palindrome.</returns>
	/// <remarks>
	/// Time: O(n/2) - Adds one operation per 2 characters added.
	/// Base: Base case is the same letter.
	/// Recursive: Calls self without a character on each end.
	/// </remarks>
	public static bool IsPalindrome(string word, int index = 0)
	{
		if (string.IsNullOrEmpty(word))
			return true;
		if (index == (int)Math.Ceiling(word.Length / 2.0))
			return word[index] == word[^(index + 1)];

		return word[index] == word[^(index + 1)] && IsPalindrome(word, index + 1);
	}

	/// <summary>
	/// Adds the items of the array.
	/// </summary>
	/// <param name="arr">The array to be processed.</param>
	/// <param name="idx">The starting position of the adding.</param>
	/// <returns>The total value of the array.</returns>
	/// <remarks>
	/// Time: O(n) - Adds one operation per new item added.
	/// Base: Base case is no items.
	/// Recursive: Calls self for each item in an array.
	/// </remarks>
	public static int ArrAdder(int[] arr, int idx = 0)
	{
		if (arr == null || arr.Length == 0 || idx >= arr.Length)
			return 0;
		return arr[idx] + ArrAdder(arr, idx + 1);
	}
}