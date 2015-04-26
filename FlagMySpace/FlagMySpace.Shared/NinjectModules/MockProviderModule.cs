using System;
using System.Collections.Generic;
using System.Text;
using FlagMySpace.Shared.MockProvider;
using FlagMySpace.Shared.ViewModels;
using Ninject.Modules;

namespace FlagMySpace.Shared.NinjectModules
{
    public class MockProviderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoginProvider>().To<MockLoginProvider>();
        }
    }
}
