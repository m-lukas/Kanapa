using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;

namespace Kanapa
{
	public class LoadResourceText
	{
		public LoadResourceText ()
		{

			#region How to load a text file embedded resource
			var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("Kanapa.PCLTextResource.txt");

			string text = "";
			using (var reader = new System.IO.StreamReader (stream)) {
				text = reader.ReadToEnd ();
			}
			#endregion

			// NOTE: use for debugging, not in released app code!
			//foreach (var res in assembly.GetManifestResourceNames()) 
			//	System.Diagnostics.Debug.WriteLine("found resource: " + res);
		}
	}
}