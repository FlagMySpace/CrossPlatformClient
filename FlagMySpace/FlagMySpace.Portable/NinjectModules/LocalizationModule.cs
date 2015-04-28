using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.ViewModels;
using Ninject.Modules;
using Xamarin.Forms;

namespace FlagMySpace.Portable.NinjectModules
{
    public class LocalizationModule : NinjectModule
    {
        public override void Load()
        {

            if (Device.OS == TargetPlatform.Android)
            {
            }
        }
    }
}
