using System.Net.Http.Headers;
using System.Text;

namespace DataStructuresToolkit;

public static class RecursiveHelper
{
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

	public static bool IsPalindrome(string word, int index = 0)
	{
		if (string.IsNullOrEmpty(word))
			return true;
		if (index == (int)Math.Ceiling(word.Length / 2.0))
			return word[index] == word[^(index + 1)];

		return word[index] == word[^(index + 1)] && IsPalindrome(word, index + 1);
	}

	public static int ArrAdder(int[] arr, int idx = 0)
	{
		if (arr == null || arr.Length == 0 || idx >= arr.Length)
			return 0;
		return arr[idx] + ArrAdder(arr, idx + 1);
	}
}