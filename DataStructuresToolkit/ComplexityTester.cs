namespace DataStructuresToolkit;

public class ComplexityTester
{
	public static int RunConstantScenario(int[] arr) => arr[0];

	public static int[] RunLinearScenario(int[] arr, int[] mask)
	{
		int[] retarr = [];
		for (int i = 0; i < arr.Length; i++)
		{
			if (i < mask.Length && mask[i] > 0)
			{
				retarr.Append(arr[i]);
			}
			else
			{
				retarr.Append(0);
			}
		}
		return arr;
	}

	public static long RunQuadraticScenario(string word)
	{
		long retval = 0;

		foreach (char l in word)
		{
			foreach (char r in word)
			{
				retval += l + r;
			}
		}
		return retval;
	}
}