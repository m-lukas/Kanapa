using System;
using Xamarin.Forms;

namespace Kanapa
{
	public class tinyEventCell : ViewCell
	{
		public tinyEventCell ()
		{

			Height = 55;


			var mainContentView = new ContentView {Padding = new Thickness(0,1,0,1), MinimumHeightRequest = 45};

			var mainStackLayout = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = new Color(0,0,0,0.5),
				HorizontalOptions = LayoutOptions.Fill,
				Spacing = 20,
				Padding = new Thickness(5,5,5,5)
			};

			mainContentView.Content = mainStackLayout;

			var circleImageLayout = new AbsoluteLayout {HeightRequest = 45, WidthRequest = 45, MinimumWidthRequest=45};

			mainStackLayout.Children.Add (circleImageLayout);

			var Label1 = new Label {
				Text = "16:00",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = 13
			};

			Label1.SetBinding(Label.TextProperty, new Binding("dateStart", BindingMode.Default, new TimeFromDayTimeConverter2()));

			circleImageLayout.Children.Add (Label1);

			var Label2 = new Label {
				Text = "Uhr",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = 13
			};

			if (!EventsPage.languageIsGerman)
			{
				Label2.Text = "Zeg.";
			}

			circleImageLayout.Children.Add (Label2);

			AbsoluteLayout.SetLayoutBounds (Label1, new Rectangle (0.5, 0.21, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (Label1, AbsoluteLayoutFlags.PositionProportional);

			AbsoluteLayout.SetLayoutBounds (Label2, new Rectangle (0.5, 0.79, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (Label2, AbsoluteLayoutFlags.PositionProportional);

			Label titleLabel = new Label {
				TextColor = Color.White,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				LineBreakMode = LineBreakMode.TailTruncation,
				VerticalOptions = LayoutOptions.Center,
				Text = "title"
			};

			if (EventsPage.languageIsGerman)
			{
				titleLabel.SetBinding(Label.TextProperty, new Binding("germanDisplayName"));
			}
			else {
				titleLabel.SetBinding(Label.TextProperty, new Binding("polishDisplayName"));
			}

			mainStackLayout.Children.Add (titleLabel);

			var image = new Image { Source = "star_gray.png", Aspect = Aspect.AspectFit, HeightRequest = 25, WidthRequest = 25, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.EndAndExpand };

			mainStackLayout.Children.Add(image);

			image.SetBinding(Image.SourceProperty, new Binding("isFavorite", BindingMode.Default, new FavoriteToColorConverter()));
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{

				Boolean isFavorite = (Boolean)((Event)this.BindingContext).isFavorite;

				if (isFavorite)
				{

					((Image)s).Source = "star_gray.png";

				}
				else {

					((Image)s).Source = "star_yellow.png";

				}

			};

			View = mainContentView;

		}
	}
}

