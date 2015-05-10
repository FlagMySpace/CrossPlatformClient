using System;
using System.Collections.Generic;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Portable.Pages;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewFactory
{
    public class ViewFactory : IViewFactory
    {
        private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IIoC _provider;

        public ViewFactory(IIoC provider)
        {
            _provider = provider;
        }

        public void Set<TViewModel, TView>()
            where TViewModel : class, IViewModel
            where TView : IView
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public IView Get<TViewModel>() where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            return Get<TViewModel>(out viewModel);
        }

        public IView Get<TViewModel>(out TViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            viewModel = _provider.Get<TViewModel>();

            var viewType = _map[typeof(TViewModel)];
            var view = (IView)_provider.Get(viewType);

            viewModel.Navigation = new ViewModelNavigation(view.Navigation);
            view.BindingContext = viewModel;
            return view;
        }

        public IView Get<TViewModel>(TViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            var viewType = _map[typeof(TViewModel)];
            var view = (IView)_provider.Get(viewType);

            viewModel.Navigation = new ViewModelNavigation(view.Navigation);
            view.BindingContext = viewModel;
            return view;
        }
    }
}
