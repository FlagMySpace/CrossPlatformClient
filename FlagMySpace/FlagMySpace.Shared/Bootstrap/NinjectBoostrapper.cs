using System.Linq;
using FlagMySpace.Shared.Localization;
using FlagMySpace.Shared.NinjectModules;
using FlagMySpace.Shared.Pages;
using FlagMySpace.Shared.ViewFactory;
using FlagMySpace.Shared.ViewModels;
using Ninject;
using Ninject.Modules;
using Xamarin.Forms;

namespace FlagMySpace.Shared.Bootstrap
{
    public class NinjectBoostrapper : Bootstrapper
    {
        public NinjectBoostrapper(params INinjectModule[] modules)
        {
            Modules = modules;
        }

        public INinjectModule[] Modules { get; set; }

        protected override void ConfigureApplication(IKernel kernel)
        {
            if (Device.OS != TargetPlatform.WinPhone)
            {
                AppResources.Culture = kernel.Get<ILocalize>().GetCurrentCultureInfo();
            }
            var viewFactory = kernel.Get<IViewFactory>();
            var mainPage = viewFactory.Get<LoginPageViewModel>();
            var navigationPage = new NavigationPage(mainPage);

            Application.MainPage = navigationPage;
        }

        protected override IKernel ConfigureKernel()
        {
            var kernel = new StandardKernel(
                new ViewFactoryModule(),
                new CommonModule(),
                new MockProviderModule(),
                new LocalizationModule());
            return kernel;
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Set<LoginPageViewModel, LoginPage>();
            viewFactory.Set<RegisterPageViewModel, RegisterPage>();
        }
    }
}