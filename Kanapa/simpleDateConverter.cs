using System;
using System.Globalization;
using Xamarin.Forms;

namespace Kanapa
{
	public class simpleDateConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			DateTime d = ((DateTime)value);

			String s = d.Day + "." + d.Month + "." + d.Year;

			return s;

		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return 1;

		}

	}
}


