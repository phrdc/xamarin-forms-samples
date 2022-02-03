using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LoginNavigation.Droid
{
	[Activity (Label = "LoginNavigation.Droid", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}

        // REF: https://www.dylanberry.com/2020/02/20/how-to-confirm-exit-in-android-with-xamarin-forms/
        // Confirm with dialog
        public override void OnBackPressed()
        {
            if (((App)App.Current).PromptToConfirmExit)
            {
                using (var alert = new AlertDialog.Builder(this))
                {
                    alert.SetTitle("Confirm Exit");
                    alert.SetMessage("Are you sure you want to exit?");
                    alert.SetPositiveButton("Yes", (sender, args) => 
                    {
                        //FinishAffinity(); 
                        Android.OS.Process.KillProcess(Android.OS.Process.MyPid());

                    }); // inform Android that we are done with the activity
                    alert.SetNegativeButton("No", (sender, args) => { }); // do nothing

                    var dialog = alert.Create();
                    dialog.Show();
                }
                return;
            }
            base.OnBackPressed();
        }

        // Confirm with toast + back button
        //bool _isBackPressed = false;
        //public override void OnBackPressed()
        //{
        //    var app = (App)App.Current;
        //    if (app.PromptToConfirmExit)
        //    {
        //        if (_isBackPressed)
        //        {
        //            FinishAffinity(); // inform Android that we are done with the activity
        //            return;
        //        }

        //        _isBackPressed = true;
        //        Toast.MakeText(this, "Press back again to exit", ToastLength.Short).Show();

        //        // Disable back to exit after 2 seconds.
        //        new Handler().PostDelayed(() => { _isBackPressed = false; }, 2000);
        //        return;
        //    }
        //    base.OnBackPressed();
        //}
    }
}

