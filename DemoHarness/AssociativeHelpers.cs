namespace DemoHarness;

/// <summary>
/// A class for running Dictionary demonstration, and HashSet demonstration.
/// </summary>
internal class AssociativeHelpers
{
	/// <summary>
	/// Runs the demonstration.
	/// </summary>
	public static void Run()
	{
		Console.WriteLine("Starting Dictionary Demo:");
		Dictionary<string, string> dct = new();

		Console.WriteLine("Setting Alice with the phone number 555-1234...");
		dct.Add("Alice", "555-1234");
		Console.WriteLine("Setting Bob with the phone number 555-5678...");
		dct.Add("Bob", "555-5678");
		Console.WriteLine("Setting Charlie with the phone number 555-9012...");
		dct.Add("Charlie", "555-9012");

		Console.WriteLine($"David has a number is {dct.ContainsKey("David")}");

		Console.WriteLine("Starting HashSet Demo:");
		HashSet<string> hst = new();

		Console.WriteLine("Inserting Apple into the HashSet");
		hst.Add("Apple");

		Console.WriteLine("Inserting Apple into the HashSet Again");
		hst.Add("Apple");

		Console.WriteLine($"Current HashSet values:\n{DemoHelpers.StringifyArray(hst.ToArray())}");
	}
}