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
using Ninject.Modules;
using Xamarin.Forms;

namespace FlagMySpace.Bootstrap
{
    public class NinjectBoostrapper : Bootstrapper
    {
        public INinjectModule[] Modules { get; set; }

        public NinjectBoostrapper(params INinjectModule[] modules)
        {
            Modules = modules;
        }

        protected override void ConfigureApplication(IKernel kernel)
        {
            var viewFactory = kernel.Get<IViewFactory>();
            var mainPage = viewFactory.Get<LoginPageViewModel>();
            var navigationPage = new NavigationPage(mainPage);

            Application.MainPage = navigationPage;
        }
    
        protected override IKernel ConfigureKernel()
        {
            var listModule = Modules.ToList();
            listModule.Add(new ViewFactoryModule());
            listModule.Add(new CommonModule());

            var kernel = new StandardKernel(listModule.ToArray());
            return kernel;
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Set<LoginPageViewModel, LoginPage>();
            viewFactory.Set<RegisterPageViewModel, RegisterPage>();
        }
    }
}
