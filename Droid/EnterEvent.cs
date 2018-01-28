using System;
using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Java.Util;

using Kanapa.Droid;

[assembly: Dependency(typeof(EnterEvent))]

namespace Kanapa.Droid
{
	public class EnterEvent : IEnter
	{

		public bool Enter(string name, DateTime dateStart, DateTime dateEnd, string description, string location)
		{

			ContentValues eventValues = new ContentValues ();

			eventValues.Put (CalendarContract.Events.InterfaceConsts.CalendarId,
				1);
			eventValues.Put (CalendarContract.Events.InterfaceConsts.Title,
				name);
			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventLocation,
				location);
			eventValues.Put (CalendarContract.Events.InterfaceConsts.Description,
				description);
			eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtstart,
				GetDateTimeMS (dateStart.Year, dateStart.Month-1, dateStart.Day, dateStart.Hour, dateStart.Minute));
			eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtend,
				GetDateTimeMS (dateEnd.Year, dateEnd.Month-1, dateEnd.Day, dateEnd.Hour, dateEnd.Minute));

			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, 
				"UTC");
			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, 
				"UTC");

			var uri = Forms.Context.ContentResolver.Insert (CalendarContract.Events.ContentUri, eventValues);

			System.Diagnostics.Debug.WriteLine(name + "\t" + dateStart + "\t" + dateEnd + "\t" + description);
			return true;
			
		}

		long GetDateTimeMS (int yr, int month, int day, int hr, int min)
		{
			Calendar c = Calendar.GetInstance (Java.Util.TimeZone.Default);

			c.Set (Calendar.DayOfMonth, day);
			c.Set (Calendar.HourOfDay, hr);
			c.Set (Calendar.Minute, min);
			c.Set (Calendar.Month, month);
			c.Set (Calendar.Year, yr);

			return c.TimeInMillis;
		}
			
	}
}

