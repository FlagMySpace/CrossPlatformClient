using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.ViewFactory;
using Ninject.Modules;

namespace FlagMySpace.NinjectModules
{
    public class ViewFactoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IViewFactory>().To<ViewFactory.ViewFactory>().InSingletonScope();
        }
    }
}
