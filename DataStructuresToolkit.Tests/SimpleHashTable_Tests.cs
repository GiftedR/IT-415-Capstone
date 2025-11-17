namespace DataStructuresToolkit.Tests;

[TestFixture]
public class SimpleHashTable_Tests
{
	[Test]
	public void ShouldAllowMultipleItemsInTheSameBucket()
	{
		SimpleHashTable sht = new(5);

		sht.Insert(12);
		sht.Insert(22);
		sht.Insert(37);

		TestContext.Out.Write($"\nSimple Has Table State:\n{sht}");

		Assert.That(sht.Contains(12), Is.True);
		Assert.That(sht.Contains(22), Is.True);
		Assert.That(sht.Contains(37), Is.True);
	}
}