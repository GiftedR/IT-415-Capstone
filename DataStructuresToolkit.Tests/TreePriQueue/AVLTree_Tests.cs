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
	public void GetHeightShouldGetHeight()
	{
		AVLTree tree = new AVLTree();

		tree.Insert(10);
		
		Assert.That(tree.GetHeight(tree.Root), Is.EqualTo(2));
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

		alt.Root = alt.Insert(root_insert);
		alt.Root = alt.Insert(left_insert);
		alt.Root = alt.Insert(right_insert);

		TestContext.Out.WriteLine(alt);

		Assert.That(alt.Root?.Value, Is.EqualTo(root_value));
		Assert.That(alt.Root?.Left?.Value, Is.EqualTo(left_value));
		Assert.That(alt.Root?.Right?.Value, Is.EqualTo(right_value));
	}

	[Test]
	public void WithValidDataShouldAllowData()
	{
		AVLNode tn;

		Assert.DoesNotThrow(() =>
		{
			tn = new(30);
		});
	}

	[Test]
	public void LeftNodeShouldDefaultToNull()
	{
		AVLNode tn = new(30);

		Assert.That(tn.Left, Is.Null);
	}

	[Test]
	public void RightNodeShouldDefaultToNull()
	{
		AVLNode tn = new(30);

		Assert.That(tn.Right, Is.Null);
	}
	
	[Test]
	public void WithLeftGivenShouldAllowLeft()
	{
		AVLNode tn = new(30);

		Assert.DoesNotThrow(() =>
		{
			tn.Left = new(29);
		});
	}

	[Test]
	public void WithRightGivenShouldAllowLeft()
	{
		AVLNode tn = new(30);

		Assert.DoesNotThrow(() =>
		{
			tn.Right = new(31);
		});
	}
}