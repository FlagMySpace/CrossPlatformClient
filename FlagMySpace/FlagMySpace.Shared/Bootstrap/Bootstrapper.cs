using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.ViewFactory;
using Ninject;
using Ninject.Modules;
using Xamarin.Forms;

namespace FlagMySpace.Bootstrap
{
    public abstract class Bootstrapper
    {
        public void Run(Application application)
        {
            Application = application;
            var kernel = ConfigureKernel();
            var viewFactory = kernel.Get<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(kernel);
        }

        protected Application Application { get; set; }

        protected abstract IKernel ConfigureKernel();

        protected abstract void RegisterViews(IViewFactory viewFactory);

        protected abstract void ConfigureApplication(IKernel kernel);
    }
}
