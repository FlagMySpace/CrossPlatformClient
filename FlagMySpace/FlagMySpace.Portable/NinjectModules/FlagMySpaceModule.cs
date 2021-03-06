﻿using Acr.UserDialogs;
using FlagMySpace.Agnostic.Error;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Portable.IoC;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.Localization.LoginPageLocalization;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels;
using FlagMySpace.Portable.ViewModels.LoginPageViewModel;
using FlagMySpace.Portable.ViewModels.RegisterPageViewModel;
using Ninject.Modules;
using Xamarin.Forms;

namespace FlagMySpace.Portable.NinjectModules
{
    public class FlagMySpaceModule : NinjectModule
    {
        public override void Load()
        {
            // View Factory
            Bind<IIoC>().To<IoCNinject>();
            Bind<IViewFactory>().To<ViewFactory.ViewFactory>().InSingletonScope();

            // Localization
            Bind<ILocalize>().ToConstant(DependencyService.Get<ILocalize>());
            Bind<ILoginPageLocalization>().To<LoginPageLocalization>();

            // Common
            Bind<IErrorService>().To<ErrorService>().InSingletonScope();

            // User dialog
            Bind<IUserDialogs>().ToConstant(UserDialogs.Instance).InSingletonScope();

            // View Model
            Bind<ILoginPageViewModel>().To<LoginPageViewModel>();
            Bind<IRegisterPageViewModel>().To<RegisterPageViewModel>();
        }
    }
}
