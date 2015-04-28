using FlagMySpace.Portable.ViewFactory;
using Ninject.Modules;

namespace FlagMySpace.Portable.NinjectModules
{
    public class ViewFactoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IViewFactory>().To<ViewFactory.ViewFactory>().InSingletonScope();
        }
    }
}
