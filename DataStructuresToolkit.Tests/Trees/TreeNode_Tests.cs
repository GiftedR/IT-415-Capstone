using DataStructuresToolkit.Trees;

namespace DataStructuresToolkit.Tests.Trees;

[TestFixture]
public class TreeNode_Tests
{
	[Test]
	public void WithValidDataShouldAllowData()
	{
		TreeNode tn;

		Assert.DoesNotThrow(() =>
		{
			tn = new(30);
		});
	}

	[Test]
	public void LeftNodeShouldDefaultToNull()
	{
		TreeNode tn = new(30);

		Assert.That(tn.Left, Is.Null);
	}

	[Test]
	public void RightNodeShouldDefaultToNull()
	{
		TreeNode tn = new(30);

		Assert.That(tn.Right, Is.Null);
	}
	
	[Test]
	public void WithLeftGivenShouldAllowLeft()
	{
		TreeNode tn = new(30);

		Assert.DoesNotThrow(() =>
		{
			tn.Left = new(29);
		});
	}

	[Test]
	public void WithRightGivenShouldAllowLeft()
	{
		TreeNode tn = new(30);

		Assert.DoesNotThrow(() =>
		{
			tn.Right = new(31);
		});
	}

	[Test]
	public void TeachingTreeShouldMatchPattern()
	{
		TreeNode teachingTree = TreeNode.CreateTeachingTree();

		Assert.That(teachingTree.Data, Is.EqualTo(38));
		Assert.That(teachingTree.Left!.Data, Is.EqualTo(27));
		Assert.That(teachingTree.Right!.Data, Is.EqualTo(43));
		Assert.That(teachingTree.Left!.Left!.Data, Is.EqualTo(3));
		Assert.That(teachingTree.Left!.Right!.Data, Is.EqualTo(9));
	}

	[Test]
	public void WithTeachingTreeInOrderShouldMatchInOrderPattern()
	{
		TreeNode teachingTree = TreeNode.CreateTeachingTree();
		int[] expectedTree = [3, 27, 9, 38, 43];
		List<TreeNode> inOrderTree = new();

		TreeNode.InOrder(teachingTree, ref inOrderTree);

		Assert.That(inOrderTree[0].Data, Is.EqualTo(expectedTree[0]));
		Assert.That(inOrderTree[1].Data, Is.EqualTo(expectedTree[1]));
		Assert.That(inOrderTree[2].Data, Is.EqualTo(expectedTree[2]));
		Assert.That(inOrderTree[3].Data, Is.EqualTo(expectedTree[3]));
		Assert.That(inOrderTree[4].Data, Is.EqualTo(expectedTree[4]));
	}

	[Test]
	public void WithTeachingTreeInPreOrderShouldMatchInPreOrderPattern()
	{
		TreeNode teachingTree = TreeNode.CreateTeachingTree();
		int[] expectedTree = [38, 27, 3, 9, 43];
		List<TreeNode> preOrderTree = new();

		TreeNode.PreOrder(teachingTree, ref preOrderTree);

		Assert.That(preOrderTree[0].Data, Is.EqualTo(expectedTree[0]));
		Assert.That(preOrderTree[1].Data, Is.EqualTo(expectedTree[1]));
		Assert.That(preOrderTree[2].Data, Is.EqualTo(expectedTree[2]));
		Assert.That(preOrderTree[3].Data, Is.EqualTo(expectedTree[3]));
		Assert.That(preOrderTree[4].Data, Is.EqualTo(expectedTree[4]));
	}

	[Test]
	public void WithTeachingTreeInPostOrderShouldMatchInPostOrderPattern()
	{
		TreeNode teachingTree = TreeNode.CreateTeachingTree();
		int[] expectedTree = [3, 9, 27, 43, 38];
		List<TreeNode> postOrderTree = new();

		TreeNode.PostOrder(teachingTree, ref postOrderTree);

		Assert.That(postOrderTree[0].Data, Is.EqualTo(expectedTree[0]));
		Assert.That(postOrderTree[1].Data, Is.EqualTo(expectedTree[1]));
		Assert.That(postOrderTree[2].Data, Is.EqualTo(expectedTree[2]));
		Assert.That(postOrderTree[3].Data, Is.EqualTo(expectedTree[3]));
		Assert.That(postOrderTree[4].Data, Is.EqualTo(expectedTree[4]));
	}

	[Test]
	public void GetHeightShouldGetHeight()
	{
		TreeNode teachingTree = TreeNode.CreateTeachingTree();
		
		Assert.That(TreeNode.GetHeight(teachingTree), Is.EqualTo(2));
	}

	[Test]
	public void GetDepthShouldGetDepth()
	{
		TreeNode teachingTree = TreeNode.CreateTeachingTree();
		
		Assert.That(TreeNode.GetDepth(teachingTree, 38), Is.EqualTo(0));
		Assert.That(TreeNode.GetDepth(teachingTree, 27), Is.EqualTo(1));
		Assert.That(TreeNode.GetDepth(teachingTree, 43), Is.EqualTo(1));
		Assert.That(TreeNode.GetDepth(teachingTree, 3), Is.EqualTo(2));
		Assert.That(TreeNode.GetDepth(teachingTree, 9), Is.EqualTo(2));
	}
}