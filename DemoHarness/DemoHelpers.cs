using System.Text;

namespace DemoHarness;

public static class DemoHelpers
{
	public static string StringifyArray(dynamic[] arr)
	{
		if (arr == null)
			return "";
		StringBuilder arrsb = new("[");
		foreach (var item in arr)
			arrsb.Append($" {item}, ");
		arrsb.Remove(arrsb.Length - 2, 2);
		arrsb.Append(" ]");
		return arrsb.ToString();
	}
}