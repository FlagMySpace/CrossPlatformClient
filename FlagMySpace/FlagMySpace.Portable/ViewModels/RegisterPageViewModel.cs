using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels
{
    public class RegisterPageViewModel : ViewModel, IRegisterPageViewModel
    {
        private string _title;
        private string _username;
        private string _password;
        private string _placeholderUsername;
        private string _placeholderPassword;
        private string _placeholderConfirmPassword;
        private string _placeholderEmail;
        private string _textRegister;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string TextUsername
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string TextPassword
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public string PlaceholderUsername
        {
            get { return _placeholderUsername; }
            set { SetProperty(ref _placeholderUsername, value); }
        }

        public string PlaceholderPassword
        {
            get { return _placeholderPassword; }
            set { SetProperty(ref _placeholderPassword, value); }
        }

        public string PlaceholderConfirmPassword
        {
            get { return _placeholderConfirmPassword; }
            set { SetProperty(ref _placeholderConfirmPassword, value); }
        }

        public string PlaceholderEmail
        {
            get { return _placeholderEmail; }
            set { SetProperty(ref _placeholderEmail, value); }
        }

        public string TextRegister
        {
            get { return _textRegister; }
            set { SetProperty(ref _textRegister, value); }
        }
    }
}
