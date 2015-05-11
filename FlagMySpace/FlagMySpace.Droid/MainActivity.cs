using System.ComponentModel;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FlagMySpace.Portable;
using Xamarin.Forms;
using XLabs.Forms;

namespace FlagMySpace.Droid
{
    [Localizable(false), Activity(Label = "FlagMySpace", Icon = "@drawable/icon", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            if (UserDialogs.Instance == null)
            {
                UserDialogs.Init(() => (Activity)Forms.Context);
            }

            LoadApplication(new App());
        }
    }
}

