using System;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Kanapa
{
	public class DayOfWeekFromDateTimeConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			DateTime d = ((DateTime)value);

			String s = "";
			DayOfWeek day = d.DayOfWeek;

			if (EventsPage.languageIsGerman)
			{

				switch (day)
				{

					case DayOfWeek.Monday:
						s = "| MO";
						break;
					case DayOfWeek.Tuesday:
						s = "| DI";
						break;
					case DayOfWeek.Wednesday:
						s = "| MI";
						break;
					case DayOfWeek.Thursday:
						s = "| DO";
						break;
					case DayOfWeek.Friday:
						s = "| FR";
						break;
					case DayOfWeek.Saturday:
						s = "| SA";
						break;
					case DayOfWeek.Sunday:
						s = "| SO";
						break;

				}

			}
			else {

				switch (day)
				{

					case DayOfWeek.Monday:
						s = "| PN";
						break;
					case DayOfWeek.Tuesday:
						s = "| WT";
						break;
					case DayOfWeek.Wednesday:
						s = "| ŚR";
						break;
					case DayOfWeek.Thursday:
						s = "| CZ";
						break;
					case DayOfWeek.Friday:
						s = "| PT";
						break;
					case DayOfWeek.Saturday:
						s = "| SO";
						break;
					case DayOfWeek.Sunday:
						s = "| NI";
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

