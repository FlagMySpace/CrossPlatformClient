using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.ViewFactory
{
    public interface IViewFactory
    {
        void Set<TViewModel, TView>()
            where TViewModel : class, IViewModel
            where TView : Page;

        Page Get<TViewModel>()
            where TViewModel : class, IViewModel;

        Page Get<TViewModel>(out TViewModel viewModel)
            where TViewModel : class, IViewModel;

        Page Get<TViewModel>(TViewModel viewModel)
            where TViewModel : class, IViewModel;

        Page GetFromViewModel(IViewModel viewModel);
    }
}
