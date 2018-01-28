using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;

namespace Kanapa
{
	public class EventManager
	{
		
		public static async Task<ObservableCollection<Event>> GetEventsAsync()
		{

			string ApplicationURL = @"http://kanapa.azurewebsites.net";

			IMobileServiceTable<Event> eventTable;
			MobileServiceClient client;

			client = new MobileServiceClient(ApplicationURL);
			eventTable = client.GetTable<Event>();

			try
			{
				IEnumerable<Event> items = await eventTable.ToEnumerableAsync();
				return new ObservableCollection<Event>(items);

			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				System.Diagnostics.Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(@"Sync error: {0}", e.Message);
			}

			return null;

		}

	}
}
