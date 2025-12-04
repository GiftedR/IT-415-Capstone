using System.Text;

/// <summary>
/// A simple implementation of a custom Hash table.
/// </summary>
public class SimpleHashTable
{
	private List<int>[] _hashBuckets;

	public SimpleHashTable(int hashSize) => _hashBuckets = new List<int>[hashSize];

	/// <summary>
	/// Clamps key down to the size of the hash.
	/// </summary>
	/// <param name="hashKey">The value to be clamped.</param>
	/// <returns>The hashkey clamped down to the size of the hash.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Only perfoms a single math operation
	/// 		Space: O(1) - Only perfoms a single math operation
	/// 	</complexity>
	/// </remarks>
	private int Hash(int hashKey) => hashKey % _hashBuckets.Length;

	/// <summary>
	/// Inserts a key into the hash
	/// </summary>
	/// <param name="hashKey">The item to be inserted</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Direct access into an array. 
	/// 		Space: O(1) - Only ever has the index.
	/// 		Uses in build methods, so time and space complexity are defferred to them.
	/// 	</complexity>
	/// </remarks>
	public void Insert(int hashKey)
	{
		int idx = Hash(hashKey);
		if (_hashBuckets[idx] == null)
			_hashBuckets[idx] = new List<int>();
		
		if (!_hashBuckets[idx].Contains(hashKey))
		{
			_hashBuckets[idx].Add(hashKey);
		}
	}

	/// <summary>
	/// Checks if a value exists in the hash
	/// </summary>
	/// <param name="hashKey">The item to be found.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Direct access into an array. 
	/// 		Space: O(1) - Only uses parameter.
	/// 		Uses in build methods, so time and space complexity are defferred to them.
	/// 	</complexity>
	/// </remarks>
	public bool Contains(int hashKey) => _hashBuckets[Hash(hashKey)] != null && _hashBuckets[Hash(hashKey)].Contains(hashKey);

	/// <summary>
	/// Formats the table to a string.
	/// </summary>
	/// <returns>Stringified Table</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(n²) - Loops through each bucket, then each item in each bucket
	/// 		Space: O(n) - Uses a new string builder per bucket, but does not depend on items in the bucket.
	/// 	</complexity>
	/// </remarks>
	public string PrintTable()
	{
		StringBuilder sb = new();

		Func<List<int>, string> lst_str = (List<int> list) =>
		{
			if (list == null)
				return "";
			StringBuilder lstsb = new();
			foreach (int item in list)
				lstsb.Append($" {item}, ");
			return lstsb.ToString();
			
		};
		for (int idx = 0; idx < _hashBuckets.Length; idx++)
			sb.Append($"[{idx}] : [{lst_str(_hashBuckets[idx])}]\n");

		return sb.ToString();
	}

	/// <summary>
	/// Uses PrintTable
	/// </summary>
	/// <returns>Stringified Hash table</returns>
	/// <remarks>See <see cref="PrintTable"/></remarks>
	public override string ToString() => PrintTable();
}