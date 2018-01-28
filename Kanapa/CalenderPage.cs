using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Kanapa
{
	public class CalenderPage : ContentPage
	{

		public CalenderPage()
		{

			if (EventsPage.languageIsGerman)
			{
				Title = "   Kalender";
			}
			else {
				Title = "   Kalendarz";
			}

			BackgroundImage = "Background_Kanapa.png";

			var scroll = new ScrollView();

			var stack = new StackLayout { Orientation = StackOrientation.Vertical, Spacing = 10 };

			scroll.Content = stack;

			Dictionary<DateTime, List<Event>> dic = new Dictionary<DateTime, List<Event>>();

			DateTime now = DateTime.UtcNow;

			int month = now.Month;
			int year = now.Year;

			for (int i = 0; i < 12; i++)
			{

				if (month > 12)
				{
					month = month - 12;
					year = year + 1;
				}

				DateTime d = new DateTime(year, month, 1);

				dic.Add(d, new List<Event>());

				month++;

			}

			foreach (Event e in EventsPage.events)
			{

				DateTime d = new DateTime(e.dateStart.Year, e.dateStart.Month, 1);

				if (dic.ContainsKey(d))
				{

					dic[d].Add(e);

				}
				else {

					if (DateTime.Compare(DateTime.UtcNow, d) < 0)
					{
						dic.Add(d, new List<Event>());
						dic[d].Add(e);
					}

				}

			}

			//START - Überbrückung bis dieser Fehler behoben wird

			if (EventsPage.firstTimeOpened)
			{

				DateTime d2 = new DateTime(2016, 11, 1);
				DateTime d3 = new DateTime(2016, 12, 1);
				DateTime d4 = new DateTime(2017, 1, 1);
				DateTime d5 = new DateTime(2017, 8, 1);

				List<Event> l1 = new List<Event>();
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 1) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 4) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 6) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 8) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 11) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 12) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 15) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 16) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 18) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 19) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 22) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 25) });
				l1.Add(new Event { dateStart = new DateTime(2016, 11, 29) });
				List<Event> l2 = new List<Event>();
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 2) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 6) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 11) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 13) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 16) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 20) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 25) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 27) });
				l2.Add(new Event { dateStart = new DateTime(2016, 12, 29) });
				List<Event> l3 = new List<Event>();
				l3.Add(new Event { dateStart = new DateTime(2017, 1, 13) });
				l3.Add(new Event { dateStart = new DateTime(2017, 1, 15) });
				l3.Add(new Event { dateStart = new DateTime(2017, 1, 22) });
				List<Event> l4 = new List<Event>();
				l4.Add(new Event { dateStart = new DateTime(2017, 8, 25) });

				dic[d2] = l1;
				dic[d3] = l2;
				dic[d4] = l3;
				dic[d5] = l4;

			}

			//END

			foreach (KeyValuePair<DateTime, List<Event>> entry in dic)
			{

				var contentView = new ContentView
				{
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.StartAndExpand,
					BackgroundColor = new Color(0, 0, 0, 0.5),
					Padding = new Thickness(10, 7, 10, 7)
				};

				stack.Children.Add(contentView);

				var mainstack = new StackLayout { Orientation = StackOrientation.Vertical, Spacing = 5 };

				contentView.Content = mainstack;

				var title = new Label { TextColor = Color.White, FontSize = 24, HorizontalOptions = LayoutOptions.StartAndExpand, Text = Methods.monthToString(entry.Key) + " " + entry.Key.Year };

				mainstack.Children.Add(title);

				var grid = new Grid { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.EndAndExpand, ColumnSpacing = 5, RowSpacing = 5 };

				mainstack.Children.Add(grid);

				int countOfDays = DateTime.DaysInMonth(entry.Key.Year, entry.Key.Month);
				int rowint = 1;
				int columnint = Methods.dayOfWeekToInt(entry.Key.DayOfWeek) - 2;

				if (EventsPage.languageIsGerman)
				{

					var monday = new Label { Text = "MO", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var tuesday = new Label { Text = "DI", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var wednesday = new Label { Text = "MI", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var thursday = new Label { Text = "DO", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var friday = new Label { Text = "FR", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var saturday = new Label { Text = "SA", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var sunday = new Label { Text = "SO", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };

					grid.Children.Add(monday, 0, 0);
					grid.Children.Add(tuesday, 1, 0);
					grid.Children.Add(wednesday, 2, 0);
					grid.Children.Add(thursday, 3, 0);
					grid.Children.Add(friday, 4, 0);
					grid.Children.Add(saturday, 5, 0);
					grid.Children.Add(sunday, 6, 0);

				}
				else { 
				
					var monday = new Label { Text = "PN", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var tuesday = new Label { Text = "WT", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var wednesday = new Label { Text = "ŚR", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var thursday = new Label { Text = "CZ", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var friday = new Label { Text = "PT", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var saturday = new Label { Text = "SO", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
					var sunday = new Label { Text = "NI", TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };

					grid.Children.Add(monday, 0, 0);
					grid.Children.Add(tuesday, 1, 0);
					grid.Children.Add(wednesday, 2, 0);
					grid.Children.Add(thursday, 3, 0);
					grid.Children.Add(friday, 4, 0);
					grid.Children.Add(saturday, 5, 0);
					grid.Children.Add(sunday, 6, 0);

				}

				for (int i = 1; i <= countOfDays; i++)
				{

					int countOfEvents = 0;

					foreach (Event e in entry.Value)
					{

						if (e.dateStart.Day == i)
						{

							countOfEvents++;

						}

					}

					if (countOfEvents == 0)
					{

						DateTime d = new DateTime(entry.Key.Year, entry.Key.Month, i);

						var bv = new BoxView { WidthRequest = 20, HeightRequest = 30, BackgroundColor = Color.Gray };

						var tapGestureRecognizer = new TapGestureRecognizer();
						tapGestureRecognizer.Tapped += async (s, e) =>
						{

							await bv.ScaleTo(0.9, 50, Easing.CubicOut);
							await bv.ScaleTo(1, 50, Easing.CubicIn);
							await Navigation.PushAsync(new DayDetailPage(d));

						};

						bv.GestureRecognizers.Add(tapGestureRecognizer);
						var label = new Label { Text = " " + i, TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold };

						if (columnint + 1 > 6)
						{

							columnint = 0;
							rowint++;

							grid.Children.Add(bv, columnint, rowint);
							grid.Children.Add(label, columnint, rowint);

						}
						else {

							grid.Children.Add(bv, columnint + 1, rowint);
							grid.Children.Add(label, columnint + 1, rowint);

							columnint++;

						}

					}
					else if (countOfEvents > 0)
					{

						DateTime d = new DateTime(entry.Key.Year, entry.Key.Month, i);

						var bv = new BoxView { WidthRequest = 20, HeightRequest = 30, BackgroundColor = Color.FromHex("#E24944") };

						var tapGestureRecognizer = new TapGestureRecognizer();
						tapGestureRecognizer.Tapped += async (s, e) =>
						{

							await bv.ScaleTo(0.9, 50, Easing.CubicOut);
							await bv.ScaleTo(1, 50, Easing.CubicIn);
							await Navigation.PushAsync(new DayDetailPage(d));

						};

						bv.GestureRecognizers.Add(tapGestureRecognizer);
						//var image = new Image
						//{
						//	HeightRequest = 10,
						//	Source = "favorite_corner.png",
						//	HorizontalOptions = LayoutOptions.End,
						//	VerticalOptions = LayoutOptions.End
						//};

						var label = new Label { Text = " " + i, TextColor = Color.White, FontSize = 14, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold };

						if (columnint + 1 > 6)
						{

							columnint = 0;
							rowint++;

							grid.Children.Add(bv, columnint, rowint);
							grid.Children.Add(label, columnint, rowint);

						}
						else {

							grid.Children.Add(bv, columnint + 1, rowint);
							grid.Children.Add(label, columnint + 1, rowint);

							columnint++;

						}

					}


				}

			}

			this.Content = scroll;

		}


		}

	}

