using Xamarin.Forms;
using System;

namespace Kanapa
{
	public class LanguagePage : ContentPage
	{
		public LanguagePage()
		{

			BackgroundImage = "Background_Kanapa.png";
			Padding = new Thickness(0, 100, 0, 50);

			NavigationPage.SetHasNavigationBar(this, false);

			var grid1 = new Grid {ColumnSpacing = 0, RowSpacing = 0, HorizontalOptions = LayoutOptions.Fill };

			var choose = new Label { Text = "Wähle\ndeine\nSprache:", TextColor = Color.White, FontSize = 40, LineBreakMode = LineBreakMode.WordWrap, HorizontalOptions = LayoutOptions.Center };
			Grid.SetRowSpan(choose, 2);

			grid1.Children.Add(choose, 0, 0);

			var choose2 = new Label { Text = "Wybierz\nswój\njęzyk:", TextColor = Color.White, FontSize = 40, LineBreakMode = LineBreakMode.WordWrap, HorizontalOptions = LayoutOptions.Center };
			Grid.SetRowSpan(choose2, 2);

			grid1.Children.Add(choose2, 1, 0);

			var contentView2 = new ContentView { HorizontalOptions = LayoutOptions.Fill, BackgroundColor = Color.FromHex("#443e3e"), VerticalOptions = LayoutOptions.End };

			grid1.Children.Add(contentView2,0,2);
			Grid.SetColumnSpan(contentView2, 2);

			var grid2 = new Grid {ColumnSpacing = 0, RowSpacing = 0, HeightRequest = 90, HorizontalOptions = LayoutOptions.Fill };

			contentView2.Content = grid2;

			var imageGerman = new Image { Source = "german_icon.png", HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			var imagePolish = new Image { Source = "polish_icon.png", HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			var tapGestureRecognizer2 = new TapGestureRecognizer();

			var tapGestureRecognizer1 = new TapGestureRecognizer();
			tapGestureRecognizer1.Tapped += async (s, e) =>
			{

				imagePolish.GestureRecognizers.Remove(tapGestureRecognizer2);
				await imageGerman.ScaleTo(0.95, 50, Easing.CubicOut);
				await imageGerman.ScaleTo(1, 50, Easing.CubicIn);
				EventsPage.languageIsGerman = true;
				var fileService = DependencyService.Get<ISaveAndLoad>();
				fileService.SaveText("language.txt", "german");
				Navigation.InsertPageBefore(new myCarouselPage(), this);
				await Navigation.PopAsync().ConfigureAwait(false);

			};

			imageGerman.GestureRecognizers.Add(tapGestureRecognizer1);

			grid2.Children.Add(imageGerman, 0, 0);
			Grid.SetRowSpan(imageGerman, 3);

			var germanLabel = new Label { Text = "DEUTSCH", FontSize = 11, TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start };

			grid2.Children.Add(germanLabel, 0, 3);

			tapGestureRecognizer2.Tapped += async (s, e) =>
			{
				imageGerman.GestureRecognizers.Remove(tapGestureRecognizer1);
				await imagePolish.ScaleTo(0.8, 50, Easing.CubicOut);
				await imagePolish.ScaleTo(1, 50, Easing.CubicIn);
				EventsPage.languageIsGerman = false;
				var fileService = DependencyService.Get<ISaveAndLoad>();
				fileService.SaveText("language.txt", "polish");
				Navigation.InsertPageBefore(new myCarouselPage(), this);
				await Navigation.PopAsync().ConfigureAwait(false);

			};

			imagePolish.GestureRecognizers.Add(tapGestureRecognizer2);

			grid2.Children.Add(imagePolish, 1, 0);
			Grid.SetRowSpan(imagePolish, 3);

			var polishLabel = new Label { Text = "POLSKI", FontSize = 11, TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start };

			grid2.Children.Add(polishLabel, 1, 3);

			this.Content = grid1;

		}
	}
}

