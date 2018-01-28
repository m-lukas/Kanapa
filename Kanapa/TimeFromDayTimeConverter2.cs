using System;
using System.Globalization;
using Xamarin.Forms;

namespace Kanapa
{
	public class TimeFromDayTimeConverter2 : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			String time = "0 Uhr";

			DateTime d = ((DateTime)value);

			if (d.Minute > 9)
			{
				time = d.Hour + ":" + d.Minute;
			}
			else {
				time = d.Hour + ":0" + d.Minute;
			}

			return time;

		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return 1;

		}

	}
}

