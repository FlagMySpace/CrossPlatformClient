using System;
using System.Runtime.ExceptionServices;
using FlagMySpace.Common;
using FlagMySpace.ViewFactory;
using Parse;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.ViewModels
{
    public class LoginPageViewModel : ViewModel
    {
        private Command _loginCommand;
        private string _password;
        private string _title;
        private string _username;
        private readonly IError _error;
        private readonly IViewFactory _viewFactory;

        public LoginPageViewModel(IViewFactory viewFactory, IError error)
        {
            _viewFactory = viewFactory;
            _error = error;
            MessagingCenter.Subscribe<IError, ExceptionDispatchInfo>(this, "error", ErrorThrown);
        }

        public String Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public String Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public String Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public Command LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new Command(Login)); }
        }

        private async void ErrorThrown(IError error, ExceptionDispatchInfo exceptionDispatchInfo)
        {
            var page = _viewFactory.GetFromViewModel(this);
            await page.DisplayAlert("Login Failed", exceptionDispatchInfo.SourceException.Message, "OK");
        }

        private async void Login()
        {
            if (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password))
            {
                try
                {
                    await ParseUser.LogInAsync(Username, Password);
                }
                catch (Exception e)
                {
                    _error.CaptureError(e);
                }
            }
        }
    }
}