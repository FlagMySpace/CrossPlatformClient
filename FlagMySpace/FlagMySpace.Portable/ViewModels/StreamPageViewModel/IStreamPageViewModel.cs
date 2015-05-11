using System;
using FlagMySpace.Agnostic.Models.SpaceModel;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels.StreamPageViewModel
{
    public interface IStreamPageViewModel : IViewModel
    {
        IObservable<SpaceModel> StreamCollection { get; }
    }
}