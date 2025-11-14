using DataStructuresToolkit.TreePriQUeue;

namespace DataStructuresToolkit.Tests.TreePriQueue;

public class AVLTree_Tests
{
	[Test]
	public void InsertIntoEmptyShouldSetRoot()
	{
		AVLTree alt = new();
		int root_value = 1;

		TestContext.Out.WriteLine(alt);

		alt.Insert(root_value);

		TestContext.Out.WriteLine(alt);

		Assert.That(alt.Root != null, Is.True);
		Assert.That(alt.Root!.Value, Is.EqualTo(root_value));
	}

	[Test]
	public void InsertDuplicateShouldThrowException()
	{
		AVLTree alt = new();
		int root_value = 1;
		int left_value = 1;

		TestContext.Out.WriteLine(alt);
		
		alt.Insert(root_value);

		Assert.Throws<InvalidOperationException>(() => {alt.Insert(left_value);});
	}

	[Test]
	public void InsertSkewedToRightShouldRotateLeft()
	{
		AVLTree alt = new();
		int root_insert = 100;
		int left_insert = 200;
		int right_insert = 300;
		
		int root_value = left_insert;
		int left_value = root_insert;
		int right_value = right_insert;

		TestContext.Out.WriteLine(alt);

		alt.Insert(root_insert);
		alt.Insert(left_insert);
		alt.Insert(right_insert);

		alt.TryBalance();

		TestContext.Out.WriteLine(alt);

		Assert.That(alt.Root?.Value, Is.EqualTo(root_value));
		Assert.That(alt.Root?.Left?.Value, Is.EqualTo(left_value));
		Assert.That(alt.Root?.Right?.Value, Is.EqualTo(right_value));
	}

	[Test]
	public void InsertBalancedSkewedToRightShouldRotateLeft()
	{
		AVLTree alt = new();
		int root_insert = 100;
		int left_insert = 200;
		int right_insert = 300;
		
		int root_value = left_insert;
		int left_value = root_insert;
		int right_value = right_insert;

		TestContext.Out.WriteLine(alt);

		alt.InsertBalanced(root_insert);
		alt.InsertBalanced(left_insert);
		alt.InsertBalanced(right_insert);

		TestContext.Out.WriteLine(alt);

		Assert.That(alt.Root?.Value, Is.EqualTo(root_value));
		Assert.That(alt.Root?.Left?.Value, Is.EqualTo(left_value));
		Assert.That(alt.Root?.Right?.Value, Is.EqualTo(right_value));
	}
}