using System;
using Xamarin.Forms;
using Kanapa.Droid;
using System.IO;
using Kanapa;
using System.Xml.Serialization;
using System.Collections.Generic;

[assembly: Dependency (typeof (SaveAndLoad_Android))]

namespace Kanapa.Droid
{
	public class SaveAndLoad_Android : ISaveAndLoad
	{
		#region ISaveAndLoad implementation

		//public async Task SaveListAsync (string filename, List<PreEvent> l)
		//{
		//	var assembly = typeof(Kanapa.LoadResourceText).GetTypeInfo().Assembly;
		//	Stream stream = assembly.GetManifestResourceStream("Kanapa.Tabelle.xml");
		//	XmlSerializer writer = new XmlSerializer(typeof(List<PreEvent>));
		//	//System.IO.FileStream file = System.IO.File.Create(path);
		//	writer.Serialize(stream, l);
		//	stream.Close();
		//}

		public void SaveList(string filename, List<PreEvent> l)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			XmlSerializer serializer = new XmlSerializer(typeof(List<PreEvent>));
			using (TextWriter writer = new StreamWriter(filePath)){
				serializer.Serialize(writer, l);
			}
		}

		public List<PreEvent> LoadList(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			Stream stream = File.Open(filePath, FileMode.Open);
			using (var reader = new System.IO.StreamReader(stream))
			{
				var serializer = new XmlSerializer(typeof(List<PreEvent>));
				return (List<PreEvent>)serializer.Deserialize(reader);
			}
		}

		public string LoadText(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			return System.IO.File.ReadAllText(filePath);
		}

		public void SaveText(string filename, string text)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			System.IO.File.WriteAllText(filePath, text);
		}

		public bool FileExists (string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

			return File.Exists (Path.Combine(documentsPath, filename));
		}

		#endregion

		string CreatePathToFile (string filename)
		{
			var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(docsPath, filename);
		}
	}
}