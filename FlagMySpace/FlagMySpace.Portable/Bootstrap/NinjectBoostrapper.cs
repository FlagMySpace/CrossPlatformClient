using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.LocalizationResources;
using FlagMySpace.Portable.NinjectModules;
using FlagMySpace.Portable.Pages;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels;
using Ninject;
using Xamarin.Forms;

namespace FlagMySpace.Portable.Bootstrap
{
    public class NinjectBoostrapper
    {
        private Application Application { get; set; }

        public void Run(Application application)
        {
            Application = application;
            var kernel = ConfigureKernel();
            var viewFactory = kernel.Get<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(kernel);
        }

        private void ConfigureApplication(IKernel kernel)
        {
            if (Device.OS != TargetPlatform.WinPhone)
            {
                AppResources.Culture = kernel.Get<ILocalize>().GetCurrentCultureInfo();
            }
            var viewFactory = kernel.Get<IViewFactory>();

            var tabbedPage = kernel.Get<TabbedPage>();
            tabbedPage.Children.Add(viewFactory.Get<ILoginPageViewModel>());
            tabbedPage.Children.Add(viewFactory.Get<IRegisterPageViewModel>());
            Application.MainPage = tabbedPage;
        }

        private IKernel ConfigureKernel()
        {
            var kernel = new StandardKernel(new FlagMySpaceModule(), new MockProviderModule());
            return kernel;
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Set<ILoginPageViewModel, LoginPage>();
            viewFactory.Set<IRegisterPageViewModel, RegisterPage>();
        }
    }
}