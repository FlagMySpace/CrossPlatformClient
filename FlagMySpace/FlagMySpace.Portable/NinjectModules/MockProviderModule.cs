using FlagMySpace.Portable.MockProvider;
using FlagMySpace.Portable.ViewModels;
using Ninject.Modules;

namespace FlagMySpace.Portable.NinjectModules
{
    public class MockProviderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoginProvider>().To<MockLoginProvider>();
        }
    }
}
