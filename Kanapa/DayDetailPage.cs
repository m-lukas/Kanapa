using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kanapa
{

	public class DayDetailPage : ContentPage
	{

		ListView favoriteListView = new ListView();

		public DayDetailPage(DateTime d){

			Title = "   Was ist an diesem Tag los?";

			if (!EventsPage.languageIsGerman)
			{
				Title = "   Co się dzieje w ten dzień?";
			}

			int eventsCounter = 0;
			int favoritesCounter = 0;

			BackgroundImage = "Background_Kanapa.png";

			var mainStackLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Spacing = 0
			};

			var contentView1 = new ContentView {
				Padding = new Thickness (10, 0, 10, 0),
				HeightRequest = 75,
				BackgroundColor = Color.FromHex ("#E24944")
			};

			mainStackLayout.Children.Add (contentView1);

			var contentView1Stack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
				Spacing = 10,
				Padding = new Thickness (10, 0, 10, 0)
			};

			contentView1.Content = contentView1Stack;

			var circleImageLayout = new AbsoluteLayout {HorizontalOptions = LayoutOptions.Start};

			contentView1Stack.Children.Add (circleImageLayout);

			var circleImage = new CircleImage {
				Aspect = Aspect.AspectFit,
				FillColor = (Color.Transparent),
				HeightRequest = 60,
				WidthRequest = 60,
				BorderColor = Color.FromHex ("#FFFFFF"),
				BorderThickness = 1
			};

			circleImageLayout.Children.Add (circleImage);

			var Label1 = new Label {
				Text = d.Day + ".",
				TextColor = Color.White,
				FontSize = 28
			};

			circleImageLayout.Children.Add (Label1);

			AbsoluteLayout.SetLayoutBounds (circleImage, new Rectangle (0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (circleImage, AbsoluteLayoutFlags.PositionProportional);

			AbsoluteLayout.SetLayoutBounds (Label1, new Rectangle (0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (Label1, AbsoluteLayoutFlags.PositionProportional);

			var titleMonthLabel = new Label {
				Text = Methods.monthToCAPSString(d),
				TextColor = Color.White,
				FontSize = 24,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			contentView1Stack.Children.Add (titleMonthLabel);

			var titleYearLabel = new Label {
				Text = "" + d.Year,
				TextColor = Color.White,
				FontSize = 24,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.EndAndExpand
			};

			contentView1Stack.Children.Add (titleYearLabel);

			foreach (Event e in EventsPage.events) {

				if (e.dateStart.Day == d.Day && e.dateStart.Month == d.Month && e.dateStart.Year == d.Year) {

					eventsCounter++;

					if (e.isFavorite) {

						favoritesCounter++;

					}

				}

			}

			var grid2 = new Grid{BackgroundColor = new Color(0,0,0,0.5), HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.StartAndExpand, Padding = new Thickness(5,15,5,20)};

			mainStackLayout.Children.Add (grid2);

			var stack1 = new StackLayout {
				Spacing = 0,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Vertical
			};

			var stack2 = new StackLayout {
				Spacing = 0,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Vertical
			};

			grid2.Children.Add (stack1, 0, 0);
			grid2.Children.Add (stack2, 1, 0);

			if (EventsPage.languageIsGerman)
			{
				var eventsCounterTitleLabel = new Label { Text = "EVENTS", FontSize = 14, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End, FontAttributes = FontAttributes.Bold };
				var eventsCounterLabel = new Label { Text = "" + eventsCounter, FontSize = 45, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold };

				stack1.Children.Add(eventsCounterTitleLabel);
				stack1.Children.Add(eventsCounterLabel);

				var favoritesCounterTitleLabel = new Label { Text = "FAVORITEN", FontSize = 14, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End, FontAttributes = FontAttributes.Bold };
				var favoritesCounterLabel = new Label { Text = "" + favoritesCounter, FontSize = 45, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold };

				stack2.Children.Add(favoritesCounterTitleLabel);
				stack2.Children.Add(favoritesCounterLabel);
			}
			else {
				var eventsCounterTitleLabel = new Label { Text = "WYDARZENIA", FontSize = 14, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End, FontAttributes = FontAttributes.Bold };
				var eventsCounterLabel = new Label { Text = "" + eventsCounter, FontSize = 45, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold };

				stack1.Children.Add(eventsCounterTitleLabel);
				stack1.Children.Add(eventsCounterLabel);

				var favoritesCounterTitleLabel = new Label { Text = "FAWORYCI", FontSize = 14, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End, FontAttributes = FontAttributes.Bold };
				var favoritesCounterLabel = new Label { Text = "" + favoritesCounter, FontSize = 45, TextColor = Color.White, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Start, FontAttributes = FontAttributes.Bold };

				stack2.Children.Add(favoritesCounterTitleLabel);
				stack2.Children.Add(favoritesCounterLabel);
			}

			var contentView2 = new ContentView {
				BackgroundColor = Color.FromHex ("#E24944"),
				Padding = new Thickness (10, 5, 10, 5),
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			mainStackLayout.Children.Add (contentView2);

			var favoriteListTitle = new Label {
				Text = "Events an diesem Tag:",
				HorizontalOptions = LayoutOptions.Start,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)) + 2,
				TextColor = Color.White,
				LineBreakMode = LineBreakMode.NoWrap
			};

			if (!EventsPage.languageIsGerman)
			{
				favoriteListTitle.Text = "Dzisiejsze wydarzenia:";
			}

			contentView2.Content = favoriteListTitle;

			favoriteListView.BackgroundColor = Color.Transparent;
			favoriteListView.SeparatorVisibility = SeparatorVisibility.None;
			favoriteListView.ItemsSource = sortEventsForFavoriteListView(d);
			favoriteListView.HasUnevenRows = true;
			favoriteListView.ItemTemplate = new DataTemplate(typeof(tinyEventCell));

			favoriteListView.ItemTapped += this.Tapped;

			mainStackLayout.Children.Add (favoriteListView);

			Content = mainStackLayout;

		}

		async void Tapped(object sender, ItemTappedEventArgs e)
		{

			await Navigation.PushAsync(new EventDetailPage { BindingContext = e.Item as Event });
			((ListView)sender).SelectedItem = null;

		}

		public ObservableCollection<Event> sortEventsForFavoriteListView(DateTime d)
		{

			ObservableCollection<Event> events = new ObservableCollection<Event>();

			foreach (Event e in EventsPage.events)
			{

				if (e.dateStart.Day == d.Day && e.dateStart.Month == d.Month && e.dateStart.Year == d.Year)
				{

					events.Add(e);

				}

			}

			Methods.sortEvents(events);

			return events;

		}

	}
}

