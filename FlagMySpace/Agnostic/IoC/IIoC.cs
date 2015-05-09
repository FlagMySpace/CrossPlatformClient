using System;

namespace FlagMySpace.Agnostic.IoC
{
    public interface IIoC
    {
        T Get<T>() where T : class;
        object Get(Type viewType);
    }
}