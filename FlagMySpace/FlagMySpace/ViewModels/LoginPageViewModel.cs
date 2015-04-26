using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.Common;
using FlagMySpace.ViewFactory;
using Ninject;
using Parse;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.ViewModels
{
    public class LoginPageViewModel : ViewModel
    {
        private readonly IViewFactory _viewFactory;
        private readonly IError _error;
        private string _title;
        private string _username;
        private string _password;
        private Command _loginCommand;

        public LoginPageViewModel(IViewFactory viewFactory, IError error)
        {
            _viewFactory = viewFactory;
            _error = error;
            MessagingCenter.Subscribe<IError, ExceptionDispatchInfo>(this, "error", ErrorThrown);
        }

        private async void ErrorThrown(IError error, ExceptionDispatchInfo exceptionDispatchInfo)
        {
            var page = _viewFactory.GetFromViewModel(this);
            await page.DisplayAlert("Login Failed", exceptionDispatchInfo.SourceException.Message, "OK");
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
