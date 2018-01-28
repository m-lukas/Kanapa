using System;
using System.Globalization;
using Xamarin.Forms;

namespace Kanapa
{
	public class shortMonthFromDayTimeConverter : IValueConverter
	{

		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{

			DateTime d = ((DateTime)value);

			String s = "";
			int m = d.Month;

			if (EventsPage.languageIsGerman)
			{

				switch (m)
				{

					case 1:
						s = "JAN";
						break;
					case 2:
						s = "FEB";
						break;
					case 3:
						s = "MÄR";
						break;
					case 4:
						s = "APR";
						break;
					case 5:
						s = "MAI";
						break;
					case 6:
						s = "JUN";
						break;
					case 7:
						s = "JUL";
						break;
					case 8:
						s = "AUG";
						break;
					case 9:
						s = "SEP";
						break;
					case 10:
						s = "OKT";
						break;
					case 11:
						s = "NOV";
						break;
					case 12:
						s = "DEZ";
						break;

				}

			}
			else {

				switch (m)
				{

					case 1:
						s = " STY";
						break;
					case 2:
						s = " LUT";
						break;
					case 3:
						s = " MAR";
						break;
					case 4:
						s = " KWI";
						break;
					case 5:
						s = " MAJ";
						break;
					case 6:
						s = " CZE";
						break;
					case 7:
						s = " LIP";
						break;
					case 8:
						s = " SIE";
						break;
					case 9:
						s = " WRZ";
						break;
					case 10:
						s = " PAŹ";
						break;
					case 11:
						s = " LIS";
						break;
					case 12:
						s = " GRU";
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

