using FlagMySpace.Shared.Common;
using Ninject.Modules;

namespace FlagMySpace.Shared.NinjectModules
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IError>().To<ErrorHandler>().InSingletonScope();
        }
    }
}
