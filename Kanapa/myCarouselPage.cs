using System;

using Xamarin.Forms;

namespace Kanapa
{
	public class myCarouselPage : CarouselPage
	{

		public myCarouselPage()
		{

			if (EventsPage.languageIsGerman)
			{
				Title = "Events";
			}
			else {
				Title = "Wydarzenia";
			}

			this.Children.Add(new MapPage());
			this.Children.Add(new EventsPage());
			this.Children.Add(new CalenderPage());

			NavigationPage.SetHasBackButton(this, false);
			NavigationPage.SetHasNavigationBar(this, true);

			CurrentPage = this.Children[1];

			ToolbarItems.Clear();

			this.ToolbarItems.Add(new ToolbarItem("pageindicator", "pageindicator_middle.png", () =>
			{

				CurrentPage = this.Children[2];

			}));

		}

		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();

			NavigationPage.SetTitleIcon(this, "kanapa_logo.png");
			this.Title = CurrentPage.Title;

			ToolbarItems.Clear();

			if (Title.Equals("   Events") || Title.Equals("   Wydarzenia"))
			{

				ToolbarItems.Clear();

				this.ToolbarItems.Add(new ToolbarItem("pageindicator", "pageindicator_middle.png", () =>
				{

					CurrentPage = this.Children[2];

				}));

			}
			else if (Title.Equals("   Kalender") || Title.Equals("   Kalendarz"))
			{

				ToolbarItems.Clear();

				this.ToolbarItems.Add(new ToolbarItem("pageindicator", "pageindicator_right.png", () =>
				{

					CurrentPage = this.Children[0];

				}));


			}
			else if (Title.Equals("   Karte") || Title.Equals("   Mapa"))
			{

				ToolbarItems.Clear();

				this.ToolbarItems.Add(new ToolbarItem("pageindicator", "pageindicator_left.png", () =>
				{

					CurrentPage = this.Children[1];

				}));

			}

		}
	}
}
