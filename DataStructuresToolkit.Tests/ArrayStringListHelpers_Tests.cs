using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DataStructuresToolkit.Tests;

[TestFixture]
[Ignore("Take too long")]
public class ArrayStringListHelpers_Tests
{
	const double leniencyms = 50;

	[Test]
	public void InsertIntoArrayShouldLinearTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			int[] testnames = new int[1000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = i;

			sw.Start();
			ArrayStringListHelpers.InsertIntoArray(testnames, 0, 1);
			sw.Stop();

			TestContext.Out.WriteLine($"InsertIntoArray n={testnames.Length}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			int[] testnames = new int[10000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = i;

			sw.Start();
			ArrayStringListHelpers.InsertIntoArray(testnames, 0, 1);
			sw.Stop();

			TestContext.Out.WriteLine($"InsertIntoArray n={testnames.Length}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			int[] testnames = new int[100000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = i;

			sw.Start();
			ArrayStringListHelpers.InsertIntoArray(testnames, 0, 1);
			sw.Stop();

			TestContext.Out.WriteLine($"InsertIntoArray n={testnames.Length}: {sw.Elapsed}");
			elapsed[2] = sw.Elapsed;
		}
		Assert.That(
			elapsed[0].TotalMilliseconds,
			Is.EqualTo(
				elapsed[1].TotalMilliseconds / 10
			).Within(leniencyms));
		Assert.That(
			elapsed[1].TotalMilliseconds,
			Is.EqualTo(
				elapsed[2].TotalMilliseconds / 10
			).Within(leniencyms));
	}

	[Test]
	public void DeleteFromArrayShouldLinearTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			int[] testnames = new int[1000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = i;

			sw.Start();
			ArrayStringListHelpers.DeleteFromArray(testnames, 0);
			sw.Stop();

			TestContext.Out.WriteLine($"DeleteFromArray n={testnames.Length}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			int[] testnames = new int[10000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = i;

			sw.Start();
			ArrayStringListHelpers.DeleteFromArray(testnames, 0);
			sw.Stop();

			TestContext.Out.WriteLine($"DeleteFromArray n={testnames.Length}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			int[] testnames = new int[100000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = i;

			sw.Start();
			ArrayStringListHelpers.DeleteFromArray(testnames, 0);
			sw.Stop();

			TestContext.Out.WriteLine($"DeleteFromArray n={testnames.Length}: {sw.Elapsed}");
			elapsed[2] = sw.Elapsed;
		}
		Assert.That(
			elapsed[0].TotalMilliseconds,
			Is.EqualTo(
				elapsed[1].TotalMilliseconds / 10
			).Within(leniencyms));
		Assert.That(
			elapsed[1].TotalMilliseconds,
			Is.EqualTo(
				elapsed[2].TotalMilliseconds / 10
			).Within(leniencyms));
	}


	[Test]
	public static void ConcatenateNamesNaiveShouldShowQuadraticTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			string[] testnames = new string[1000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = $"Student{i}";

			sw.Start();
			ArrayStringListHelpers.ConcatenateNamesNaive(testnames);
			sw.Stop();

			TestContext.Out.WriteLine($"ConcatenateNamesNaive n={testnames.Length}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			string[] testnames = new string[10000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = $"Student{i}";

			sw.Start();
			ArrayStringListHelpers.ConcatenateNamesNaive(testnames);
			sw.Stop();

			TestContext.Out.WriteLine($"ConcatenateNamesNaive n={testnames.Length}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			string[] testnames = new string[100000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = $"Student{i}";

			sw.Start();
			ArrayStringListHelpers.ConcatenateNamesNaive(testnames);
			sw.Stop();

			TestContext.Out.WriteLine($"ConcatenateNamesNaive n={testnames.Length}: {sw.Elapsed}");
			elapsed[2] = sw.Elapsed;
		}
		Assert.That(
			elapsed[0].TotalMilliseconds,
			Is.EqualTo(
				elapsed[1].TotalMilliseconds / 100
			).Within(leniencyms));
		Assert.That(
			elapsed[1].TotalMilliseconds,
			Is.EqualTo(
				elapsed[2].TotalMilliseconds / 100
			).Within(leniencyms));
	}
	
	[Test]
	public void ConcatenateNamesBuilderShouldLinearTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			string[] testnames = new string[1000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = $"Student{i}";

			sw.Start();
			ArrayStringListHelpers.ConcatenateNamesBuilder(testnames);
			sw.Stop();

			TestContext.Out.WriteLine($"ConcatenateNamesBuilder n={testnames.Length}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			string[] testnames = new string[10000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = $"Student{i}";

			sw.Start();
			ArrayStringListHelpers.ConcatenateNamesBuilder(testnames);
			sw.Stop();

			TestContext.Out.WriteLine($"ConcatenateNamesBuilder n={testnames.Length}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			string[] testnames = new string[100000];

			for (int i = 0; i < testnames.Length; i++)
				testnames[i] = $"Student{i}";

			sw.Start();
			ArrayStringListHelpers.ConcatenateNamesBuilder(testnames);
			sw.Stop();

			TestContext.Out.WriteLine($"ConcatenateNamesBuilder n={testnames.Length}: {sw.Elapsed}");
			elapsed[2] = sw.Elapsed;
		}
		Assert.That(
			elapsed[0].TotalMilliseconds,
			Is.EqualTo(
				elapsed[1].TotalMilliseconds / 10
			).Within(leniencyms));
		Assert.That(
			elapsed[1].TotalMilliseconds,
			Is.EqualTo(
				elapsed[2].TotalMilliseconds / 10
			).Within(leniencyms));
	}
	
	[Test]
	public void InsertIntoListShouldLinearTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			int[] intarr = new int[1000];

			for (int i = 0; i < intarr.Length; i++)
				intarr[i] = i;
			
			List<int> intlist = [.. intarr];

			sw.Start();
			ArrayStringListHelpers.InsertIntoList(intlist, 0, 567);
			sw.Stop();

			TestContext.Out.WriteLine($"InsertIntoList n={intlist.Count}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			int[] intarr = new int[10000];

			for (int i = 0; i < intarr.Length; i++)
				intarr[i] = i;
			
			List<int> intlist = [.. intarr];

			sw.Start();
			ArrayStringListHelpers.InsertIntoList(intlist, 0, 567);
			sw.Stop();

			TestContext.Out.WriteLine($"InsertIntoList n={intlist.Count}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			int[] intarr = new int[100000];

			for (int i = 0; i < intarr.Length; i++)
				intarr[i] = i;
			
			List<int> intlist = [.. intarr];

			sw.Start();
			ArrayStringListHelpers.InsertIntoList(intlist, 0, 567);
			sw.Stop();

			TestContext.Out.WriteLine($"InsertIntoList n={intlist.Count}: {sw.Elapsed}");
			elapsed[2] = sw.Elapsed;
		}
		Assert.That(
			elapsed[0].TotalMilliseconds,
			Is.EqualTo(
				elapsed[1].TotalMilliseconds / 10
			).Within(leniencyms));
		Assert.That(
			elapsed[1].TotalMilliseconds,
			Is.EqualTo(
				elapsed[2].TotalMilliseconds / 10
			).Within(leniencyms));
	}
}
