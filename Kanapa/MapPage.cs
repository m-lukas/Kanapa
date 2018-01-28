using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Kanapa
{
	public class MapPage : ContentPage
	{

		public static Map map;

		public MapPage()
		{

			Title = "   Karte";

			if (!EventsPage.languageIsGerman)
			{
				Title = "   Mapa";
			}

			BackgroundImage = "Background_Kanapa.png";

			var mainContentView = new ContentView { BackgroundColor = new Color(0, 0, 0, 0.5), Padding = new Thickness(20, 20, 20, 20) };

			var stack = new StackLayout { Spacing = 0, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };

			mainContentView.Content = stack;

			var contentView1 = new ContentView
			{
				BackgroundColor = Color.FromHex("#E24944"),
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 5, 10, 5)
			};

			stack.Children.Add(contentView1);

			var MapTitle = new Label
			{
				Text = "Wo ist heute etwas los?",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2,
				LineBreakMode = LineBreakMode.NoWrap,
				VerticalOptions = LayoutOptions.Center
			};

			if (!EventsPage.languageIsGerman)
			{
				MapTitle.Text = "Gdzie się dzisiaj coś dzieje?";
			}

			contentView1.Content = MapTitle;

			map = new Map
			{
				HorizontalOptions = LayoutOptions.Fill,
				MapType = MapType.Street,
				HeightRequest = 150
			};

			map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(51.150568, 14.986818), Distance.FromMiles(1.5)));
			map.HasZoomEnabled = false;
			map.HasScrollEnabled = false;

			stack.Children.Add(map);

			var contentView2 = new ContentView { HeightRequest = 20, BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.Fill };

			stack.Children.Add(contentView2);

			var grid = new Grid { HeightRequest = 67, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.Fill, RowSpacing = 2, ColumnSpacing = 2 };

			stack.Children.Add(grid);

			var bv = new BoxView { BackgroundColor = Color.Gray };

			var tapGestureRecognizer1 = new TapGestureRecognizer();
			tapGestureRecognizer1.Tapped += async (s, e) =>
			{
				await bv.ScaleTo(0.9, 50, Easing.CubicOut);
				await bv.ScaleTo(1, 50, Easing.CubicIn);
				await Navigation.PushAsync(new InfoPage());

			};

			bv.GestureRecognizers.Add(tapGestureRecognizer1);

			var bv2 = new BoxView { BackgroundColor = Color.Gray };

			var tapGestureRecognizer2 = new TapGestureRecognizer();
			tapGestureRecognizer2.Tapped += async (s, e) =>
			{
				await bv2.ScaleTo(0.9, 50, Easing.CubicOut);
				await bv2.ScaleTo(1, 50, Easing.CubicIn);
				Device.OpenUri(new Uri("http://kanapa-blog.org/"));

			};

			bv2.GestureRecognizers.Add(tapGestureRecognizer2);

			grid.Children.Add(bv, 0, 0);
			Grid.SetRowSpan(bv, 3);
			grid.Children.Add(bv2, 1, 0);
			Grid.SetRowSpan(bv2, 3);

			var image1 = new Image { HeightRequest = 30, WidthRequest = 30, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.Center, Source = "options.png" };
			var image2 = new Image { HeightRequest = 30, WidthRequest = 30, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.Center, Source = "homepage.png" };

			grid.Children.Add(image1, 0, 0);
			Grid.SetRowSpan(image1, 2);
			grid.Children.Add(image2, 1, 0);
			Grid.SetRowSpan(image2, 2);

			var label1 = new Label { Text = "ÜBER", FontSize = 11, TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start};
			var label2 = new Label { Text = "HOMEPAGE", FontSize = 11, TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start };

			if (!EventsPage.languageIsGerman)
			{
				label1.Text = "O";
				label2.Text = "Strona gółwna";
			}

			grid.Children.Add(label1, 0, 2);
			grid.Children.Add(label2, 1, 2);

			Content = mainContentView;

		}
	}
}
