using DataStructuresToolkit.StackQueues;

namespace DataStructuresToolkit.Tests.StackQueues;

[TestFixture]
public class CustomQueue_Tests
{
	[Test]
	public static void EnqueueShouldIncreaseCount()
	{
		CustomQueue<int> cq = new();

		cq.Enqueue(7);

		Assert.That(
			cq.Count,
			Is.EqualTo(1)
		);
	}

	[Test]
	public static void PeekShouldShowLastEnqueuedItem()
	{
		CustomQueue<int> cq = new();

		cq.Enqueue(7);

		Assert.That(
			cq.Peek(),
			Is.EqualTo(7)
		);
	}

	[Test]
	public static void DequeueShouldReturnLastItem()
	{
		CustomQueue<int> cq = new();

		cq.Enqueue(7);

		Assert.That(
			cq.Dequeue(),
			Is.EqualTo(7)
		);
	}
	[Test]
	public static void DequeueShouldReturnDecreaseCount()
	{
		CustomQueue<int> cq = new();

		cq.Enqueue(7);
		cq.Enqueue(9);
		cq.Dequeue();

		Assert.That(
			cq.Count,
			Is.EqualTo(1)
		);
	}
	[Test]
	public static void DequeueEmptyShouldThrowInvalidOperationException()
	{
		CustomQueue<int> cq = new();

		Assert.That(
			cq.Dequeue,
			Throws.InvalidOperationException
		);
	}
	[Test]
	public static void PeekEmptyShouldThrowInvalidOperationException()
	{
		CustomQueue<int> cq = new();

		Assert.That(
			cq.Peek,
			Throws.InvalidOperationException
		);
	}

	[DatapointSource]
	public int[] TestSizes = { 100, 1000, 10000 };

	[Theory]
	public static void DataStructureShouldShowWraparoundBehavior(int count)
	{
		CustomQueue<int> cq = new((uint)count);
		int[] expected = new int[count];
		bool matches = true;

		for (int idx = 0; idx < count; idx++)
		{
			cq.Enqueue(idx);
			expected[idx] = idx;
		}

		TestContext.Out.Write($"CQ: {cq.Count} @ {cq.Capacity}; Arr: {expected.Length}");


		for (int idx = 0; idx < count; idx++)
		{
			if (expected[idx] != cq.Dequeue())
				matches = false;
		}

		Assert.That(
			matches
		);
	}
}