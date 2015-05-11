using System;
using FlagMySpace.Agnostic.Space;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels.StreamPageViewModel
{
    public interface IStreamPageViewModel : IViewModel
    {
        IObservable<SpaceModel> StreamCollection { get; }
    }
}