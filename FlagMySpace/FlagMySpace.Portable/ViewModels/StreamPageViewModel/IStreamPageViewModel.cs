using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlagMySpace.Agnostic.Models.SpaceModel;
using FlagMySpace.Agnostic.Repositories;
using FlagMySpace.Agnostic.Repositories.SpaceRepository;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels.StreamPageViewModel
{
    public interface IStreamPageViewModel : IViewModel
    {
        ICollection<ISpaceModel> StreamCollection { get; }
    }

    public interface IStreamPageViewModel<T> : IStreamPageViewModel
    {
    }
}