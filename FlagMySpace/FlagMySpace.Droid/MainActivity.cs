using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FlagMySpace.Bootstrap;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FlagMySpace.Droid
{
    [Activity(Label = "FlagMySpace", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            var bootstrapper = new NinjectBoostrapper();

            LoadApplication(new App(bootstrapper));
        }
    }
}

