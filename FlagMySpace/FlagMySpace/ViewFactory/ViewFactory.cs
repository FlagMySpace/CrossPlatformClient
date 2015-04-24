using System;
using System.Collections.Generic;
using Ninject;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.ViewFactory
{
    public class ViewFactory : IViewFactory
    {
        private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IKernel _kernel;

        public ViewFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Set<TViewModel, TView>()
            where TViewModel : class, IViewModel
            where TView : Page
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public Page Get<TViewModel>() where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            return Get<TViewModel>(out viewModel);
        }

        public Page Get<TViewModel>(out TViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            viewModel = _kernel.Get<TViewModel>();

            var viewType = _map[typeof(TViewModel)];
            var view = (Page)_kernel.Get(viewType);

            view.BindingContext = viewModel;
            return view;
        }

        public Page Get<TViewModel>(TViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            var viewType = _map[typeof(TViewModel)];
            var view = (Page)_kernel.Get(viewType);
            view.BindingContext = viewModel;
            return view;
        }
    }
}
