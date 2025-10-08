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
	}
}
