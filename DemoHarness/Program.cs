using System.Diagnostics;
using System.Text;
using DataStructuresToolkit;
using DataStructuresToolkit.StackQueues;

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
