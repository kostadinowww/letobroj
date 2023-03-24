using Android.App;
using Android.Widget;
using Android.OS;
using System;
using AndroidX.Work;
using Java.Interop;
using Android.Views;

namespace BulgarskiLetobroj
{
	/// <summary>
	/// Main class of the application. Shows the instructions and does nothing more.
	/// </summary>
	[Activity(Label = "Български Лѣтоброй", MainLauncher = true, Icon = "@drawable/icon", Exported = true)]
	public class MainActivity : Activity
	{
		/// <summary>
		/// Shows the instructions screen.
		/// </summary>
		/// <param name="savedInstanceState">The bundle state</param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			var btn = FindViewById<Button>(Resource.Id.closeButton);
			btn.Click += (s, e) =>
			{
				Finish();
			};
		}
	}
}