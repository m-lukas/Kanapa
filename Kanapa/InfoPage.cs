using System;
using Xamarin.Forms;

namespace Kanapa
{
	public class InfoPage : ContentPage
	{
		public InfoPage()
		{

			Title = "   Über";

			if (!EventsPage.languageIsGerman)
			{
				Title = "   O";
			}

			BackgroundImage = "Background_Kanapa.png";

			var mainstack = new StackLayout { Spacing = 0, HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.StartAndExpand, Orientation = StackOrientation.Vertical };

			var titleContenView = new ContentView { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Start, MinimumHeightRequest = 90, BackgroundColor = Color.FromHex("#E24944"), Padding = new Thickness(10, 10, 10, 10) };

			mainstack.Children.Add(titleContenView);

			var grid = new Grid { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, ColumnSpacing = 0, RowSpacing = 0 };

			titleContenView.Content = grid;

			var titlelabel = new Label { Text = "Kanapa", TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) + 10, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			grid.Children.Add(titlelabel, 0, 0);
			Grid.SetRowSpan(titlelabel, 3);

			var copyrightlabel = new Label { Text = "Copyright 2016 - Kanapa", TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))-2, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			grid.Children.Add(copyrightlabel, 0, 3);

			var projectlabel = new Label { Text = "Diese App ist ein Projekt von Lukas Müller", TextColor = Color.White, FontAttributes = FontAttributes.Italic, LineBreakMode = LineBreakMode.WordWrap, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))-4, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			grid.Children.Add(projectlabel, 0, 4);

			if (!EventsPage.languageIsGerman)
			{
				projectlabel.Text = "Ta aplikacja jest projekt Lukasza Müllera";
			}

			var PlaceHolderContentView1 = new ContentView { HeightRequest = 10, BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.Fill };

			mainstack.Children.Add(PlaceHolderContentView1);

			var homepageTitleContentView = new ContentView
			{
				BackgroundColor = Color.FromHex("#E24944"),
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 5, 10, 5)
			};

			mainstack.Children.Add(homepageTitleContentView);


			var homepageLabelTitle = new Label
			{
				Text = "Webseite",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2,
				LineBreakMode = LineBreakMode.NoWrap,
				VerticalOptions = LayoutOptions.Center
			};

			if (!EventsPage.languageIsGerman)
			{
				homepageLabelTitle.Text = "Strona gółwna";
			}

			homepageTitleContentView.Content = homepageLabelTitle;

			var hompageContentView = new ContentView
			{
				BackgroundColor = new Color(0, 0, 0, 0.5),
				Padding = new Thickness(8, 8, 8, 8)
			};

			mainstack.Children.Add(hompageContentView);

			var homepageLabel = new Label
			{
				Text = "kanapa-blog.org",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) - 4,
				LineBreakMode = LineBreakMode.WordWrap
			};

			hompageContentView.Content = homepageLabel;

			var tapGestureRecognizer2 = new TapGestureRecognizer();
			tapGestureRecognizer2.Tapped += (s, e) =>
			{
				Device.OpenUri(new Uri("http://kanapa-blog.org/"));
			};

			hompageContentView.GestureRecognizers.Add(tapGestureRecognizer2);

			var PlaceHolderContentView2 = new ContentView { HeightRequest = 10, BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.Fill };

			mainstack.Children.Add(PlaceHolderContentView2);

			var contactTitleContentView = new ContentView
			{
				BackgroundColor = Color.FromHex("#E24944"),
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 5, 10, 5)
			};

			mainstack.Children.Add(contactTitleContentView);


			var contactLabelTitle = new Label
			{
				Text = "Kontakt",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2,
				LineBreakMode = LineBreakMode.NoWrap,
				VerticalOptions = LayoutOptions.Center
			};

			contactTitleContentView.Content = contactLabelTitle;

			var contactContentView = new ContentView
			{
				BackgroundColor = new Color(0, 0, 0, 0.5),
				Padding = new Thickness(8, 8, 8, 8)
			};

			mainstack.Children.Add(contactContentView);

			var contactLabel = new Label
			{
				Text = "kanapablog.gr@gmail.com",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) - 4,
				LineBreakMode = LineBreakMode.WordWrap
			};

			contactContentView.Content = contactLabel;

			var PlaceHolderContentView3 = new ContentView { HeightRequest = 10, BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.Fill };

			mainstack.Children.Add(PlaceHolderContentView3);

			var licenseTitleContentView = new ContentView
			{
				BackgroundColor = Color.FromHex("#E24944"),
				HorizontalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 5, 10, 5)
			};

			mainstack.Children.Add(licenseTitleContentView);

			var licenseLabelTitle = new Label
			{
				Text = "Lizensen",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2,
				LineBreakMode = LineBreakMode.NoWrap,
				VerticalOptions = LayoutOptions.Center
			};

			if (!EventsPage.languageIsGerman)
			{
				licenseLabelTitle.Text = "Licencje";
			}

			licenseTitleContentView.Content = licenseLabelTitle;

			var scroll = new ScrollView { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, Orientation = ScrollOrientation.Vertical };

			mainstack.Children.Add(scroll);

			var licenseContentView = new ContentView { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.StartAndExpand, BackgroundColor = Color.FromHex("#F6F6F6"), Padding=new Thickness(10,10,10,10) };

			scroll.Content = licenseContentView;

			var stack = new StackLayout { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.StartAndExpand, Orientation = StackOrientation.Vertical, Spacing=5 };

			licenseContentView.Content = stack;

			var main1 = new Label { Text = "Kanapa is build using following software:", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start };

			stack.Children.Add(main1);

			var apache1 = new Label { Text = "Apache License 2.0:", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap,FontAttributes=FontAttributes.Bold ,FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start };

			stack.Children.Add(apache1);

			var apache2 = new Label { Text = "\nAndroid Code - Copyright 2005 Android Open Source Project\nAzure Mobile Services - Copyright 2015 Microsoft", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontSize = 10, FontAttributes=FontAttributes.Italic ,VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			stack.Children.Add(apache2);

			var apache3 = new Label { Text = "\nLicensed under the Apache License, Version 2.0 (the \"License\");you may not use this file except in compliance with the License.\nYou may obtain a copy of the License at\n\n    http://www.apache.org/licenses/LICENSE-2.0\n\nUnless required by applicable law or agreed to in writing, softwaredistributed under the License is distributed on an \"AS IS\" BASIS,\nWITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.See the License for the specific language governing permissions and\nlimitations under the License.", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontSize = 8, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			stack.Children.Add(apache3);

			var mit1 = new Label { Text = "MIT-License:", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start };

			stack.Children.Add(mit1);

			var mit2 = new Label { Text = "\nImageCirclePlugin - Copyright 2016 James Montemagno", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontSize = 10, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			stack.Children.Add(mit2);

			var mit3 = new Label { Text = "\nPermission is hereby granted, free of charge, to any person obtaining a copy\nof this software and associated documentation files (the \"Software\"), to deal\nin the Software without restriction, including without limitation the rights\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\ncopies of the Software, and to permit persons to whom the Software is\nfurnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all\ncopies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\nSOFTWARE.", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontSize = 8, FontAttributes = FontAttributes.Italic, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			stack.Children.Add(mit3);

			var cc1 = new Label { Text = "Creative-Commons-License:", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start };

			stack.Children.Add(cc1);

			var cc2 = new Label { Text = "\nsmall-n-flat Icons - Copyright 2014 Paomedia\nPeterskirche Goerlitz.jpg - Copyright 2007 Europastadt Goerlitz GmbH", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontSize = 10, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			stack.Children.Add(cc2);

			var cc3 = new Label { Text = "\nhttp://creativecommons.org/licenses/by/3.0/", TextColor = Color.Black, LineBreakMode = LineBreakMode.WordWrap, FontSize = 8, FontAttributes = FontAttributes.Italic, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center };

			stack.Children.Add(cc3);

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
				Device.OpenUri(new Uri("http://creativecommons.org/licenses/by/3.0/"));
			};

			cc3.GestureRecognizers.Add(tapGestureRecognizer);


			//var stack = new StackLayout { Spacing = 0, HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.StartAndExpand, Orientation = StackOrientation.Vertical };

			//scroll.Content = stack;

			//var contentView0 = new ContentView { BackgroundColor = new Color(0, 0, 0, 0.5), Padding = new Thickness(10, 10, 10, 10) };

			//stack.Children.Add(contentView0);

			//var titlelabel = new Label { Text = "Kanapa for Android", TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2, VerticalOptions = LayoutOptions.Center, HeightRequest = 25 };

			//contentView0.Content = labelCopyright;

			//var contentView1 = new ContentView { HeightRequest = 8, BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.Fill };

			//stack.Children.Add(contentView1);

			//var contentView2 = new ContentView
			//{
			//	BackgroundColor = Color.FromHex("#E24944"),
			//	HorizontalOptions = LayoutOptions.Fill,
			//	Padding = new Thickness(10, 5, 10, 5)
			//};

			//stack.Children.Add(contentView2);

			//var licenseLabelTitle = new Label
			//{
			//	Text = "Lizensen:",
			//	TextColor = Color.White,
			//	FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 2,
			//	LineBreakMode = LineBreakMode.NoWrap,
			//	VerticalOptions = LayoutOptions.Center
			//};

			//contentView2.Content = licenseLabelTitle;

			//var contentView3 = new ContentView { BackgroundColor = new Color(0, 0, 0, 0.5), Padding = new Thickness(10, 10, 10, 10) };

			//stack.Children.Add(contentView3);

			//var licenseLabel = new Label {
			//	Text = "Peterskirche Goerlitz.jpg \nCopyright (c) 2012 Europastadt Goerlitz GmbH\n\nLizenz: Creative-Commons-Lizenz",
			//	TextColor = Color.White,
			//	FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) - 2,
			//	LineBreakMode = LineBreakMode.WordWrap };

			//contentView3.Content = licenseLabel;

			//var contentView4 = new ContentView { BackgroundColor = Color.Transparent, HeightRequest = 8, HorizontalOptions = LayoutOptions.Fill};

			//stack.Children.Add(contentView4);



			this.Content = mainstack;

		}
	}
}
