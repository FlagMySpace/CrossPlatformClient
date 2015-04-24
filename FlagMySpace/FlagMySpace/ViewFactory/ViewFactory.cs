using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Register<TViewModel, TView>()
            where TViewModel : class, IViewModel
            where TView : Page
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public Page Resolve<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            return Resolve<TViewModel>(out viewModel, setStateAction);
        }

        public Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> setStateAction = null)
            where TViewModel : class, IViewModel
        {
            viewModel = _kernel.Get<TViewModel>();

            var viewType = _map[typeof(TViewModel)];
            var view = (Page)_kernel.Get(viewType);

            view.BindingContext = viewModel;
            return view;
        }

        public Page Resolve<TViewModel>(TViewModel viewModel)
            where TViewModel : class, IViewModel
        {
            var viewType = _map[typeof(TViewModel)];
            var view = (Page)_kernel.Get(viewType);
            view.BindingContext = viewModel;
            return view;
        }
    }
}
