using System;
using FlagMySpace.ViewFactory;
using FlagMySpace.ViewModels;
using Xamarin.Forms;

namespace FlagMySpace.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly IViewFactory _viewFactory;

        public LoginPage(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            InitializeComponent();
        }

        private async void ButtonRegister_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(_viewFactory.Get<RegisterPageViewModel>());
        }
    }
}
