using FlagMySpace.Portable.ViewFactory;
using Xamarin.Forms;

namespace FlagMySpace.Portable.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly IViewFactory _viewFactory;

        public LoginPage(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            InitializeComponent();
        }
    }
}
