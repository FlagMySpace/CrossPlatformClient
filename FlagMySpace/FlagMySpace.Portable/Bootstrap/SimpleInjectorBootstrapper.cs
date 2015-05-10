using Acr.UserDialogs;
using FlagMySpace.Agnostic.Error;
using FlagMySpace.Agnostic.EventAggregator;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Agnostic.Login;
using FlagMySpace.Agnostic.Register;
using FlagMySpace.Portable.IoC;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.Pages;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels;
using SimpleInjector;
using Xamarin.Forms;

namespace FlagMySpace.Portable.Bootstrap
{
    public class SimpleInjectorBootstrapper : BootstrapperBase
    {
        protected override IIoC ConfigureContainer()
        {
            var container = new Container();
            // Event Aggregator
            container.RegisterSingle<IEventAggregator, EventAggregator>();
            // View Factory
            container.Register<IIoC, IoCSimpleContainer>();
            container.RegisterSingle<IViewFactory, ViewFactory.ViewFactory>();
            // Localization
            container.Register(() => DependencyService.Get<ILocalize>());
            container.Register<ILoginPageLocalizationProvider, LoginPageLocalizationProvider>();
            container.Register<IRegisterPageLocalization, RegisterPageLocalization>();
            // User dialog
            container.RegisterSingle(() => UserDialogs.Instance);
            // View
            container.Register<ILoginPage, LoginPage>();
            container.Register<IRegisterPage, RegisterPage>();
            // View Model
            container.Register<ILoginPageViewModel, LoginPageViewModel>();
            container.Register<IRegisterPageViewModel, RegisterPageViewModel>();
            // Login
            container.Register<ILoginService, MockLoginService>();
            // Register
            container.Register<IRegisterService, MockRegisterService>();
            // Error
            container.Register<IErrorService, ErrorService>();
            // Utility
            container.Register<IUsernameValidatorUtility, MockUsernameValidatorUtility>();

#if DEBUG
            container.Verify();
#endif

            return container.GetInstance<IoCSimpleContainer>();
        }
    }
}
