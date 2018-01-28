using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;

namespace Kanapa
{
	public partial class EventsPage : ContentPage
	{

		public static ObservableCollection<Event> events = new ObservableCollection<Event>();
		public static ObservableCollection<Group> groupedEvents = new ObservableCollection<Group>();
		public static Dictionary<Image, string> favoriteImages = new Dictionary<Image, string>();
		public static ObservableCollection<Event> recommendedEvents = new ObservableCollection<Event>();
		public static bool languageIsGerman = true;
		public static bool firstTimeOpened = true;
		public static bool eventsHasBeenAdded = false;
		public static bool b = false;
		public static int i = 0;

		public EventsPage()
		{

			InitializeComponent();
			EventsList.ItemsSource = groupedEvents;
			AbsoluteLayout.SetLayoutBounds(activityIndicator, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags(activityIndicator, AbsoluteLayoutFlags.PositionProportional);
			absoluteLayout.Children.Add(activityIndicator);
			BackgroundImage = "Background_Kanapa.png";

			if (EventsPage.languageIsGerman)
			{
				Title = "   Events";
			}
			else {
				Title = "   Wydarzenia";
			}

			var template = new DataTemplate(typeof(EventCell));
			var headerTemplate = new DataTemplate(typeof(GroupHeaderCell));

			EventsList.IsGroupingEnabled = true;
			EventsList.ItemTemplate = template;
			EventsList.GroupHeaderTemplate = headerTemplate;
			EventsList.RowHeight = 85;
			EventsList.ItemTapped += this.Tapped;
			EventsList.IsPullToRefreshEnabled = true;
			EventsList.Refreshing += this.onRefresh;

			//eventsCarousel.ItemsSource = recommendedEvents;
			events = Methods.sortEvents(events);
			groupedEvents = Methods.groupEvents(events);             
			getOnlineEvents();

		}

		async void Tapped(object sender, ItemTappedEventArgs e)
		{

			await Navigation.PushAsync(new EventDetailPage { BindingContext = e.Item as Event });
			((ListView)sender).SelectedItem = null;

		}

		async void onRefresh(object sender, EventArgs e)
		{

			await getOnlineEvents();
			((ListView)sender).IsRefreshing = false;

		}

		public async Task<bool> getOnlineEvents()
		{

			ObservableCollection<Event> o;

			o = await EventManager.GetEventsAsync();

			if (o != null)
			{

				//has internet-connection
				ObservableCollection<Event> ob = events;
				ObservableCollection<Group> ov;

				foreach (Event e in o)
				{

					bool bo = false;

					foreach (Event ev in events)
					{
						if (e.id.Equals(ev.id))
						{
							bo = true;
						}
					}

					if (!bo)
					{
						ob.Add(e);
					}

				}

				ob = Methods.sortEvents(ob);
				ov = Methods.groupEvents(ob);

				events = ob;
				groupedEvents = ov;

				absoluteLayout.Children.Remove(activityIndicator);

				EventsList.ItemsSource = null;
				EventsList.ItemsSource = groupedEvents;

				SaveResource.convertEventToPreEvent();
				SaveResource.SaveResourceInXML();

				foreach (Event eve in events)
				{
					if (DateTime.Compare(DateTime.UtcNow, eve.dateEnd) <= 0 && DateTime.Compare(DateTime.UtcNow, eve.dateStart) >= 0 || (eve.dateStart.Day == DateTime.UtcNow.Day && eve.dateStart.Month == DateTime.UtcNow.Month && eve.dateStart.Year == DateTime.UtcNow.Year))
					{
						var position = new Position(eve.x, eve.y); // Latitude, Longitude
						var pin = new Pin
						{
							Type = PinType.Place,
							Position = position,
							Label = eve.germanDisplayName,
							Address = eve.locationGerman
						};
						MapPage.map.Pins.Add(pin);
					}
				}

			}
			else {

				//has no internet-connection
				EventsList.ItemsSource = null;
				EventsList.ItemsSource = groupedEvents;

				if (events.Count == 0)
				{
					if (languageIsGerman)
					{
						await DisplayAlert("Keine Internetverbindung!", "Die Events müssen beim ersten Start der App online abgerufen werden. Bitte schließe die App und starte sie mit einer aktiven Internetverbindung erneut.", "App schließen");
					}
					else {
						await DisplayAlert("Brak połączenia z internetem!", "Wydarzenia muszą byc dostępne online prszy pierwszym otwarciu aplikacji. Proszę zamkni aplikacje i uruchom ponownie z aktiwnym dostępu do interneta.", "Zamknji aplikacje");
					}
					DependencyService.Get<IMethods>().CloseApp();
				}
				else {
					if (languageIsGerman)
					{
						await DisplayAlert("Keine Internetverbindung!", "Events wurden aus dem Speicher geladen.", "Ok");
					}
					else {
						await DisplayAlert("Brak połączenia z internetem!", "Wydarzenie byli ładowane z pamięći.", "Ok");
					}
					absoluteLayout.Children.Remove(activityIndicator);
				}

			}

			return true;

		}

		public void addEvents(ObservableCollection<Event> o)
		{

			ObservableCollection<Event> ob = events;
			ObservableCollection<Group> ov;

			foreach (Event e in o)
			{

				bool bo = false;

				foreach (Event ev in events)
				{
					if (e.id.Equals(ev.id))
					{
						bo = true;
					}
				}

				if (!bo)
				{
					ob.Add(e);
				}

			}

			ob = Methods.sortEvents(ob);
			ov = Methods.groupEvents(ob);

			events = ob;
			groupedEvents = ov;

			absoluteLayout.Children.Remove(activityIndicator);

			EventsList.ItemsSource = null;
			EventsList.ItemsSource = groupedEvents;

			SaveResource.convertEventToPreEvent();
			SaveResource.SaveResourceInXML();
		}

	}
}