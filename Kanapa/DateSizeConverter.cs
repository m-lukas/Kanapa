using System;
using System.Globalization;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Kanapa
{
	public class DateSizeConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			double size = 1;

			DateTime d1 = ((DateTime[])value)[0];
			DateTime d2 = ((DateTime[])value)[1];

			if (d1.Equals (d2)) {

				size = Device.GetNamedSize (NamedSize.Large, typeof(Label));

			} else {

				size = Device.GetNamedSize (NamedSize.Small, typeof(Label));

			}

			return size;

		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return 1;

		}

	}
}
