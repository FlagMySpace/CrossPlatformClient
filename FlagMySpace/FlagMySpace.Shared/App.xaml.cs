using System.ComponentModel;
using FlagMySpace.Shared.Bootstrap;
using Parse;
using Xamarin.Forms;

namespace FlagMySpace.Shared
{
    public partial class App : Application
    {
        [Localizable(false)]
        public App(Bootstrapper bootstrapper)
        {
            InitializeComponent();
            bootstrapper.Run(this);
            ParseClient.Initialize("L3POUewF4K1RgkRtKcZTDLne4Zp2kCgwQUmeW0Ru", "5qgD6FO6sAR4NWN5FehNtuaGBqHXIikQSg7yj1fu");
        }
    }
}
