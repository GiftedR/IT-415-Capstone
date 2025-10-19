using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace DataStructuresToolkit.Tests;

[TestFixture]
public static class RecursiveHelper_Tests
{
	private static int[] arrMaker(int length)
	{
		int[] gen = new int[length];
		for (int idx = 0; idx < length; idx++)
			gen[idx] = idx + 1;
		return gen;
	}

	[TestCase("cs")]
	[TestCase("de")]
	[TestCase("es")]
	[TestCase("fr")]
	[TestCase("it")]
	[TestCase("ja")]
	[TestCase("ko")]
	[TestCase("pl")]
	[TestCase("pt-BR")]
	[TestCase("ru")]
	[TestCase("tr")]
	[TestCase("zh-Hans")]
	[TestCase("zh-Hant")]
	public static void GetFoldersShouldShowFolders(string foldername)
	{
		string folders;

		folders = RecursiveHelper.GetFolders();

		Assert.That(
			folders,
			Contains.Substring(foldername)
		);
	}

	[TestCase("hi", false)]
	[TestCase("hello", false)]
	[TestCase("", true)]
	[TestCase("saippuakivikauppias", true)]
	public static void IsPalindromeShouldShowPalindrome(string palindrome, bool expected)
	{
		Assert.That(
			RecursiveHelper.IsPalindrome(palindrome),
			Is.EqualTo(expected)
		);
	}

	[TestCase(0, 0)]
	[TestCase(10, 55)]
	[TestCase(20, 210)]
	[TestCase(30, 465)]
	public static void BinaryAdderShouldSumArray(int arrlen, int expected)
	{
		int[] arr = arrMaker(arrlen);

		Assert.That(
			RecursiveHelper.ArrAdder(arr),
			Is.EqualTo(expected)
		);
	}
}