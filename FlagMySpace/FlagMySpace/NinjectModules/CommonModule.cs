using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.Common;
using Ninject.Modules;

namespace FlagMySpace.NinjectModules
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IError>().To<ErrorHandler>().InSingletonScope();
        }
    }
}
