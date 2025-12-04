using DataStructuresToolkit.StackQueues;

namespace DataStructuresToolkit.Tests.StackQueues;

[TestFixture]
public class CustomStack_Tests
{
	[Test]
	public static void PushShouldIncreaseCount()
	{
		CustomStack<int> cs = new();

		cs.Push(7);

		Assert.That(
			cs.Count,
			Is.EqualTo(1)
		);
	}

	[Test]
	public static void PeekShouldShowLastPushedItem()
	{
		CustomStack<int> cs = new();

		cs.Push(7);

		Assert.That(
			cs.Peek(),
			Is.EqualTo(7)
		);
	}

	[Test]
	public static void PopShouldReturnLastItem()
	{
		CustomStack<int> cs = new();

		cs.Push(7);

		Assert.That(
			cs.Pop(),
			Is.EqualTo(7)
		);
	}
	[Test]
	public static void PopShouldReturnDecreaseCount()
	{
		CustomStack<int> cs = new();

		cs.Push(7);
		cs.Push(9);
		cs.Pop();

		Assert.That(
			cs.Count,
			Is.EqualTo(1)
		);
	}
	[Test]
	public static void PopEmptyShouldThrowInvalidOperationException()
	{
		CustomStack<int> cs = new();

		Assert.That(
			cs.Pop,
			Throws.InvalidOperationException
		);
	}
	[Test]
	public static void PeekEmptyShouldThrowInvalidOperationException()
	{
		CustomStack<int> cs = new();

		Assert.That(
			cs.Peek,
			Throws.InvalidOperationException
		);
	}
}