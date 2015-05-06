using Acr.UserDialogs;
using FlagMySpace.Agnostic.Login;
using FlagMySpace.Portable.Localization;
using FlagMySpace.Portable.ViewFactory;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels
{
    public class LoginPageViewModel : ViewModel, ILoginPageViewModel
    {
        private readonly IUserDialogs _dialogs;
        private readonly ILoginPageLocalizationProvider _localizationProvider;
        private readonly ILoginProvider _loginProvider;
        private readonly IViewFactory _viewFactory;
        private Command _loginCommand;
        private string _mButtonLoginText;
        private string _mPasswordPlaceholder;
        private string _mUsernamePlaceholder;
        private string _password;
        private string _title;
        private string _username;

        public LoginPageViewModel(IViewFactory viewFactory, ILoginProvider loginProvider,
            ILoginPageLocalizationProvider localizationProvider, IUserDialogs dialogs)
        {
            _viewFactory = viewFactory;
            _loginProvider = loginProvider;
            _localizationProvider = localizationProvider;
            _dialogs = dialogs;
        }

        public string Title
        {
            get { return _title = _localizationProvider.TitleText; }
            set { SetProperty(ref _title, value); }
        }

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public Command LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new Command(Login)); }
        }

        public string UsernamePlaceholder
        {
            get
            {
                _mUsernamePlaceholder = _localizationProvider.UsernamePlaceholder;
                return _mUsernamePlaceholder;
            }
            set { SetProperty(ref _mUsernamePlaceholder, value); }
        }

        public string PasswordPlaceholder
        {
            get
            {
                _mPasswordPlaceholder = _localizationProvider.PasswordPlaceholder;
                return _mPasswordPlaceholder;
            }
            set { SetProperty(ref _mPasswordPlaceholder, value); }
        }

        public string ButtonLoginText
        {
            get
            {
                _mButtonLoginText = _localizationProvider.ButtonLoginText;
                return _mButtonLoginText;
            }
            set { SetProperty(ref _mButtonLoginText, value); }
        }

        private async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                var doLogin = await _loginProvider.LoginAsync();
                if (!doLogin)
                {
                    await
                        _dialogs.AlertAsync(
                            _localizationProvider.LoginFailedMessage,
                            _localizationProvider.LoginFailedTitle,
                            _localizationProvider.LoginFailedCancel);
                }
            }
            else
            {
                await
                    _dialogs.AlertAsync(
                        _localizationProvider.ErrorLoginEmpty,
                        _localizationProvider.LoginFailedTitle,
                        _localizationProvider.LoginFailedCancel);
            }
        }
    }
}