using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Kanapa
{
	public class Event : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") 
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private bool _isFavorite;

		public string id { get; set; }
		public string germanDisplayName{ get; set; }
		public string polishDisplayName{ get; set; }
		public string locationGerman{ get; set;}
		public string locationPolish{ get; set; }
		public DateTime dateStart{ get; set; }
		public DateTime dateEnd { get; set; }
		public string imageUrl{ get; set; }
		public string descriptionGerman{ get; set;}
		public string descriptionPolish { get; set; }
		public Boolean isFavorite { 
			get { return _isFavorite; }
			set
			{
				if (_isFavorite != value)
				{
					_isFavorite = value;
					NotifyPropertyChanged("isFavorite");
				}
			} }
		public float x{ get; set; }
		public float y { get; set; }

	}

}