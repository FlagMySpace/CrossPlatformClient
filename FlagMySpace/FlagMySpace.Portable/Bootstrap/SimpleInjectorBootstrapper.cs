using Acr.UserDialogs;
using FlagMySpace.Agnostic.Error;
using FlagMySpace.Agnostic.EventAggregator;
using FlagMySpace.Agnostic.Login;
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
        protected override IIoCProvider ConfigureContainer()
        {
            var container = new Container();
            // Event Aggregator
            container.RegisterSingle<IEventAggregator, EventAggregator>();
            // View Factory
            container.Register<IIoCProvider, IoCSimpleContainer>();
            container.RegisterSingle<IViewFactory, ViewFactory.ViewFactory>();
            // Localization
            container.Register(() => DependencyService.Get<ILocalize>());
            container.Register<ILoginPageLocalizationProvider, LoginPageLocalizationProvider>();
            // User dialog
            container.RegisterSingle(() => UserDialogs.Instance);
            // View
            container.Register<ILoginPage, LoginPage>();
            container.Register<IRegisterPage, RegisterPage>();
            // View Model
            container.Register<ILoginPageViewModel, LoginPageViewModel>();
            container.Register<IRegisterPageViewModel, RegisterPageViewModel>();
            // Login
            container.Register<ILoginProvider, MockLoginProvider>();
            // Error
            container.Register<IErrorService, ErrorService>();

#if DEBUG
            container.Verify();
#endif

            return container.GetInstance<IoCSimpleContainer>();
        }
    }
}
