using System;
using System.Reflection;
using System.IO;

namespace Kanapa
{
	public class SaveResourceText
	{
		public SaveResourceText()
		{

			#region How to save a text file embedded resource
			var assembly = typeof(SaveResourceText).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("Kanapa.PCLTextResource.txt");

			string text = "";
			using (var writer = new System.IO.StreamWriter(stream))
			{
				writer.WriteLine(text);
			}
			#endregion

		}
	}
}

