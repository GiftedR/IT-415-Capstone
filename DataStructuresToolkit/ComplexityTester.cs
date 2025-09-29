namespace DataStructuresToolkit;

public class ComplexityTester
{
	/// <summary>
	/// Creates a sample for constant time complexity.
	/// </summary>
	/// <param name="arr">The array used for the scenario.</param>
	/// <returns>First item in the input array</returns>
	/// <complexity>Time: O(1), Space: O(1)</complexity>
	/// <remarks>Time: Only ever has one operation. Space: Only ever stores a reference to the first item of the array.</remarks>
	public static int RunConstantScenario(int[] arr) => arr[0];

	/// <summary>
	/// Creates a sample for linear time complexity.
	/// </summary>
	/// <param name="arr">The array used for the scenario.</param>
	/// <param name="mask">The mask used for the first array. Any value 0 or less will output 0</param>
	/// <returns>A masked version of the array.</returns>
	/// <complexity>Time: O(n), Space: O(n)</complexity>
	/// <remarks>Time: The amount of operations increases at the same rate as the amount of items within the array. Space: The Amount of items in the return array will always increase the same amount as the input array.</remarks>
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

	/// <summary>
	/// Creates a sample for quadratic time complexity.
	/// </summary>
	/// <param name="word">The letters that will have their value calculated.</param>
	/// <returns></returns>
	/// <complexity>Time: O(n²) Space: O(1)</complexity>
	/// <remarks>Time: Double Nested Loops, there adds n more operation per additional item. Space: The same amount of space is used for the results of the calculation.</remarks>
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