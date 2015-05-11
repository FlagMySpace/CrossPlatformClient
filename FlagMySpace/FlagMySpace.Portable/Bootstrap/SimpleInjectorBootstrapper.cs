using Acr.UserDialogs;
using FlagMySpace.Agnostic.EventAggregator;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Agnostic.Models.PersonModel;
using FlagMySpace.Agnostic.Models.SpaceModel;
using FlagMySpace.Agnostic.Services.ErrorService;
using FlagMySpace.Agnostic.Services.LoginService;
using FlagMySpace.Agnostic.Services.RegisterService;
using FlagMySpace.Agnostic.Utilities.UsernameValidatorUtility;
using FlagMySpace.Portable.IoC;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.Localization.LoginPageLocalization;
using FlagMySpace.Portable.Localization.RegisterPageLocalization;
using FlagMySpace.Portable.Pages;
using FlagMySpace.Portable.Pages.LoginPage;
using FlagMySpace.Portable.Pages.RegisterPage;
using FlagMySpace.Portable.Pages.StreamPage;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels;
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
            #endregion

            #region View Model
            container.Register<ILoginPageViewModel, LoginPageViewModel>();
            container.Register<IRegisterPageViewModel, RegisterPageViewModel>();
            container.Register<IStreamPageViewModel, StreamPageViewModel>();
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
            #endregion

#if DEBUG
            container.Verify();
#endif

            return container.GetInstance<IIoC>();
        }
    }
}
