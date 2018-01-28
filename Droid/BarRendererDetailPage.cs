using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Kanapa.EventDetailPage), typeof(Kanapa.Droid.BarRendererDetailPage))]
namespace Kanapa.Droid
{
	public class BarRendererDetailPage : PageRenderer
	{
		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);
			var actionBar = ((Activity)Context).ActionBar;
			actionBar.SetDisplayShowTitleEnabled (true);

		}
	}
}