using FlagMySpace.Shared.ViewFactory;
using Xamarin.Forms;

namespace FlagMySpace.Shared.Pages
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
