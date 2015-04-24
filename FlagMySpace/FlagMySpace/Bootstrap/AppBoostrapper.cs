using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.NinjectModules;
using FlagMySpace.Pages;
using FlagMySpace.ViewFactory;
using FlagMySpace.ViewModels;
using Ninject;
using Xamarin.Forms;

namespace FlagMySpace.Bootstrap
{
    public class AppBoostrapper : NinjectBootstrapper
    {
        private readonly App _application;

        public AppBoostrapper(App application)
        {
            _application = application;
        }

        protected override void ConfigureApplication(IKernel kernel)
        {
            // set main page
            var viewFactory = kernel.Get<IViewFactory>();
            var mainPage = viewFactory.Resolve<LoginPageViewModel>();
            var navigationPage = new NavigationPage(mainPage);

            _application.MainPage = navigationPage;
        }
    
        protected override IKernel ConfigureKernel()
        {
            var kernel = new StandardKernel(new ViewFactoryModule());
            return kernel;
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginPageViewModel, LoginPage>();
        }
    }
}
