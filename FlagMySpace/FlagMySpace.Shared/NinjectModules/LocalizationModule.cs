using System;
using System.Collections.Generic;
using System.Text;
using FlagMySpace.Shared.Localization;
using FlagMySpace.Shared.ViewModels;
using Ninject.Modules;
using Xamarin.Forms;

namespace FlagMySpace.Shared.NinjectModules
{
    public class LocalizationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoginPageLocalizationProvider>().To<LoginPageLocalizationProvider>();

            if (Device.OS == TargetPlatform.Android)
            {
                Bind<ILocalize>().To<LocalizeAndroid>();
            }
        }
    }
}
