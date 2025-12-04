using DataStructuresToolkit.Linked;

namespace DataStructuresToolkit.Tests.Linked;

[TestFixture]
public class DoubleNode_Tests
{
	[Test]
	public void ShouldAllowAPrevItem()
	{
		DoubleNode<int> current = new(32);
		DoubleNode<int> prev = new (64);

		current.Prev = prev;

		Assert.That(current.Prev, Is.EqualTo(prev));
	}
}