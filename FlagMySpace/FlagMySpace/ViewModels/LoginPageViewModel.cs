using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.ViewModels
{
    public class LoginPageViewModel : ViewModel
    {
        private string _title;
        private string _username;
        private string _password;
        private Command _loginCommand;

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

        private void Login()
        {
            if (!String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password))
            {
            }
        }

        public LoginPageViewModel()
        {

        }
    }
}
