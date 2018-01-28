using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Collections.Generic;
using System;
using Xamarin.Forms;

namespace Kanapa
{
	public class SaveResource
	{

		public static List<PreEvent> preevents = new List<PreEvent>();

		public static void SaveResourceInXML ()
		{
			var fileService = DependencyService.Get<ISaveAndLoad>();
			fileService.SaveList("events.xml", preevents);
		}

		public static void convertEventToPreEvent()
		{

			preevents.Clear();

			foreach(Event e in EventsPage.events){

				PreEvent pr = new PreEvent();

				if (e.isFavorite)
				{
					pr.isFavorite = "true";
				}
				else {
					pr.isFavorite = "false";
				}

				pr.germanDisplayName = e.germanDisplayName;
				pr.polishDisplayName = e.polishDisplayName;
				pr.locationGerman = e.locationGerman;
				pr.locationPolish = e.locationPolish;
				pr.descriptionGerman = e.descriptionGerman;
				pr.descriptionPolish = e.descriptionPolish;
				pr.dateStart = e.dateStart.Year + "/" + e.dateStart.Month + "/" + e.dateStart.Day + " " + e.dateStart.Hour + ":" + e.dateStart.Minute;
				pr.dateEnd = e.dateEnd.Year + "/" + e.dateEnd.Month + "/" + e.dateEnd.Day + " " + e.dateEnd.Hour + ":" + e.dateEnd.Minute;
				pr.imageUrl = e.imageUrl;
				pr.id = e.id;
				pr.x = e.x;
				pr.y = e.y;

				preevents.Add(pr);

			}

		}

	}
}

