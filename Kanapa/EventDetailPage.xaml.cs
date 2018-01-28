using ImageCircle.Forms.Plugin.Abstractions;

using Xamarin.Forms;

namespace Kanapa
{
	public partial class EventDetailPage : ContentPage
	{

		public EventDetailPage ()
		{

			NavigationPage.SetHasBackButton(this, true);

			ToolbarItems.Clear();

			if (EventsPage.languageIsGerman)
			{

				this.ToolbarItems.Add(new ToolbarItem("Zum Kalender hinzufügen", "calender", async () =>
				 {

					var answer = await DisplayAlert("Kalendereintrag", "Möchtest du diese Veranstaltung in deinen persönlichen Kalender eintragen?", "Ja", "Nein");

					Event e = ((Event)this.BindingContext);

					 if (answer)
					 {

						 var enter = DependencyService.Get<IEnter>();
						 if (enter != null)
							 enter.Enter(e.germanDisplayName, e.dateStart, e.dateEnd, e.descriptionGerman, e.locationGerman);

					}

				 }));

			}
			else {

				this.ToolbarItems.Add(new ToolbarItem("Dodaj do kalendarza", "calender", async () =>
				 {

					 var answer = await DisplayAlert("kalendarz", "Checz dodawać to wydarzenie do twojego kalendarza?", "tak", "nie");

					 Event e = ((Event)this.BindingContext);

					 if (answer)
					 {

						 var enter = DependencyService.Get<IEnter>();
						 if (enter != null)
							 enter.Enter(e.polishDisplayName, e.dateStart, e.dateEnd, e.descriptionPolish, e.locationPolish);

					 }

				 }));

			}

			BackgroundImage = "Background_Kanapa.png";
			this.Icon = "kanapa_logo.png";
			InitializeComponent ();

			var scrollView = new ScrollView ();

			var mainStackLayout = new StackLayout {Spacing = 0};

			scrollView.Content = mainStackLayout;

			var contentView1 = new ContentView {HeightRequest = 120, VerticalOptions = LayoutOptions.Start, BackgroundColor = Color.Gray};

			mainStackLayout.Children.Add (contentView1);

			var absoluteLayout = new AbsoluteLayout ();

			contentView1.Content = absoluteLayout;

			var image = new Image {
				Source = "Example.jpg",
				HeightRequest = 120,
				WidthRequest = 400,
				Aspect = Aspect.AspectFill,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Fill
			};

			image.SetBinding(Image.SourceProperty, new Binding("imageUrl", BindingMode.Default, new ImageSoureConverter()));

			absoluteLayout.Children.Add (image);
		
			AbsoluteLayout.SetLayoutBounds (image, new Rectangle (0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (image, AbsoluteLayoutFlags.PositionProportional);

			var circleImage = new CircleImage {
				Aspect = Aspect.AspectFit,
				FillColor = (Color.FromHex ("#E24944")),
				HeightRequest = 55,
				WidthRequest = 55,
				BorderColor = Color.FromHex ("#E24944"),
				BorderThickness = 2
			};

			absoluteLayout.Children.Add (circleImage);

			AbsoluteLayout.SetLayoutBounds (circleImage, new Rectangle (0.02, 0.9, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags (circleImage, AbsoluteLayoutFlags.PositionProportional);

			var Label1 = new Label {
				Text = "6.",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
			};

			absoluteLayout.Children.Add (Label1);

    		Label1.SetBinding (Label.TextProperty, new Binding ("dateStart", BindingMode.Default, new DayFromDayTimeConverter ()));
			Label1.SetBinding(Label.FontSizeProperty, new Binding("dateStart", BindingMode.Default, new SizeFromLenghtConverter()));

			var Label2 = new Label {
				Text = "FEB",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label))
			};

			absoluteLayout.Children.Add (Label2);

			Label2.SetBinding (Label.TextProperty, new Binding ("dateStart", BindingMode.Default, new shortMonthFromDayTimeConverter ()));

			AbsoluteLayout.SetLayoutBounds (Label1, new Rectangle (0.065, 0.7, -1, -1));
			AbsoluteLayout.SetLayoutFlags(Label1, AbsoluteLayoutFlags.PositionProportional);

			AbsoluteLayout.SetLayoutBounds (Label2, new Rectangle (0.05, 0.86, -1, -1));
			AbsoluteLayout.SetLayoutFlags(Label2, AbsoluteLayoutFlags.PositionProportional);

			var contentView2 = new ContentView{BackgroundColor = Color.FromHex ("#E24944"), Padding = new Thickness(10,5,10,5) };

			mainStackLayout.Children.Add (contentView2);

			var titlegrid = new Grid { HorizontalOptions = LayoutOptions.Fill };

			titlegrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
			titlegrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });

			contentView2.Content = titlegrid;

			var title = new Label {
				Text = "Title",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))+1,
				LineBreakMode = LineBreakMode.WordWrap
			};

			if (EventsPage.languageIsGerman)
			{
				title.SetBinding(Label.TextProperty, new Binding("germanDisplayName"));
			}
			else {
				title.SetBinding(Label.TextProperty, new Binding("polishDisplayName"));
			}

			titlegrid.Children.Add(title,0,0);
			Grid.SetColumnSpan(title, 7);

			var favoriteimage = new Image { Source = "star_gray.png", Aspect = Aspect.AspectFit, HeightRequest = 34, WidthRequest = 34, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End };

			titlegrid.Children.Add(favoriteimage, 7, 0);

			favoriteimage.SetBinding(Image.SourceProperty, new Binding("isFavorite", BindingMode.Default, new FavoriteToColorConverter()));
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{

				bool isFavorite = (bool)((Event)this.BindingContext).isFavorite;

				if (isFavorite)
				{

					((Event)this.BindingContext).isFavorite = false;
					SaveResource.convertEventToPreEvent();
					SaveResource.SaveResourceInXML();

				}
				else {

					((Event)this.BindingContext).isFavorite = true;
					SaveResource.convertEventToPreEvent();
					SaveResource.SaveResourceInXML();
				}

			};

			favoriteimage.GestureRecognizers.Add(tapGestureRecognizer);

			var contentView3 = new ContentView {
				HeightRequest = 8,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Fill
			};

			mainStackLayout.Children.Add (contentView3);

			var contentView4 = new ContentView {
				BackgroundColor = Color.FromHex ("#E24944"),
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10,5,10,5)
			};

			mainStackLayout.Children.Add (contentView4);

			var descriptiontitle = new Label {
				Text = "Beschreibung",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label))+2,
				LineBreakMode = LineBreakMode.NoWrap,
				VerticalOptions = LayoutOptions.Center
			};

			if (!EventsPage.languageIsGerman)
			{
				descriptiontitle.Text = "Opis";
			}

			contentView4.Content = descriptiontitle;

			var contentView5 = new ContentView{BackgroundColor = new Color(0,0,0,0.5), Padding = new Thickness(10,10,10,10) };

			mainStackLayout.Children.Add (contentView5);

			var description = new Label {
				Text = "description",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label))-2,
				LineBreakMode = LineBreakMode.WordWrap
			};

			if (EventsPage.languageIsGerman)
			{
				description.SetBinding(Label.TextProperty, new Binding("descriptionGerman"));
			}
			else {
				description.SetBinding(Label.TextProperty, new Binding("descriptionPolish"));
			}

			contentView5.Content = description;

			var contentView5_1 = new ContentView
			{
				HeightRequest = 8,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Fill
			};

			mainStackLayout.Children.Add(contentView5_1);

			var contentView6 = new ContentView {HorizontalOptions = LayoutOptions.Fill};

			mainStackLayout.Children.Add(contentView6);

			var grid = new Grid { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Center, ColumnSpacing = 3, RowSpacing = 3 };

			contentView6.Content = grid;

			var contentView6_1 = new ContentView
			{
				BackgroundColor = Color.FromHex("#E24944"),
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 5, 10, 5),
				HeightRequest = 22
			};

			grid.Children.Add(contentView6_1, 0, 0);

			Grid.SetColumnSpan(contentView6_1, 2);

			var label1 = new Label { Text = "Von", TextColor = Color.White, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

			if (!EventsPage.languageIsGerman)
			{
				label1.Text = "Od";
			}

			grid.Children.Add(label1, 0, 0);

			var label2 = new Label { Text = "Bis", TextColor = Color.White, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

			if (!EventsPage.languageIsGerman)
			{
				label2.Text = "Do";
			}

			grid.Children.Add(label2, 1, 0);

			var bv3 = new BoxView { BackgroundColor = new Color(0, 0, 0, 0.5), HeightRequest = 15 };
			var label3 = new Label { Text = "1.1.2000", TextColor = Color.White, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))-2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

			label3.SetBinding(Label.TextProperty, new Binding("dateStart", BindingMode.Default, new DateStringFromDateTimeConverter()));

			grid.Children.Add(bv3, 0, 1);
			grid.Children.Add(label3, 0, 1);

			var bv4 = new BoxView { BackgroundColor = new Color(0, 0, 0, 0.5), HeightRequest = 15 };
			var label4 = new Label { Text = "1.1.2000", TextColor = Color.White, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))-2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

			label4.SetBinding(Label.TextProperty, new Binding("dateEnd", BindingMode.Default, new DateStringFromDateTimeConverter()));

			grid.Children.Add(bv4, 1, 1);
			grid.Children.Add(label4, 1, 1);

			var bv5 = new BoxView { BackgroundColor = new Color(0, 0, 0, 0.5), HeightRequest = 15 };
			var label5 = new Label { Text = "18 Uhr", TextColor = Color.White, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))-2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

			label5.SetBinding(Label.TextProperty, new Binding("dateStart", BindingMode.Default, new TimeFromDateTimeConverter()));

			grid.Children.Add(bv5, 0, 2);
			grid.Children.Add(label5, 0, 2);

			var bv6 = new BoxView { BackgroundColor = new Color(0, 0, 0, 0.5), HeightRequest = 15 };
			var label6 = new Label { Text = "7 Uhr", TextColor = Color.White, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))-2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

			label6.SetBinding(Label.TextProperty, new Binding("dateEnd", BindingMode.Default, new TimeFromDateTimeConverter()));

			grid.Children.Add(bv6, 1, 2);
			grid.Children.Add(label6, 1, 2);

			var contentView6_2 = new ContentView
			{
				HeightRequest = 8,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Fill
			};

			mainStackLayout.Children.Add(contentView6_2);

			var contentView7 = new ContentView
			{
				BackgroundColor = Color.FromHex("#E24944"),
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 5, 10, 5)
			};

			mainStackLayout.Children.Add(contentView7);

			var locationlabel = new Label
			{
				Text = "Location",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2,
				LineBreakMode = LineBreakMode.NoWrap,
				VerticalOptions = LayoutOptions.Center
			};

			if (!EventsPage.languageIsGerman)
			{
				locationlabel.Text = "Miejsce";
			}

			contentView7.Content = locationlabel;

			var contentView8 = new ContentView { BackgroundColor = new Color(0, 0, 0, 0.5), Padding = new Thickness(10, 10, 10, 10) };

			mainStackLayout.Children.Add(contentView8);

			var location = new Label
			{
				Text = "location",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) - 2,
				LineBreakMode = LineBreakMode.WordWrap
			};

			if (EventsPage.languageIsGerman)
			{
				location.SetBinding(Label.TextProperty, new Binding("locationGerman"));
			}
			else {
				location.SetBinding(Label.TextProperty, new Binding("locationPolish"));
			}

			contentView8.Content = location;

			mainStackLayout.Children.Add(contentView8);

			Content = scrollView;

		}

	}
}

