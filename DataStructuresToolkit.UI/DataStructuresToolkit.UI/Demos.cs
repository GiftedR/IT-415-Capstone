using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DataStructuresToolkit.Graphs;
using DataStructuresToolkit.StackQueues;
using Eto.Forms;

namespace DataStructuresToolkit.UI
{
	public static class Demos
	{
		public static Control GetStackDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "Stack Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
				CustomStack<string> cs = new();
				output.WriteLine("1) Pushing First Item: This comes before.");
				cs.Push("This comes before.");
				output.WriteLine("2) Pushing Second Item: This happens in the middle");
				cs.Push("This happens in the middle.");
				output.WriteLine("3) Pushing Third Item: This is the last.");
				cs.Push("This is the last.");

				output.WriteLine();
				output.WriteLine($"1) Popping First Item: {cs.Pop()}");
				output.WriteLine($"2) Popping Second Item: {cs.Pop()}");
				output.WriteLine($"3) Popping Third Item: {cs.Pop()}");
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "Stack Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 3 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}
		public static Control GetQueueDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "Queue Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
				CustomQueue<string> cq = new();
				output.WriteLine("1) Enqueueing First Item: First is the Worst.");
				cq.Enqueue("First is the Worst.");
				output.WriteLine("2) Enqueueing Second Item: Second is the Best.");
				cq.Enqueue("Second is the Best.");
				output.WriteLine("3) Enqueueing Third Item: Third is the one with...");
				cq.Enqueue("Third is the one with...");

				output.WriteLine();
				output.WriteLine($"1) Dequeueing First Item: {cq.Dequeue()}");
				output.WriteLine($"2) Dequeueing Second Item: {cq.Dequeue()}");
				output.WriteLine($"3) Dequeueing Third Item: {cq.Dequeue()}");
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "Queue Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 3 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}
		public static Control GetSortDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "Sorting Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
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
				output.WriteLine("Results:");
				output.WriteLine("            |-------100--------|-------1000-------|-------10000------|");
				output.WriteLine($"Insert Sort | {in100} | {in1000} | {in10000} |");
				output.WriteLine($"Quick Sort  | {qs100} | {qs1000} | {qs10000} |");
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "Sorting Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 5 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}
		public static Control GetSearchDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "Search Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
				Stopwatch sw = new();
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
				output.WriteLine( "Results:");
				output.WriteLine( "              |-------100--------|-------1000-------|-------10000------|");
				output.WriteLine($"Linear Search | {ls100} | {ls1000} | {ls10000} |");
				output.WriteLine($"Binary Search | {bs100} | {bs1000} | {bs10000} |");
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "Search Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 5 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}
		public static Control GetDictionaryDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "Dictionary Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
				Dictionary<string, string> dct = new();

				output.WriteLine("Setting Alice with the phone number 555-1234...");
				dct.Add("Alice", "555-1234");
				output.WriteLine("Setting Bob with the phone number 555-5678...");
				dct.Add("Bob", "555-5678");
				output.WriteLine("Setting Charlie with the phone number 555-9012...");
				dct.Add("Charlie", "555-9012");

				output.WriteLine($"David has a number is {dct.ContainsKey("David")}");
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "Dictionary Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 8 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}
		public static Control GetHashSetDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "HashSet Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
				HashSet<string> hst = new();

				output.WriteLine("Inserting Apple into the HashSet");
				hst.Add("Apple");

				output.WriteLine("Inserting Apple into the HashSet Again");
				hst.Add("Apple");

				output.WriteLine($"Current HashSet values:\n{StringifyArray(hst.ToArray())}");
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "HashSet Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 8 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}
		public static Control GetGraphDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "Graph Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
				Graph<string> gph = new Graph<string>();
				List<string> names = ["Bob!", "Kyle!", "Mickey!", "Carl!", "Anistasia!"];
				output.WriteLine("Beginning Graph Demo");

				output.WriteLine($"\nAdding \"{names[0]}\" with connections \"{names[1]}\", \"{names[2]}\", \"{names[3]}\", \"{names[4]}\"");
				gph.AddItem(names[0], [names[1], names[2], names[3], names[4]]);
				output.WriteLine($"\nAdding \"{names[1]}\" with connections \"{names[0]}\", \"{names[2]}\", \"{names[3]}\", \"{names[4]}\"");
				gph.AddItem(names[1], [names[0], names[2], names[3], names[4]]);
				output.WriteLine($"\nAdding \"{names[2]}\" with connections \"{names[0]}\", \"{names[1]}\", \"{names[3]}\", \"{names[4]}\"");
				gph.AddItem(names[2], [names[0], names[1], names[3], names[4]]);
				output.WriteLine($"\nAdding \"{names[3]}\" with connections \"{names[0]}\", \"{names[1]}\", \"{names[2]}\", \"{names[4]}\"");
				gph.AddItem(names[3], [names[0], names[1], names[2], names[4]]);
				output.WriteLine($"\nAdding \"{names[4]}\" with connections \"{names[0]}\", \"{names[1]}\", \"{names[2]}\", \"{names[3]}\"");
				gph.AddItem(names[4], [names[0], names[1], names[2], names[3]]);

				output.WriteLine("\nPerforming Depth first traversal on Graph");

				output.WriteLine(ArrayStringListHelpers.ConcatenateNamesBuilder(gph.DFS(names[0]).ToArray()));
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "Graph Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 10 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}
		public static Control GetHashSetListDemo()
		{
			RichTextArea output = new RichTextArea
			{
				Enabled = false,
				Text = "HashSet v. List Demo Output..."
			};

			Command demoCommand = new();
			demoCommand.Executed += (sender, e) =>
			{
				output.Text = "";
				output.Style = "f-white h5";
				HashSet<string> hset = new();
				List<string> lst = new();
				int randomItemCount = 1_000_000;
				Guid itemToLookFor = Guid.NewGuid();
				Stopwatch hsetTime = new();
				Stopwatch lstTime = new();

				output.WriteLine("Beginning Hashset vs List demo:");

				output.WriteLine($"Adding {randomItemCount} string items to List and Hashset.");
				foreach(int idx in Enumerable.Range(0, randomItemCount))
				{
					Guid addedguid = Guid.NewGuid();
					if (idx == randomItemCount / 2)
					{
						output.WriteLine($"Adding {itemToLookFor} to middle.");
						hset.Add(itemToLookFor.ToString());
						lst.Add(itemToLookFor.ToString());
					}
					else
					{
						hset.Add(addedguid.ToString());
						lst.Add(addedguid.ToString());
					}
				}
				output.WriteLine($"Searching for { itemToLookFor }.");
				hsetTime.Start();
				hset.Contains(itemToLookFor.ToString());
				hsetTime.Stop();
				lstTime.Start();
				lst.Contains(itemToLookFor.ToString());
				lstTime.Stop();

				output.WriteLine($"Search Times: \n\tHashSet: {hsetTime.Elapsed}\n\tList: {lstTime.Elapsed}");
			};

			return new TableLayout
			{
				Width = 1260,
				Padding = 10,
				Rows =
				{
					new TableRow(
						new Label{Style = "h1 center", Text = "HashSet v. List Demo"}
					),
					new TableRow(
						new TableLayout
						{
							Rows =
							{
								new TableRow
								(
									new Label{Style = "h3 center", Text = "Week 10 Demo", Width = 1100},
									new Button() {Text = "▶\tRun Demo", Command = demoCommand}
								)
							}
						}
					),
					new TableRow(
						output
					)
				}
			};
		}

		private static int[] gen(int size)
		{
			int[] genarr = new int[size];
			Random rng = new();
			for (int idx = 0; idx < size; idx++)
				genarr[idx] = rng.Next(0, 999);
			return genarr;
		}

		public static string StringifyArray(dynamic[] arr)
		{
			if (arr == null)
				return "";
			StringBuilder arrsb = new("[");
			foreach (var item in arr)
				arrsb.Append($" {item}, ");
			arrsb.Remove(arrsb.Length - 2, 2);
			arrsb.Append(" ]");
			return arrsb.ToString();
		}
	}
}