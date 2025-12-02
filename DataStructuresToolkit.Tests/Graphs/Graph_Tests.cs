using DataStructuresToolkit;
using DataStructuresToolkit.Graphs;

namespace DataStructuresToolkit.Tests.Graphs;

[TestFixture]
public class Graph_Tests
{
	[Test]
	public void AddItemShouldAddItem()
	{
		Graph<string> gph = new Graph<string>();

		gph.AddItem("Bob!");

		Assert.That(gph.Contains("Bob!"), Is.True);
	}

	[Test]
	public void AddItemWithConnectionsShouldAddItemWithConnections()
	{
		Graph<string> gph = new Graph<string>();

		gph.AddItem("Bob!", ["Kyle!", "Mickey!", "Carl!", "Anistasia!"]);

		Assert.That(gph.Contains("Bob!"), Is.True);
		Assert.That(gph.GetConnections("Bob!"), Is.EqualTo(new List<string>{"Kyle!", "Mickey!", "Carl!", "Anistasia!"}));
	}

	[Test]
	public void DFSShouldShowDFSPattern()
	{
		Graph<string> gph = new Graph<string>();
		List<string> names = ["Bob!", "Kyle!", "Mickey!", "Carl!", "Anistasia!"];

		gph.AddItem(names[0], [names[1], names[2], names[3], names[4]]);
		gph.AddItem(names[1], [names[0], names[2], names[3], names[4]]);
		gph.AddItem(names[2], [names[0], names[1], names[3], names[4]]);
		gph.AddItem(names[3], [names[0], names[1], names[2], names[4]]);
		gph.AddItem(names[4], [names[0], names[1], names[2], names[3]]);

		TestContext.Out.WriteLine(gph.DFS(names[0]).Count);

		Assert.That(gph.DFS(names[0]), Is.EqualTo(names));
	}
}