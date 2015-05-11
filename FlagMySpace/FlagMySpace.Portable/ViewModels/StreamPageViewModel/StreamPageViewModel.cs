using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.SpaceModel;
using FlagMySpace.Agnostic.Services.SpaceService;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels.StreamPageViewModel
{
    public class StreamPageViewModel<T> : ViewModel, IStreamPageViewModel<T> where T : ISpaceService
    {
        private readonly T _repository;

        private event Func<Task> InitializeAsync;

        public ICollection<ISpaceModel> StreamCollection { get; private set; }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public StreamPageViewModel(T repository)
        {
            _repository = repository;
            InitializeAsync += OnInitializeAsync;
            if (InitializeAsync != null) InitializeAsync.Invoke();
        }

        private async Task OnInitializeAsync()
        {
            StreamCollection = await _repository.GetSpaces();
        }
    }
}
