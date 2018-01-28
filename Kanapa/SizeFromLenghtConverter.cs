using System;
using System.Globalization;
using Xamarin.Forms;

namespace Kanapa
{
	public class SizeFromLenghtConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			double size = Device.GetNamedSize(NamedSize.Large, typeof(Label));

			DateTime d = ((DateTime)value);

			int day = d.Day;

			if (day > 9)
			{
				size = Device.GetNamedSize(NamedSize.Large, typeof(Label))-4;
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

