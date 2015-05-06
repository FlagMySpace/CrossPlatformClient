using Acr.UserDialogs;
using Agnostic.Error;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.MockProvider;
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

            //View Factory
            container.Register<IIoCProvider, IoCSimpleContainer>();
            container.RegisterSingle<IViewFactory, ViewFactory.ViewFactory>();

            // Localization
            container.Register<ILocalize>(() => DependencyService.Get<ILocalize>());
            container.Register<ILoginPageLocalizationProvider, LoginPageLocalizationProvider>();

            // Common
            container.Register<IErrorService, ErrorService>();

            // User dialog
            container.RegisterSingle<IUserDialogs>(() => UserDialogs.Instance);

            // View Model
            container.Register<ILoginPageViewModel, LoginPageViewModel>();
            container.Register<IRegisterPageViewModel, RegisterPageViewModel>();

            // Mock Service
            container.Register<ILoginProvider, MockLoginProvider>();

#if DEBUG
            container.Verify();
#endif

            return container.GetInstance<IoCSimpleContainer>();
        }
    }
}
