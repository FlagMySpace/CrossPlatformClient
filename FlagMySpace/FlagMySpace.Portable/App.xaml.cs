using System.ComponentModel;
using FlagMySpace.Portable.Bootstrap;
using Xamarin.Forms;

namespace FlagMySpace.Portable
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var bootstrapper = new NinjectBoostrapper();
            bootstrapper.Run(this);
        }
    }
}
