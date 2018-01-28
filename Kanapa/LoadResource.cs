using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;


namespace Kanapa
{

	public class LoadResource
	{

		public static List<PreEvent> events = new List<PreEvent>();

		public static void LoadResourceFromEmbeddedResource ()
		{
			
			var assembly = typeof(LoadResourceText).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("Kanapa.Tabelle.xml");

			using (var reader = new System.IO.StreamReader (stream)) {
				var serializer = new XmlSerializer(typeof(List<PreEvent>));
				events = (List<PreEvent>)serializer.Deserialize(reader);
			}

		}

		public static void LoadResourceFromXML()
		{
			var fileService = DependencyService.Get<ISaveAndLoad>();
			events = fileService.LoadList("events.xml");
		}

		public static ObservableCollection<Event> convertEvents (){

			ObservableCollection<Event> newEventList = new ObservableCollection<Event> ();

			foreach (PreEvent pr in events) {

				Event e = new Event();

				e.descriptionGerman = pr.descriptionGerman;
				e.descriptionPolish = pr.descriptionPolish;
				e.locationGerman = pr.locationGerman;
				e.locationPolish = pr.locationPolish;
				e.imageUrl = pr.imageUrl;
				e.polishDisplayName = pr.polishDisplayName;
				e.germanDisplayName = pr.germanDisplayName;
				Boolean b;
				Boolean.TryParse(pr.isFavorite, out b);
				e.isFavorite = b;
				e.dateStart = DateTime.Parse(pr.dateStart);
				e.dateEnd = DateTime.Parse(pr.dateEnd);
				e.id = pr.id;
				e.x = pr.x;
				e.y = pr.y;

				newEventList.Add (e);

			}

			events.Clear();

			return newEventList;

		}

	}
}
