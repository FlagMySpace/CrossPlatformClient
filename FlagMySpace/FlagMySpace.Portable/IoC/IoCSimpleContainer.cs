using System;
using FlagMySpace.Agnostic.IoC;
using SimpleInjector;

namespace FlagMySpace.Portable.IoC
{
    class IoCSimpleContainer : IIoC
    {
        private readonly Container _provider;

        public IoCSimpleContainer(Container provider)
        {
            _provider = provider;
        }

        public T Get<T>() where T : class
        {
            return _provider.GetInstance<T>();
        }

        public object Get(Type viewType)
        {
            return _provider.GetInstance(viewType);
        }
    }
}