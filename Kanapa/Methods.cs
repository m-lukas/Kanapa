using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Kanapa
{
	public class Methods
	{

		public static ObservableCollection<Event> sortEvents (ObservableCollection<Event> col){

			List<Event> l = new List<Event>();
			DateTime today = DateTime.UtcNow;

			foreach (Event e in col) {

				l.Add (e);

			}

			l.Sort((a, b) => ((Event)a).dateStart.CompareTo(((Event)b).dateStart));

			col.Clear();

			foreach (Event e in l) {

				int i = DateTime.Compare(today, e.dateEnd);

				if (i <= 0)
				{
					
					col.Add(e);

				}

			}

			return col;

		}

		public static ObservableCollection<Group> groupEvents(ObservableCollection<Event> o){

			ObservableCollection<Group> ob = new ObservableCollection<Group>();

			Dictionary<DateTime, List<Event>> dic = new Dictionary<DateTime, List<Event>> ();

			foreach (Event e in o) {

				DateTime d = new DateTime(e.dateStart.Year, e.dateStart.Month, e.dateStart.Day);

				if (!dic.ContainsKey (d)) {

					List<Event> list = new List<Event> ();
					list.Add (e);
					dic.Add (d, list);

				} else {

					dic [d].Add (e);

				}

			}

			ob.Clear();

			foreach(KeyValuePair<DateTime, List<Event>> entry in dic)
			{

				entry.Value.Sort((a, b) => ((Event)a).dateStart.CompareTo(((Event)b).dateStart));

				Group group = new Group (entry.Key);

				foreach (Event e in entry.Value) {

					group.Add (e);

				}

				ob.Add (group);

			}

			return ob;

		}

		public static int dayOfWeekToInt(DayOfWeek d){

			int  i = 1;

			switch (d) {

			case DayOfWeek.Monday: 
				i = 1;
				break;
			case DayOfWeek.Tuesday:
				i = 2;
				break;
			case DayOfWeek.Wednesday:
				i = 3;
				break;
			case DayOfWeek.Thursday:
				i = 4;
				break;
			case DayOfWeek.Friday:
				i = 5;
				break;
			case DayOfWeek.Saturday:
				i = 6;
				break;
			case DayOfWeek.Sunday:
				i = 7;
				break;

			}

			return i;

		}

		public static string monthToString(DateTime d){


			String s = "";
			int m = d.Month;

			if (EventsPage.languageIsGerman)
			{

				switch (m)
				{

					case 1:
						s = "Januar";
						break;
					case 2:
						s = "Februar";
						break;
					case 3:
						s = "März";
						break;
					case 4:
						s = "April";
						break;
					case 5:
						s = "Mai";
						break;
					case 6:
						s = "Juni";
						break;
					case 7:
						s = "Juli";
						break;
					case 8:
						s = "August";
						break;
					case 9:
						s = "September";
						break;
					case 10:
						s = "Oktober";
						break;
					case 11:
						s = "November";
						break;
					case 12:
						s = "Dezember";
						break;

				}

			}
			else {

				switch (m)
				{

					case 1:
						s = "Styczeń";
						break;
					case 2:
						s = "Luty";
						break;
					case 3:
						s = "Marzec";
						break;
					case 4:
						s = "Kwiecień";
						break;
					case 5:
						s = "Maj";
						break;
					case 6:
						s = "Czerwiec";
						break;
					case 7:
						s = "Lipiec";
						break;
					case 8:
						s = "Sierpień";
						break;
					case 9:
						s = "Wrzesień";
						break;
					case 10:
						s = "Październik";
						break;
					case 11:
						s = "Listopad";
						break;
					case 12:
						s = "Grudzień";
						break;

				}

			}

			return s;

		}

		public static string monthToCAPSString(DateTime d)
		{


			String s = "";
			int m = d.Month;

			if (EventsPage.languageIsGerman)
			{

				switch (m)
				{

					case 1:
						s = "JANUAR";
						break;
					case 2:
						s = "FEBRUAR";
						break;
					case 3:
						s = "MÄRZ";
						break;
					case 4:
						s = "APRIL";
						break;
					case 5:
						s = "MAI";
						break;
					case 6:
						s = "JUNI";
						break;
					case 7:
						s = "JULI";
						break;
					case 8:
						s = "AUGUST";
						break;
					case 9:
						s = "SEPTEMBER";
						break;
					case 10:
						s = "OKTOBER";
						break;
					case 11:
						s = "NOVEMBER";
						break;
					case 12:
						s = "DEZEMBER";
						break;

				}

			}
			else {

				switch (m)
				{

					case 1:
						s = "STYCZEŃ";
						break;
					case 2:
						s = "LUTY";
						break;
					case 3:
						s = "MARZEC";
						break;
					case 4:
						s = "KWIECIEŃ";
						break;
					case 5:
						s = "MAJ";
						break;
					case 6:
						s = "CZERWIEC";
						break;
					case 7:
						s = "LIPIEC";
						break;
					case 8:
						s = "SIERPIEŃ";
						break;
					case 9:
						s = "WRZESIEŃ";
						break;
					case 10:
						s = "PAŹDZIERNIK";
						break;
					case 11:
						s = "LISTOPAD";
						break;
					case 12:
						s = "GRUDZIEŃ";
						break;

				}

			}

			return s;

		}

		public static void listLastEventOnMapPage()
		{

			int i = 0;

			foreach (Event e in EventsPage.events)
			{

				i++;

				if (i <= 3)
				{

					EventsPage.recommendedEvents.Add(e);

					//switch (i)
					//{
					//	case 1:
					//		MapPage.image1 = new Image
					//		{
					//			Aspect = Aspect.AspectFill,
					//			VerticalOptions = LayoutOptions.Start,
					//			HorizontalOptions = LayoutOptions.Fill,
					//			Source = ImageSource.FromUri(new Uri(e.imageUrl))
					//		};
					//		MapPage.grid.Children.Add(MapPage.image1, 0, 0);
					//		break;
					//	case 2:
					//		MapPage.image2 = new Image
					//		{
					//			Aspect = Aspect.AspectFill,
					//			VerticalOptions = LayoutOptions.Start,
					//			HorizontalOptions = LayoutOptions.Fill,
					//			Source = ImageSource.FromUri(new Uri(e.imageUrl))
					//		};
					//		MapPage.grid.Children.Add(MapPage.image2, 1, 0);
					//		break;
					//	case 3:
					//		MapPage.image1 = new Image
					//		{
					//			Aspect = Aspect.AspectFill,
					//			VerticalOptions = LayoutOptions.Start,
					//			HorizontalOptions = LayoutOptions.Fill,
					//			Source = ImageSource.FromUri(new Uri(e.imageUrl))
					//		};
					//		MapPage.grid.Children.Add(MapPage.image1, 0, 1);
					//		break;
					//	//case 4:
					//	//	MapPage.image1 = new Image
					//	//	{
					//	//		Aspect = Aspect.AspectFill,
					//	//		VerticalOptions = LayoutOptions.Start,
					//	//		HorizontalOptions = LayoutOptions.Fill,
					//	//		Source = ImageSource.FromUri(new Uri(e.imageUrl))
					//	//	};
					//	//	MapPage.grid.Children.Add(MapPage.image1, 1, 1);
					//	//	break;
					//	//case 5:
					//	//	MapPage.image1 = new Image
					//	//	{
					//	//		Aspect = Aspect.AspectFill,
					//	//		VerticalOptions = LayoutOptions.Start,
					//	//		HorizontalOptions = LayoutOptions.Fill,
					//	//		Source = ImageSource.FromUri(new Uri(e.imageUrl))
					//	//	};
					//	//	MapPage.grid.Children.Add(MapPage.image1, 0, 2);
					//	//	break;
					//	//case 6:
					//	//	MapPage.image1 = new Image
					//	//	{
					//	//		Aspect = Aspect.AspectFill,
					//	//		VerticalOptions = LayoutOptions.Start,
					//	//		HorizontalOptions = LayoutOptions.Fill,
					//	//		Source = ImageSource.FromUri(new Uri(e.imageUrl))
					//	//	};
					//	//	MapPage.grid.Children.Add(MapPage.image1, 1, 2);
					//	//	break;
					//}

				}

			}
		}

	}

}
