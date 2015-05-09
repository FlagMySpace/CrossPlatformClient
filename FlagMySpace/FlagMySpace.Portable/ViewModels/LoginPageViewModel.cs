using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using FlagMySpace.Agnostic.EventAggregator;
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
        private readonly IEventAggregator _eventAggregator;
        private readonly ILoginPageLocalizationProvider _localizationProvider;
        private readonly ILoginService _loginProvider;
        private readonly IViewFactory _viewFactory;
        private ICommand _loginCommand;
        private string _mButtonLoginText;
        private string _mPasswordPlaceholder;
        private string _mUsernamePlaceholder;
        private string _password;
        private string _title;
        private string _username;

        public LoginPageViewModel(
            IViewFactory viewFactory,
            ILoginService loginProvider,
            ILoginPageLocalizationProvider localizationProvider,
            IUserDialogs dialogs,
            IEventAggregator eventAggregator)
        {
            _viewFactory = viewFactory;
            _loginProvider = loginProvider;
            _localizationProvider = localizationProvider;
            _dialogs = dialogs;
            _eventAggregator = eventAggregator;
        }

        private async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                var result = await _loginProvider.LoginAsync();
                if (!result)
                {
                    await
                        _dialogs.AlertAsync(
                            _localizationProvider.LoginFailedMessage,
                            _localizationProvider.LoginFailedTitle,
                            _localizationProvider.LoginFailedCancel);
                }
                else
                {
                    //TODO: redirect user after successful login.
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

        #region Property

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

        #endregion

        #region Bindings

        public string Title
        {
            get { return _title = _localizationProvider.TitleText; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new Command(async () => await Login())); }
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

        #endregion
    }
}