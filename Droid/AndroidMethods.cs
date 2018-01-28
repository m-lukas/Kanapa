using System;
using Kanapa.Droid;
using Kanapa;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace Kanapa
{
	public class AndroidMethods : IMethods
	{
		public void CloseApp()
		{
			Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
		}
	}
}
