using System;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Portable.IoC;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.LocalizationResources;
using FlagMySpace.Portable.NinjectModules;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels;
using Ninject;

namespace FlagMySpace.Portable.Bootstrap
{
    public class NinjectBoostrapper : BootstrapperBase
    {
        protected override IIoC ConfigureContainer()
        {
            var kernel = new StandardKernel(new FlagMySpaceModule(), new MockProviderModule());
            return kernel.Get<IoCNinject>();
        }
    }
}