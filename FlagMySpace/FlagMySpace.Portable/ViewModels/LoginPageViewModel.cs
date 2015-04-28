using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using FlagMySpace.Portable.Common;
using FlagMySpace.Portable.ViewFactory;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels
{
    public interface ILoginProvider
    {
        Task<bool> Login();
    }

    public interface ILoginPageLocalizationProvider
    {
        string ButtonLoginText { get; }
        string UsernamePlaceholder { get; }
        string PasswordPlaceholder { get; }
        string LoginFailedTitle { get; }
        string LoginFailedMessage { get; }
        string LoginFailedCancel { get; }
    }

    public interface IPerson
    {
        string Username { get; set; }
        string Email { get; set; }
    }

    public class LoginPageViewModel : ViewModel
    {
        private Command _loginCommand;
        private string _password;
        private string _title;
        private string _username;
        private readonly IViewFactory _viewFactory;
        private readonly ILoginProvider _loginProvider;
        private readonly ILoginPageLocalizationProvider _localizationProvider;

        public LoginPageViewModel(IViewFactory viewFactory, ILoginProvider loginProvider, ILoginPageLocalizationProvider localizationProvider)
        {
            _viewFactory = viewFactory;
            _loginProvider = loginProvider;
            _localizationProvider = localizationProvider;
        }

        public string Title
        {
            get { return _title; }
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

        private async void ErrorThrown(IError error, ExceptionDispatchInfo exceptionDispatchInfo)
        {
            var page = _viewFactory.GetFromViewModel(this);
            await page.DisplayAlert(
                _localizationProvider.LoginFailedTitle,
                exceptionDispatchInfo.SourceException.Message,
                _localizationProvider.LoginFailedCancel);
        }

        private async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                var doLogin = await _loginProvider.Login();
                if (!doLogin)
                {
                    await
                        _viewFactory.GetFromViewModel(this)
                            .DisplayAlert(
                            _localizationProvider.LoginFailedTitle,
                            _localizationProvider.LoginFailedMessage,
                            _localizationProvider.LoginFailedCancel);
                }
            }
        }

        private string _mUsernamePlaceholder;
        public string UsernamePlaceholder
        {
            get
            {
                _mUsernamePlaceholder = _localizationProvider.UsernamePlaceholder;
                return _mUsernamePlaceholder;
            }
            set
            {
                SetProperty(ref _mUsernamePlaceholder, value);
            }
        }

        private string _mPasswordPlaceholder;
        public string PasswordPlaceholder
        {
            get
            {
                _mPasswordPlaceholder = _localizationProvider.PasswordPlaceholder;
                return _mPasswordPlaceholder;
            }
            set
            {
                SetProperty(ref _mPasswordPlaceholder, value);
            }
        }

        private string _mButtonLoginText;
        public string ButtonLoginText
        {
            get
            {
                _mButtonLoginText = _localizationProvider.ButtonLoginText;
                return _mButtonLoginText;
            }
            set
            {
                SetProperty(ref _mButtonLoginText, value);
            }
        }
    }
}