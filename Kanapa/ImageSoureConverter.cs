using System;
using System.Globalization;
using Xamarin.Forms;

namespace Kanapa
{
	public class ImageSoureConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			String s = (String)value;

			ImageSource imageSource = ImageSource.FromUri(new Uri(s));

			if (imageSource != null)
			{
				return imageSource;
			}
			else {

				ImageSource mainImageSource = "Example.jpg";

				return mainImageSource;

			}

		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			return "1";

		}

	}
}

