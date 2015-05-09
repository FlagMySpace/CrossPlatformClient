using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.LocalizationResources;
using FlagMySpace.Portable.Pages;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels;
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

            var tabbedPage = container.Get<TabbedPage>();
            tabbedPage.Children.Add(viewFactory.Get<ILoginPageViewModel>() as Page);
            tabbedPage.Children.Add(viewFactory.Get<IRegisterPageViewModel>() as Page);
            _application.MainPage = tabbedPage;
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Set<ILoginPageViewModel, LoginPage>();
            viewFactory.Set<IRegisterPageViewModel, RegisterPage>();
        }
    }
}