using DataStructuresToolkit.Linked;

namespace DataStructuresToolkit.Tests.Linked;

[TestFixture]
public class Node_Tests
{
	[TestCase(1)]
	[TestCase(0.5)]
	[TestCase(33.33f)]
	[TestCase("Gobobble")]
	[TestCase(0x2839)]
	public void ShouldAllowTemplateTypes(dynamic item)
	{
		Node<dynamic> node = new(item);

		Assert.That(node.Data, Is.EqualTo(item));
	}

	[Test]
	public void ShouldAllowANextItem()
	{
		Node<int> current = new(32);
		Node<int> next = new (64);

		current.Next = next;

		Assert.That(current.Next, Is.EqualTo(next));
	}

	[TestCase(1, "1")]
	[TestCase(0.5, "0.5")]
	[TestCase(33.33f, "33.33")]
	[TestCase("Gobobble", "Gobobble")]
	[TestCase(0x2839, "10297")]
	public void ShouldBeAbleToString(dynamic item, string expected)
	{
		Node<dynamic> node = new(item);

		Assert.That(node.Data.ToString(), Is.EqualTo(expected));
	}
}