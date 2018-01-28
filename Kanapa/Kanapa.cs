using System;

using Xamarin.Forms;

namespace Kanapa
{
	public class App : Application
	{
		public App ()
		{

			var fileService = DependencyService.Get<ISaveAndLoad>();

			if (fileService.FileExists("language.txt"))
			{

				if (fileService.FileExists("events.xml"))
				{
					LoadResource.LoadResourceFromXML();
					EventsPage.events = LoadResource.convertEvents();
					string language = fileService.LoadText("language.txt");
					if (language.Equals("german"))
					{
						EventsPage.languageIsGerman = true;
					}
					else {
						EventsPage.languageIsGerman = false;
					}
					EventsPage.firstTimeOpened = false;
					MainPage = new NavigationPage(new myCarouselPage());
				}
				else {
					string language = fileService.LoadText("language.txt");
					if (language.Equals("german"))
					{
						EventsPage.languageIsGerman = true;
					}
					else {
						EventsPage.languageIsGerman = false;
					}
					EventsPage.firstTimeOpened = true;
					MainPage = new NavigationPage(new myCarouselPage());
				}

			}
			else {

				if (fileService.FileExists("events.xml"))
				{
					LoadResource.LoadResourceFromXML();
					EventsPage.events = LoadResource.convertEvents();
					EventsPage.firstTimeOpened = false;
					MainPage = new NavigationPage(new LanguagePage());
				}
				else {
					EventsPage.firstTimeOpened = true;
					MainPage = new NavigationPage(new LanguagePage());
				}

			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			SaveResource.convertEventToPreEvent();
			SaveResource.SaveResourceInXML();
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

