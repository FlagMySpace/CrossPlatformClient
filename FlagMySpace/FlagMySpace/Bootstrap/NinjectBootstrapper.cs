using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.ViewFactory;
using Ninject;
using Ninject.Modules;

namespace FlagMySpace.Bootstrap
{
    public abstract class NinjectBootstrapper
    {
        public void Run()
        {
            var kernel = ConfigureKernel();
            var viewFactory = kernel.Get<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(kernel);
        }

        protected abstract IKernel ConfigureKernel();

        protected abstract void RegisterViews(IViewFactory viewFactory);

        protected abstract void ConfigureApplication(IKernel kernel);
    }
}
