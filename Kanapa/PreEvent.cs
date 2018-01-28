using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Kanapa
{
	public class PreEvent
	{

		public string id { get; set; }
		public string germanDisplayName{ get; set; }
		public string polishDisplayName{ get; set; }
		public string locationGerman{ get; set;}
		public string locationPolish { get; set; }
		public string dateStart{ get; set; }
		public string dateEnd { get; set; }
		public string imageUrl{ get; set; }
		public string descriptionGerman{ get; set;}
		public string descriptionPolish { get; set; }
		public string isFavorite{ get; set;}
		public float x{ get; set; }
		public float y{ get; set; }

	}

}