using DataStructuresToolkit.Trees;

namespace DataStructuresToolkit.Tests.Trees;

[TestFixture]
public class BST_Tests
{
	[Test]
	public void ShouldAllowRootNode()
	{
		BST bst = new();

		Assert.DoesNotThrow(() =>
		{
			bst.Root = new TreeNode(0);
		});
	}

	[Test]
	public void InsertAtRootShouldAllowInsertRootNode()
	{
		BST bst = new();

		Assert.DoesNotThrow(() =>
		{
			bst.Insert(0);
		});
	}

	[Test]
	public void InsertShouldNotAllowDuplicateValues()
	{
		BST bst = new();

		bst.Insert(0);

		Assert.Throws<InvalidOperationException>(() =>
		{
			bst.Insert(0);
		});
	}

	[Test]
	public void InsertDataShouldShowInsertedData()
	{
		BST bst = new();

		bst.Insert(50);
		bst.Insert(30);
		bst.Insert(70);
		bst.Insert(20);
		bst.Insert(40);
		bst.Insert(60);
		bst.Insert(80);

		Assert.That(bst.Root!.Data, Is.EqualTo(50));
		Assert.That(bst.Root!.Left!.Data, Is.EqualTo(30));
		Assert.That(bst.Root!.Right!.Data, Is.EqualTo(70));
		Assert.That(bst.Root!.Left!.Left!.Data, Is.EqualTo(20));
		Assert.That(bst.Root!.Left!.Right!.Data, Is.EqualTo(40));
		Assert.That(bst.Root!.Right!.Left!.Data, Is.EqualTo(60));
		Assert.That(bst.Root!.Right!.Right!.Data, Is.EqualTo(80));
	}

	[Test]
	public void ContainsWithValidShouldShowTrue()
	{
		BST bst = new();

		bst.Insert(50);
		bst.Insert(30);
		bst.Insert(70);
		bst.Insert(20);
		bst.Insert(40);
		bst.Insert(60);
		bst.Insert(80);

		Assert.That(bst.Contains(20), Is.True);
	}

	[Test]
	public void ContainsWithInvalidShouldShowFalse()
	{
		BST bst = new();

		bst.Insert(50);
		bst.Insert(30);
		bst.Insert(70);
		bst.Insert(20);
		bst.Insert(40);
		bst.Insert(60);
		bst.Insert(80);

		Assert.That(bst.Contains(69), Is.False);
	}

	[Test]
	public void InsertSkewedDataShouldShowSkewedInsertData()
	{
		BST bst = new();

		bst.Insert(10);
		bst.Insert(20);
		bst.Insert(30);
		bst.Insert(40);
		bst.Insert(50);

		Assert.That(bst.Root!.Data, Is.EqualTo(10));
		Assert.That(bst.Root!.Right!.Data, Is.EqualTo(20));
		Assert.That(bst.Root!.Right!.Right!.Data, Is.EqualTo(30));
		Assert.That(bst.Root!.Right!.Right!.Right!.Data, Is.EqualTo(40));
		Assert.That(bst.Root!.Right!.Right!.Right!.Right!.Data, Is.EqualTo(50));
	}

	[Test]
	public void TeachingTreeShouldMatchPattern()
	{
		BST teachingTree = BST.CreateTeachingTree();

		Assert.That(teachingTree.Root!.Data, Is.EqualTo(38));
		Assert.That(teachingTree.Root!.Left!.Data, Is.EqualTo(27));
		Assert.That(teachingTree.Root!.Right!.Data, Is.EqualTo(43));
		Assert.That(teachingTree.Root!.Left!.Left!.Data, Is.EqualTo(3));
		Assert.That(teachingTree.Root!.Left!.Right!.Data, Is.EqualTo(9));
	}

	[Test]
	public void GetHeightShouldGetHeight()
	{
		BST teachingTree = BST.CreateTeachingTree();
		
		Assert.That(BST.GetHeight(teachingTree), Is.EqualTo(2));
	}

	[Test]
	public void GetDepthShouldGetDepth()
	{
		BST teachingTree = BST.CreateTeachingTree();
		
		Assert.That(BST.GetDepth(teachingTree, 38), Is.EqualTo(0));
		Assert.That(BST.GetDepth(teachingTree, 27), Is.EqualTo(1));
		Assert.That(BST.GetDepth(teachingTree, 43), Is.EqualTo(1));
		Assert.That(BST.GetDepth(teachingTree, 3), Is.EqualTo(2));
		Assert.That(BST.GetDepth(teachingTree, 9), Is.EqualTo(2));
	}
}