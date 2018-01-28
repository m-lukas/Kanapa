using System.Collections.ObjectModel;
using System.Collections.Generic;

using System;

namespace Kanapa
{
	public class Group : ObservableCollection<Event>
	{
		public DateTime Date { get; private set; }        

		public Group(DateTime date)
		{
			this.Date = date;                   
		}
	}
}
