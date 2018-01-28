using System;
using System.Globalization;
using Xamarin.Forms;

namespace Kanapa
{
	public class FavoriteToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			String s = "star_gray.png";

			if ((Boolean)value == true){

				s = "star_yellow.png";

			}

			return s;
		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			Boolean b = true;

			return b;


		}

	}
}