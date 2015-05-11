using System;
using Acr.UserDialogs;
using FlagMySpace.Agnostic.EventAggregator;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Agnostic.Models.PersonModel;
using FlagMySpace.Agnostic.Models.SpaceModel;
using FlagMySpace.Agnostic.Repositories.PersonRepository;
using FlagMySpace.Agnostic.Repositories.SpaceRepository;
using FlagMySpace.Agnostic.Services.ErrorService;
using FlagMySpace.Agnostic.Services.LoginService;
using FlagMySpace.Agnostic.Services.RegisterService;
using FlagMySpace.Agnostic.Services.SpaceService;
using FlagMySpace.Agnostic.Utilities.EmailValidatorUtility;
using FlagMySpace.Agnostic.Utilities.PasswordValidatorUtility;
using FlagMySpace.Agnostic.Utilities.UsernameValidatorUtility;
using FlagMySpace.Portable.IoC;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.Localization.LoginPageLocalization;
using FlagMySpace.Portable.Localization.RegisterPageLocalization;
using FlagMySpace.Portable.Pages;
using FlagMySpace.Portable.Pages.HomePage;
using FlagMySpace.Portable.Pages.LoginPage;
using FlagMySpace.Portable.Pages.RegisterPage;
using FlagMySpace.Portable.Pages.StreamPage;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels;
using FlagMySpace.Portable.ViewModels.HomePageViewModel;
using FlagMySpace.Portable.ViewModels.LoginPageViewModel;
using FlagMySpace.Portable.ViewModels.RegisterPageViewModel;
using FlagMySpace.Portable.ViewModels.StreamPageViewModel;
using SimpleInjector;
using Xamarin.Forms;

namespace FlagMySpace.Portable.Bootstrap
{
    public class SimpleInjectorBootstrapper : BootstrapperBase
    {
        /// <exception cref="ActivationException">Thrown when there are errors resolving the service instance.</exception>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected override IIoC ConfigureContainer()
        {
            var container = new Container();
            #region Event Aggregator
            container.RegisterSingle<IEventAggregator, EventAggregator>();
            #endregion

            #region IoC

            container.RegisterSingle<IIoC, IoCSimpleContainer>();

            #endregion

            #region View Factory
            container.RegisterSingle<IViewFactory, ViewFactory.ViewFactory>();
            #endregion

            #region Localization
            container.Register(() => DependencyService.Get<ILocalize>());
            container.Register<ILoginPageLocalization, LoginPageLocalization>();
            container.Register<IRegisterPageLocalization, RegisterPageLocalization>();
            #endregion

            #region User Dialog
            container.RegisterSingle(() => UserDialogs.Instance);
            #endregion

            #region Model
            container.Register<IPersonModel, PersonModel>();
            container.Register<ISpaceModel, SpaceModel>();
            #endregion

            #region View
            container.Register<ILoginPage, LoginPage>();
            container.Register<IRegisterPage, RegisterPage>();
            container.Register<IStreamPage, StreamPage>();
            container.Register<IHomePage, HomePage>();
            #endregion

            #region View Model
            container.Register<ILoginPageViewModel, LoginPageViewModel>();
            container.Register<IRegisterPageViewModel, RegisterPageViewModel>();
            container.Register<IHomePageViewModel, HomePageViewModel>();
            container.Register<IStreamPageViewModel<FreshSpaceService>, StreamPageViewModel<FreshSpaceService>>();
            #endregion

            #region Repository
            container.RegisterSingle<IPersonRepository, LocalPersonRepository>();
            container.RegisterSingle<ISpaceRepository, LocalSpaceRepository>();
            #endregion

            #region Login
            container.Register<ILoginService, MockLoginService>();
            #endregion

            #region Register
            container.Register<IRegisterService, MockRegisterService>();
            #endregion

            #region Error
            container.Register<IErrorService, ErrorService>();
            #endregion

            #region Utility
            container.Register<IUsernameValidatorUtility, MockUsernameValidatorUtility>();
            container.Register<IPasswordValidatorUtility, PasswordValidatorUtility>();
            container.Register<IEmailValidatorUtility, EmailValidatorUtility>();
            #endregion

#if DEBUG
            container.Verify();
#endif

            return container.GetInstance<IIoC>();
        }
    }
}
