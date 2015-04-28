using Acr.UserDialogs;
using FlagMySpace.Portable.Bootstrap;
using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace FlagMySpace.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Forms.Init();

            if (UserDialogs.Instance == null)
            {
                UserDialogs.Init();
            }

            LoadApplication(new FlagMySpace.Portable.App());
        }
    }
}