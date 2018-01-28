using System;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Kanapa
{
	public class YearFromDayTimeConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			String year = "2016";

			DateTime d1 = ((DateTime[])value)[0];
			DateTime d2 = ((DateTime[])value)[1];

			int y1 = d1.Year;
			int y2 = d2.Year;

			if (y1 == y2) {

				year = "" + y1;

			} else {

				year = y1 + "/" + y2;

			}

			return year;

		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return 2016;

		}

	}
}

