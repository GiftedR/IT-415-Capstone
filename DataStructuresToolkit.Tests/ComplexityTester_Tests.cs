using System.Diagnostics;
using NUnit.Framework.Internal;

namespace DataStructuresToolkit.Tests;

[TestFixture]
[Ignore("Takes too long")]
public static class ComplexityTesterTests
{
	const double leniencyms = 5;

	[Test]
	public static void ShouldShowConstantTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			int[] testarr = new int[1000];

			for (int i = 0; i < testarr.Length; i++)
				testarr[i] = i;

			sw.Start();
			ComplexityTester.RunConstantScenario(testarr);
			sw.Stop();

			TestContext.Out.WriteLine($"O(1) n={testarr.Length}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			int[] testarr = new int[10000];

			for (int i = 0; i < testarr.Length; i++)
				testarr[i] = i;

			sw.Start();
			ComplexityTester.RunConstantScenario(testarr);
			sw.Stop();

			TestContext.Out.WriteLine($"O(1) n={testarr.Length}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			int[] testarr = new int[100000];

			for (int i = 0; i < testarr.Length; i++)
				testarr[i] = i;

			sw.Start();
			ComplexityTester.RunConstantScenario(testarr);
			sw.Stop();

			TestContext.Out.WriteLine($"O(1) n={testarr.Length}: {sw.Elapsed}");
			elapsed[2] = sw.Elapsed;
		}

		Assert.That(
			elapsed[0].TotalMilliseconds,
			Is.EqualTo(
				elapsed[1].TotalMilliseconds
			).Within(leniencyms));
		Assert.That(
			elapsed[1].TotalMilliseconds,
			Is.EqualTo(
				elapsed[2].TotalMilliseconds
			).Within(leniencyms));
	}

	[Test]
	public static void ShouldShowLinearTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			int[] testarr = new int[1000];

			for (int i = 0; i < testarr.Length; i++)
				testarr[i] = i;

			sw.Start();
			ComplexityTester.RunLinearScenario(testarr, testarr);
			sw.Stop();

			TestContext.Out.WriteLine($"O(n) n={testarr.Length}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			int[] testarr = new int[10000];

			for (int i = 0; i < testarr.Length; i++)
				testarr[i] = i;

			sw.Start();
			ComplexityTester.RunLinearScenario(testarr, testarr);
			sw.Stop();

			TestContext.Out.WriteLine($"O(n) n={testarr.Length}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			int[] testarr = new int[100000];

			for (int i = 0; i < testarr.Length; i++)
				testarr[i] = i;

			sw.Start();
			ComplexityTester.RunLinearScenario(testarr, testarr);
			sw.Stop();

			TestContext.Out.WriteLine($"O(n) n={testarr.Length}: {sw.Elapsed}");
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
	public static void ShouldShowQuadraticTime()
	{
		Stopwatch sw = new();
		TimeSpan[] elapsed = new TimeSpan[3];

		{
			char[] testword = new char[1000];

			for (int i = 0; i < testword.Length; i++)
				testword[i] = (char)((DateTime.Now.Nanosecond % 26) + 65);

			sw.Start();
			ComplexityTester.RunQuadraticScenario(new string(testword));
			sw.Stop();

			TestContext.Out.WriteLine($"O(n²) n={testword.Length}: {sw.Elapsed}");
			elapsed[0] = sw.Elapsed;
		}

		{
			char[] testword = new char[10000];

			for (int i = 0; i < testword.Length; i++)
				testword[i] = (char)((DateTime.Now.Nanosecond % 26) + 65);

			sw.Start();
			ComplexityTester.RunQuadraticScenario(new string(testword));
			sw.Stop();

			TestContext.Out.WriteLine($"O(n²) n={testword.Length}: {sw.Elapsed}");
			elapsed[1] = sw.Elapsed;
		}

		{
			char[] testword = new char[100000];

			for (int i = 0; i < testword.Length; i++)
				testword[i] = (char)((DateTime.Now.Nanosecond % 26) + 65);

			sw.Start();
			ComplexityTester.RunQuadraticScenario(new string(testword));
			sw.Stop();

			TestContext.Out.WriteLine($"O(n²) n={testword.Length}: {sw.Elapsed}");
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
}