using Eto.Forms;

namespace DataStructuresToolkit.UI
{
	public static class RichTextAreaExtensions
	{
		public static void WriteLine(this RichTextArea rch, string message = "") => rch.Write($"{message}\n");
		public static void Write(this RichTextArea rch, string message)
		{
			rch.Text += message;
		}
	}
}