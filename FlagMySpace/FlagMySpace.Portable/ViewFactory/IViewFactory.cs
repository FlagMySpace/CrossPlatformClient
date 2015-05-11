using FlagMySpace.Portable.Pages;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewFactory
{
    public interface IViewFactory
    {
        void Set<TViewModel, TView>()
            where TViewModel : class, IViewModel
            where TView : IView;

        IView Get<TViewModel>()
            where TViewModel : class, IViewModel;

        IView Get<TViewModel>(out TViewModel viewModel)
            where TViewModel : class, IViewModel;

        IView Get<TViewModel>(TViewModel viewModel)
            where TViewModel : class, IViewModel;

        int CountMapping { get; }
    }
}
