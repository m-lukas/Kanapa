using System;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Kanapa
{
	public class MonthFromDayTimeConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			DateTime d = ((DateTime)value);

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

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return 1;

		}

	}
}
