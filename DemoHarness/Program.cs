using System.Diagnostics;
using System.Text;
using DataStructuresToolkit;
using DataStructuresToolkit.Graphs;
using DataStructuresToolkit.StackQueues;

namespace DemoHarness;

internal class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("\nStarting Stack Demo\n");
		#region Stack Demo
		{
			CustomStack<string> cs = new();
			Console.WriteLine("1) Pushing First Item: This comes before.");
			cs.Push("This comes before.");
			Console.WriteLine("2) Pushing Second Item: This happens in the middle");
			cs.Push("This happens in the middle.");
			Console.WriteLine("3) Pushing Third Item: This is the last.");
			cs.Push("This is the last.");
			
			Console.WriteLine();
			Console.WriteLine($"1) Popping First Item: {cs.Pop()}");
			Console.WriteLine($"2) Popping Second Item: {cs.Pop()}");
			Console.WriteLine($"3) Popping Third Item: {cs.Pop()}");
		}
		#endregion
		Console.WriteLine("\nStarting Queue Demo\n");
		#region Queue Demo
		{
			CustomQueue<string> cq = new();
			Console.WriteLine("1) Enqueueing First Item: First is the Worst.");
			cq.Enqueue("First is the Worst.");
			Console.WriteLine("2) Enqueueing Second Item: Second is the Best.");
			cq.Enqueue("Second is the Best.");
			Console.WriteLine("3) Enqueueing Third Item: Third is the one with...");
			cq.Enqueue("Third is the one with...");

			Console.WriteLine();
			Console.WriteLine($"1) Dequeueing First Item: {cq.Dequeue()}");
			Console.WriteLine($"2) Dequeueing Second Item: {cq.Dequeue()}");
			Console.WriteLine($"3) Dequeueing Third Item: {cq.Dequeue()}");
		}
		#endregion
		
		Console.WriteLine("\nStarting Sorting Demo\n");
		Stopwatch sw = new();
		TimeSpan in100, in1000, in10000, qs100, qs1000, qs10000;

		{ // Insertion Sorting
			int[] insertarr = gen(100);
			sw.Start();
			SortingSearchingHelpers.InsertionSort(insertarr);
			sw.Stop();
			in100 = sw.Elapsed;
		}
		{ // Insertion Sorting
			int[] insertarr = gen(1000);
			sw.Restart();
			SortingSearchingHelpers.InsertionSort(insertarr);
			sw.Stop();
			in1000 = sw.Elapsed;
		}
		{ // Insertion Sorting
			int[] insertarr = gen(10000);
			sw.Restart();
			SortingSearchingHelpers.InsertionSort(insertarr);
			sw.Stop();
			in10000 = sw.Elapsed;
		}
		{ // Quick Sorting
			int[] quickarr = gen(100);
			sw.Restart();
			SortingSearchingHelpers.QuickSort(quickarr);
			sw.Stop();
			qs100 = sw.Elapsed;
		}
		{ // Quick Sorting
			int[] quickarr = gen(1000);
			sw.Restart();
			SortingSearchingHelpers.QuickSort(quickarr);
			sw.Stop();
			qs1000 = sw.Elapsed;
		}
		{ // Quick Sorting
			int[] quickarr = gen(10000);
			sw.Restart();
			SortingSearchingHelpers.QuickSort(quickarr);
			sw.Stop();
			qs10000 = sw.Elapsed;
		}
		Console.WriteLine("Results:");
		Console.WriteLine("            |-------100--------|-------1000-------|-------10000------|");
		Console.WriteLine($"Insert Sort | {in100} | {in1000} | {in10000} |");
		Console.WriteLine($"Quick Sort  | {qs100} | {qs1000} | {qs10000} |");
		
		Console.WriteLine("\nStarting Search Demo");
		TimeSpan ls100, ls1000, ls10000, bs100, bs1000, bs10000;
		Random rng = new();
		{
			int[] linearsearcharr = gen(100);
			SortingSearchingHelpers.QuickSort(linearsearcharr);
			sw.Start();
			SortingSearchingHelpers.LinearSearch(linearsearcharr, rng.Next(0, 999));
			sw.Stop();
			ls100 = sw.Elapsed;
		}
		{
			int[] linearsearcharr = gen(1000);
			SortingSearchingHelpers.QuickSort(linearsearcharr);
			sw.Restart();
			SortingSearchingHelpers.LinearSearch(linearsearcharr, rng.Next(0, 999));
			sw.Stop();
			ls1000 = sw.Elapsed;
		}
		{
			int[] linearsearcharr = gen(10000);
			SortingSearchingHelpers.QuickSort(linearsearcharr);
			sw.Restart();
			SortingSearchingHelpers.LinearSearch(linearsearcharr, rng.Next(0, 999));
			sw.Stop();
			ls10000 = sw.Elapsed;
		}
		{
			int[] binsearcharr = gen(100);
			SortingSearchingHelpers.QuickSort(binsearcharr);
			sw.Restart();
			SortingSearchingHelpers.BinarySearch(binsearcharr, rng.Next(0, 999));
			sw.Stop();
			bs100 = sw.Elapsed;
		}
		{
			int[] binsearcharr = gen(1000);
			SortingSearchingHelpers.QuickSort(binsearcharr);
			sw.Restart();
			SortingSearchingHelpers.BinarySearch(binsearcharr, rng.Next(0, 999));
			sw.Stop();
			bs1000 = sw.Elapsed;
		}
		{
			int[] binsearcharr = gen(10000);
			SortingSearchingHelpers.QuickSort(binsearcharr);
			sw.Restart();
			SortingSearchingHelpers.BinarySearch(binsearcharr, rng.Next(0, 999));
			sw.Stop();
			bs10000 = sw.Elapsed;
		}
		Console.WriteLine( "Results:");
		Console.WriteLine( "              |-------100--------|-------1000-------|-------10000------|");
		Console.WriteLine($"Linear Search | {ls100} | {ls1000} | {ls10000} |");
		Console.WriteLine($"Binary Search | {bs100} | {bs1000} | {bs10000} |");
		
		{ // Associative Helpers
			AssociativeHelpers.Run();
		}

		{ // Graph Demo
			Graph<string> gph = new Graph<string>();
			List<string> names = ["Bob!", "Kyle!", "Mickey!", "Carl!", "Anistasia!"];
			Console.WriteLine("Beginning Graph Demo");

			Console.WriteLine($"\nAdding \"{names[0]}\" with connections \"{names[1]}\", \"{names[2]}\", \"{names[3]}\", \"{names[4]}\"");
			gph.AddItem(names[0], [names[1], names[2], names[3], names[4]]);
			Console.WriteLine($"\nAdding \"{names[1]}\" with connections \"{names[0]}\", \"{names[2]}\", \"{names[3]}\", \"{names[4]}\"");
			gph.AddItem(names[1], [names[0], names[2], names[3], names[4]]);
			Console.WriteLine($"\nAdding \"{names[2]}\" with connections \"{names[0]}\", \"{names[1]}\", \"{names[3]}\", \"{names[4]}\"");
			gph.AddItem(names[2], [names[0], names[1], names[3], names[4]]);
			Console.WriteLine($"\nAdding \"{names[3]}\" with connections \"{names[0]}\", \"{names[1]}\", \"{names[2]}\", \"{names[4]}\"");
			gph.AddItem(names[3], [names[0], names[1], names[2], names[4]]);
			Console.WriteLine($"\nAdding \"{names[4]}\" with connections \"{names[0]}\", \"{names[1]}\", \"{names[2]}\", \"{names[3]}\"");
			gph.AddItem(names[4], [names[0], names[1], names[2], names[3]]);

			Console.WriteLine("\nPerforming Depth first traversal on Graph");
			
			Console.WriteLine(ArrayStringListHelpers.ConcatenateNamesBuilder(gph.DFS(names[0]).ToArray()));
		}

		{ // Hashset vs List Demo
			HashSet<string> hset = new();
			List<string> lst = new();
			int randomItemCount = 1_000_000;
			Guid itemToLookFor = Guid.NewGuid();
			Stopwatch hsetTime = new();
			Stopwatch lstTime = new();
			
			Console.WriteLine("Beginning Hashset vs List demo:");

			Console.WriteLine($"Adding {randomItemCount} string items to List and Hashset.");
			foreach(int idx in Enumerable.Range(0, randomItemCount))
			{
				Guid addedguid = Guid.NewGuid();
				if (idx == randomItemCount / 2)
				{
					Console.WriteLine($"Adding {itemToLookFor} to middle.");
					hset.Add(itemToLookFor.ToString());
					lst.Add(itemToLookFor.ToString());
				}
				else
				{
					hset.Add(addedguid.ToString());
					lst.Add(addedguid.ToString());
				}
			}
			Console.WriteLine($"Searching for { itemToLookFor }.");
			hsetTime.Start();
			hset.Contains(itemToLookFor.ToString());
			hsetTime.Stop();
			lstTime.Start();
			lst.Contains(itemToLookFor.ToString());
			lstTime.Stop();

			Console.WriteLine($"Search Times: \n\tHashSet: {hsetTime.Elapsed}\n\tList: {lstTime.Elapsed}");
		}
	}
	private static int[] gen(int size)
	{
		int[] genarr = new int[size];
		Random rng = new();
		for (int idx = 0; idx < size; idx++)
			genarr[idx] = rng.Next(0, 999);
		return genarr;
	}
}
