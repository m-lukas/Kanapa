using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Kanapa
{
	public class EventCell : ViewCell
	{

		Image image;

		public EventCell ()
		{

			var mainContentView = new ContentView {Padding = new Thickness(0,1,0,1), MinimumHeightRequest = 70, HorizontalOptions = LayoutOptions.Fill};

			var mainGrid = new Grid { HorizontalOptions = LayoutOptions.Fill, RowSpacing = 0, ColumnSpacing = 0, BackgroundColor = new Color(0,0,0,0.5) };

			mainContentView.Content = mainGrid;

			var contentView1 = new ContentView {
				Padding = 1,
				WidthRequest = 70,
				HeightRequest = 70,
				HorizontalOptions = LayoutOptions.Start,
				MinimumWidthRequest = 80,
				MinimumHeightRequest = 70
			};

			mainGrid.Children.Add (contentView1,0,0);

			Grid.SetColumnSpan(contentView1, 2);

			var circleImageLayout = new AbsoluteLayout ();

			contentView1.Content = circleImageLayout;

//			var circleImage = new CircleImage {
//				Aspect = Aspect.AspectFit,
//				FillColor = Color.Transparent,
//				HeightRequest = 55,
//				WidthRequest = 55,
//				BorderColor = Color.Transparent,
//				BorderThickness = 2
//			};

//			.FromHex ("#E24944"))
//			.FromHex ("#443e3e")

//			circleImageLayout.Children.Add (circleImage);

			var Label1 = new Label {
				Text = "16:00",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
			};

			circleImageLayout.Children.Add (Label1);

			Label1.SetBinding (Label.TextProperty, new Binding ("dateStart", BindingMode.Default, new TimeFromDayTimeConverter2()));

			var Label2 = new Label {
				Text = "Uhr",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label))
			};

			if (!EventsPage.languageIsGerman)
			{
				Label2.Text = "Zegarek";
			}

			circleImageLayout.Children.Add (Label2);

//			Label2.SetBinding (Label.TextProperty, new Binding ("date", BindingMode.Default, new MonthFromDayTimeConverter ()));

			AbsoluteLayout.SetLayoutBounds (Label1, new Rectangle (0.5, 0.31, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (Label1, AbsoluteLayoutFlags.PositionProportional);

			AbsoluteLayout.SetLayoutBounds (Label2, new Rectangle (0.5, 0.71, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (Label2, AbsoluteLayoutFlags.PositionProportional);

			var contentView2 = new ContentView {
				Padding = new Thickness (10, 0, 10, 0),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 70,
				MinimumHeightRequest = 70
			};

			mainGrid.Children.Add (contentView2,2,0);
			Grid.SetColumnSpan(contentView2, 5);

			var titleGrid = new Grid {
				HeightRequest = 70,
				MinimumHeightRequest = 70,
				VerticalOptions = LayoutOptions.StartAndExpand,
				RowSpacing = 0,
				ColumnSpacing = 0
			};

			titleGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (50) });
			titleGrid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (20) });
			titleGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = GridLength.Auto });
			titleGrid.ColumnDefinitions.Add (new ColumnDefinition { Width = GridLength.Auto });

			Label titleLabel = new Label {
				TextColor = Color.White,
				FontSize = 24,
				HorizontalOptions = LayoutOptions.Center,
				LineBreakMode = LineBreakMode.TailTruncation,
				VerticalOptions = LayoutOptions.Center,
				Text = "location",
				HeightRequest = 50
			};

			if (EventsPage.languageIsGerman)
			{
				titleLabel.SetBinding(Label.TextProperty, new Binding("germanDisplayName"));
			}
			else {
				titleLabel.SetBinding(Label.TextProperty, new Binding("polishDisplayName"));
			}

			titleGrid.Children.Add (titleLabel, 0, 0);
			Grid.SetRowSpan (titleLabel, 2);

			Label locationLabel = new Label {
				TextColor = Color.Gray,
				FontSize = 12,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				LineBreakMode = LineBreakMode.TailTruncation,
				Text = "title",
				HeightRequest = 20
			};

			if (EventsPage.languageIsGerman)
			{
				locationLabel.SetBinding(Label.TextProperty, new Binding("locationGerman"));
			}
			else {
				locationLabel.SetBinding(Label.TextProperty, new Binding("locationPolish"));
			}

			titleGrid.Children.Add (locationLabel, 0, 1);
			Grid.SetRowSpan (locationLabel, 2);

			contentView2.Content = titleGrid;

			var contentView3 = new ContentView {
				Padding = new Thickness (5, 8, 5, 2),
				HorizontalOptions = LayoutOptions.EndAndExpand,
				HeightRequest = 70,
				MinimumWidthRequest = 60
			};

			mainGrid.Children.Add(contentView3, 7, 0);

//			var stackLayout2 = new StackLayout{ Orientation = StackOrientation.Horizontal };

//			var boxView1 = new BoxView {
//				WidthRequest = 1,
//				HeightRequest = 58,
//				BackgroundColor = Color.Gray,
//				VerticalOptions = LayoutOptions.Center
//			};

			var stackLayout2 = new StackLayout{Spacing = 7};

			contentView3.Content = stackLayout2;

			var stackLayout1 = new StackLayout {Spacing = 0, WidthRequest = 30};

			stackLayout2.Children.Add (stackLayout1);

			var Label3 = new Label {
				Text = "bis",
				TextColor = Color.Gray,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			if (!EventsPage.languageIsGerman)
			{
				Label3.Text = "do";
			}

			stackLayout1.Children.Add (Label3);

			var Label4 = new Label {
				Text = "18:00",
				TextColor = Color.Gray,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Label4.SetBinding(Label.TextProperty, new Binding("dateEnd", BindingMode.Default, new DateStringFromDateTimeConverter2()));

			stackLayout1.Children.Add (Label4);

			image = new Image{ Source = "star_gray.png", Aspect = Aspect.AspectFit, HeightRequest = 34, WidthRequest = 34, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

			stackLayout2.Children.Add (image);

			image.SetBinding (Image.SourceProperty, new Binding ("isFavorite", BindingMode.Default, new FavoriteToColorConverter ()));
			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.Tapped += (s, e) => {

				Boolean isFavorite = (Boolean)((Event)this.BindingContext).isFavorite;

				if (isFavorite) {

					((Event)this.BindingContext).isFavorite = false;
					SaveResource.convertEventToPreEvent();
					SaveResource.SaveResourceInXML();

				} else {

					((Event)this.BindingContext).isFavorite = true;
					SaveResource.convertEventToPreEvent();
					SaveResource.SaveResourceInXML();
				}

			};

			image.GestureRecognizers.Add (tapGestureRecognizer);

			View = mainContentView;

		}

	}

}