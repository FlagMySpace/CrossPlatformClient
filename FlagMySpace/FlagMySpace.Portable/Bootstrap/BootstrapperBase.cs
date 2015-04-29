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

        protected abstract IIoCProvider ConfigureContainer();

        private void ConfigureApplication(IIoCProvider container)
        {
            if (Device.OS != TargetPlatform.WinPhone)
            {
                AppResources.Culture = container.Get<ILocalize>().GetCurrentCultureInfo();
            }
            var viewFactory = container.Get<IViewFactory>();

            var tabbedPage = container.Get<TabbedPage>();
            tabbedPage.Children.Add(viewFactory.Get<ILoginPageViewModel>());
            tabbedPage.Children.Add(viewFactory.Get<IRegisterPageViewModel>());
            _application.MainPage = tabbedPage;
        }
        protected void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Set<ILoginPageViewModel, LoginPage>();
            viewFactory.Set<IRegisterPageViewModel, RegisterPage>();
        }
    }
}