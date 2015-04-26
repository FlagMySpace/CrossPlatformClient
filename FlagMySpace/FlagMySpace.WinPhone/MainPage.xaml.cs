using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using FlagMySpace.Shared.Bootstrap;

namespace FlagMySpace.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Forms.Init();

            var bootstrapper = new NinjectBoostrapper();
            LoadApplication(new FlagMySpace.App(bootstrapper));
        }
    }
}