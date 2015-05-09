using System;
using FlagMySpace.Agnostic.IoC;
using Ninject;

namespace FlagMySpace.Portable.IoC
{
    public class IoCNinject : IIoC
    {
        private readonly IKernel _kernel;

        public IoCNinject(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object Get(Type viewType)
        {
            return _kernel.Get(viewType);
        }

        public T Get<T>() where T : class
        {
            return _kernel.Get<T>();
        }
    }
}