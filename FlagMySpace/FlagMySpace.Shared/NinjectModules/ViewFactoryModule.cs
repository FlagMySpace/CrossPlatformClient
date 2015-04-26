
using FlagMySpace.Shared.ViewFactory;
using Ninject.Modules;

namespace FlagMySpace.Shared.NinjectModules
{
    public class ViewFactoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IViewFactory>().To<ViewFactory.ViewFactory>().InSingletonScope();
        }
    }
}
