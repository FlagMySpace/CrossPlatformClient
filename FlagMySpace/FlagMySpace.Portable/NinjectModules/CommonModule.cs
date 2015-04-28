using FlagMySpace.Portable.Common;
using Ninject.Modules;

namespace FlagMySpace.Portable.NinjectModules
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IError>().To<ErrorHandler>().InSingletonScope();
        }
    }
}
