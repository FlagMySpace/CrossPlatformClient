using System;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Agnostic.Repositories.SpaceRepository;
using FlagMySpace.Agnostic.Services.SpaceService;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.Resources;
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
using Xamarin.Forms;

namespace FlagMySpace.Portable.Bootstrap
{
    public abstract class BootstrapperBase : IBoostrapper
    {
        private Application _application;

        public void Run(Application application)
        {
            _application = application;
            var container = ConfigureContainer();
            RegisterViews(container.Get<IViewFactory>());
            ConfigureApplication(container);
        }

        protected abstract IIoC ConfigureContainer();

        private void ConfigureApplication(IIoC container)
        {
            if (Device.OS != TargetPlatform.WinPhone)
            {
                AppResources.Culture = container.Get<ILocalize>().GetCurrentCultureInfo();
            }
            var viewFactory = container.Get<IViewFactory>();

            _application.MainPage = new NavigationPage(viewFactory.Get<IHomePageViewModel>() as Page);
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Set<ILoginPageViewModel, ILoginPage>();
            viewFactory.Set<IRegisterPageViewModel, IRegisterPage>();
            viewFactory.Set<IStreamPageViewModel, IStreamPage>();
            viewFactory.Set<IStreamPageViewModel<FreshSpaceService>, IStreamPage>();
            viewFactory.Set<IHomePageViewModel, IHomePage>();
        }
    }
}