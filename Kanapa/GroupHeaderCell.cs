using System;
using ImageCircle.Forms.Plugin.Abstractions;

using Xamarin.Forms;

namespace Kanapa
{
	public class GroupHeaderCell : ViewCell
	{
		public GroupHeaderCell ()
		{

			var mainContentView = new ContentView{Padding = new Thickness(0,2,0,1), HeightRequest=75, BackgroundColor = Color.Transparent};

			View = mainContentView;

			var contentView = new ContentView {Padding = new Thickness(10,0,10,0), HeightRequest=75, BackgroundColor = Color.FromHex ("#E24944")};

			mainContentView.Content = contentView;

			var stackLayout = new StackLayout{Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill, Spacing = 10 };

			contentView.Content = stackLayout;

			var circleImageLayout = new AbsoluteLayout ();

			stackLayout.Children.Add (circleImageLayout);

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
				Text = "20.",
				TextColor = Color.White,
				FontSize = 28
			};

			circleImageLayout.Children.Add (Label1);

			Label1.SetBinding (Label.TextProperty, new Binding ("Date", BindingMode.Default, new DayFromDayTimeConverter ()));

			AbsoluteLayout.SetLayoutBounds (circleImage, new Rectangle (0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (circleImage, AbsoluteLayoutFlags.PositionProportional);

			AbsoluteLayout.SetLayoutBounds (Label1, new Rectangle (0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (Label1, AbsoluteLayoutFlags.PositionProportional);

			var Label2 = new Label {
				Text = "FEBRUAR",
				TextColor = Color.White,
				FontSize = 24,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand
			};

			stackLayout.Children.Add (Label2);

			Label2.SetBinding (Label.TextProperty, new Binding ("Date", BindingMode.Default, new MonthFromDayTimeConverter ()));

			var Label3 = new Label {
				Text = "| MONTAG",
				TextColor = Color.White,
				FontSize = 24,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.End
			};

			stackLayout.Children.Add (Label3);

			Label3.SetBinding (Label.TextProperty, new Binding ("Date", BindingMode.Default, new DayOfWeekFromDateTimeConverter ()));

		}
	}
}