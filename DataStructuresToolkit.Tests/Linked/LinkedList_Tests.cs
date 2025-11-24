using DSTL = DataStructuresToolkit.Linked;

namespace DataStructuresToolkit.Tests.Linked;

[TestFixture]
public class LinkedList_Tests
{
	[Test]
	public void ShouldAllowAHead()
	{
		DSTL.LinkedList<int> ll = new();

		ll.AddFirst(32);

		Assert.That(ll.Head != null);
	}
	
	[Test]
	public void ShouldHaveAHeadValue()
	{
		DSTL.LinkedList<int> ll = new();
		int headVal = 69;

		ll.AddFirst(headVal);

		Assert.That(ll.Head!.Data, Is.EqualTo(headVal));
	}

	[Test]
	public void ShouldAllowMultipleValues()
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84;

		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		Assert.That(ll.Head!.Data, Is.EqualTo(one));
		Assert.That(ll.Head!.Next!.Data, Is.EqualTo(two));
		Assert.That(ll.Head!.Next!.Next!.Data, Is.EqualTo(three));
	}

	[TestCase(1)]
	[TestCase(2)]
	[TestCase(3)]
	[TestCase(4)]
	[TestCase(5)]
	[TestCase(6)]
	[TestCase(7)]
	[TestCase(8)]
	[TestCase(9)]
	public void MultipleValuesShouldIncreaseCount(int itemCount)
	{
		DSTL.LinkedList<int> ll = new();
		int item = 69;

		for (int idx = 0; idx < itemCount; idx++)
			ll.AddFirst(item);

		Assert.That(ll.Count, Is.EqualTo(itemCount));
	}

	[Test]
	public void ShouldFindUsingGetNode()
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84, four = 99, five = 103;

		ll.AddFirst(five);
		ll.AddFirst(four);
		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		Assert.That(ll.GetNode(ll.Head!.Next!.Next!), Is.EqualTo(ll.Head!.Next!.Next!));
	}


	[Test]
	public void GivenOffsetShouldFindUsingGetNode()
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84, four = 99, five = 103;

		ll.AddFirst(five);
		ll.AddFirst(four);
		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		Assert.That(ll.GetNode(ll.Head!.Next!.Next!, 1), Is.EqualTo(ll.Head!.Next!));
	}

	[Test]
	public void ShouldFindUsingGetValue()
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84, four = 99, five = 103;

		ll.AddFirst(five);
		ll.AddFirst(four);
		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		Assert.That(ll.GetValue(four), Is.EqualTo(ll.Head!.Next!.Next!.Next!.Data));
	}

	[Test]
	public void GivenHeadShouldRemoveHeadNode()
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84, four = 99, five = 103;

		ll.AddFirst(five);
		ll.AddFirst(four);
		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		ll.Remove(ll.Head!);

		Assert.That(ll.Head!.Data, Is.EqualTo(two));
	}

	[Test]
	public void GivenMiddleNodeShouldRemoveMiddleNode()
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84, four = 99, five = 103;

		ll.AddFirst(five);
		ll.AddFirst(four);
		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		ll.Remove(ll.Head!.Next!.Next!);

		Assert.That(ll.Head!.Data, Is.EqualTo(one));
		Assert.That(ll.Head!.Next!.Data, Is.EqualTo(two));
		Assert.That(ll.Head!.Next!.Next!.Data, Is.EqualTo(four));
		Assert.That(ll.Head!.Next!.Next!.Next!.Data, Is.EqualTo(five));
	}

	[Test]
	public void ShouldReadForward()
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84, four = 99, five = 103;

		ll.AddFirst(five);
		ll.AddFirst(four);
		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		Assert.That(ll.ReadForward(), Is.EqualTo("[HEAD]:69 -> 78 -> 84 -> 99 -> 103 -> <END>"));
	}

	[TestCase(" -> ")]
	[TestCase(" , ")]
	[TestCase(" -- ")]
	[TestCase(" => ")]
	[TestCase(" then ")]
	public void GivenSeparatorShouldReadForwardWithSeparator(string separator)
	{
		DSTL.LinkedList<int> ll = new();
		int one = 69, two = 78, three = 84, four = 99, five = 103;

		ll.AddFirst(five);
		ll.AddFirst(four);
		ll.AddFirst(three);
		ll.AddFirst(two);
		ll.AddFirst(one);

		Assert.That(ll.ReadForward(separator), Is.EqualTo($"[HEAD]:69{separator}78{separator}84{separator}99{separator}103{separator}<END>"));
	}

	[Test]
	public void GivenSimilarValuesShouldCompareToDefaultLinkedList()
	{
		DSTL.LinkedList<int> dll = new();
		LinkedList<int> pll = new();

		dll.AddFirst(0);
		pll.AddFirst(0);
		dll.AddFirst(1);
		pll.AddFirst(1);
		dll.AddFirst(2);
		pll.AddFirst(2);
		dll.AddFirst(3);
		pll.AddFirst(3);
		dll.AddFirst(4);
		pll.AddFirst(4);

		Assert.That(dll.Head!.Data, Is.EqualTo(pll.First!.Value));
		Assert.That(dll.Head!.Next!.Data, Is.EqualTo(pll.First!.Next!.Value));
		Assert.That(dll.Head!.Next!.Next!.Data, Is.EqualTo(pll.First!.Next!.Next!.Value));
		Assert.That(dll.Head!.Next!.Next!.Next!.Data, Is.EqualTo(pll.First!.Next!.Next!.Next!.Value));
		Assert.That(dll.Head!.Next!.Next!.Next!.Next!.Data, Is.EqualTo(pll.First!.Next!.Next!.Next!.Next!.Value));
	}
	
}