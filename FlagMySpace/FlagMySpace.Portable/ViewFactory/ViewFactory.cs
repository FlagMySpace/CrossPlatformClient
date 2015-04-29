using System;
using System.Collections.Generic;
using Ninject;
using SimpleInjector;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewFactory
{
    public interface IIoCProvider
    {
        T Get<T>() where T : class;
        object Get(Type viewType);
    }

    class IoCSimpleContainer : IIoCProvider
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

    public class IoCNinject : IIoCProvider
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

    public class ViewFactory : IViewFactory
    {
        private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IIoCProvider _provider;

        public ViewFactory(IIoCProvider provider)
        {
            _provider = provider;
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
            viewModel = _provider.Get<TViewModel>();

            var viewType = _map[typeof(TViewModel)];
            var view = (Page)_provider.Get(viewType);
            
            viewModel.Navigation = new ViewModelNavigation(view.Navigation);
            view.BindingContext = viewModel;
            return view;
        }

        public Page Get<TViewModel>(TViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            var viewType = _map[typeof(TViewModel)];
            var view = (Page)_provider.Get(viewType);
            
            viewModel.Navigation = new ViewModelNavigation(view.Navigation);
            view.BindingContext = viewModel;
            return view;
        }
    }
}
