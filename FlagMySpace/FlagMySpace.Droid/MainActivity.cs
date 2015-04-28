using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FlagMySpace.Portable;
using FlagMySpace.Portable.Bootstrap;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FlagMySpace.Shared
{
    [Activity(Label = "FlagMySpace", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            if (UserDialogs.Instance == null)
            {
                UserDialogs.Init(() => (Activity) Forms.Context);
            }

            LoadApplication(new App());
        }
    }
}

