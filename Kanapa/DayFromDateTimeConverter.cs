using System;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Kanapa
{
	public class DayFromDayTimeConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			String day = "1.";

			DateTime d = ((DateTime)value);

			day = d.Day + ".";

			return day;

		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return 1;

		}

	}
}