using System;
using System.Globalization;
using Xamarin.Forms;

namespace Kanapa
{
	public class DateStringFromDateTimeConverter2 : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			String date = "1.1";

			DateTime d = ((DateTime)value);

			date = d.Day + "." + d.Month;

			return date;

		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return 1;

		}

	}
}

