using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Kanapa.Droid
{
	[Activity (Label = "Kanapa", Icon = "@drawable/kanapa_logo", Theme="@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init ();

			global::Xamarin.Forms.Forms.Init (this, bundle);

			Xamarin.FormsMaps.Init(this, bundle);

			LoadApplication (new App ());
		}
	}
}

