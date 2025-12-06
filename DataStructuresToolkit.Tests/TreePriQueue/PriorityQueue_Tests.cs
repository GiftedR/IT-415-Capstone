using DataStructuresToolkit.TreePriQUeue;

namespace DataStructuresToolkit.Tests.TreePriQueue;

[TestFixture]
public class PriorityQueue_Tests
{
	[Test]
	public void EnqueueShouldAddValue()
	{
		IntPriorityQueue ipq = new();

		ipq.Enqueue(3);

		Assert.That(ipq.Dequeue(), Is.EqualTo(3));
	}
	
	private static readonly object[] _sourceLists =
	{
		new object[] { new List<int>{5, 2, 8}, 2 },
		new object[] { new List<int>{6372, 98, 127389}, 98 }
	};
	
	[TestCaseSource(nameof(_sourceLists))]
	public void EnqueueingAscendingValuesShouldSwapOrder(List<int> queueValues, int minimumValue)
	{
		IntPriorityQueue ipq = new();

		foreach (int item in queueValues)
			ipq.Enqueue(item);

		Assert.That(ipq.Dequeue(), Is.EqualTo(minimumValue));
	}
}