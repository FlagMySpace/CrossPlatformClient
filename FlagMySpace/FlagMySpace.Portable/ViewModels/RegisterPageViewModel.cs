using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using FlagMySpace.Agnostic.Register;
using FlagMySpace.Portable.Localization;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels
{
    public class RegisterPageViewModel : ViewModel, IRegisterPageViewModel
    {
        private readonly IRegisterPageLocalization _localization;
        private readonly IRegisterService _registerService;
        private readonly IUserDialogs _userDialogs;

        public RegisterPageViewModel(IRegisterPageLocalization localization, IRegisterService registerService, IUserDialogs userDialogs)
        {
            _localization = localization;
            _registerService = registerService;
            _userDialogs = userDialogs;
        }

        #region PropertyBinding

        private string _mTitle;

        public string Title
        {
            get { return _mTitle = _localization.Title; }
            set { SetProperty(ref _mTitle, value); }
        }

        private string _mUsername;

        public string Username
        {
            get { return _mUsername; }
            set { SetProperty(ref _mUsername, value); }
        }

        private string _mPassword;

        public string Password
        {
            get { return _mPassword; }
            set { SetProperty(ref _mPassword, value); }
        }

        private string _mConfirmPassword;

        public string ConfirmPassword
        {
            get { return _mConfirmPassword; }
            set { SetProperty(ref _mConfirmPassword, value); }
        }

        private string _mEmail;

        public string Email
        {
            get { return _mEmail; }
            set { SetProperty(ref _mEmail, value); }
        }

        private ICommand _mRegisterCommand;
        public ICommand RegisterCommand
        {
            get { return _mRegisterCommand ?? (_mRegisterCommand = new Command(async () => await Register())); }
        }

        private async Task Register()
        {
            var result = await _registerService.RegisterAsync(Username, Password, Email);
            await
                _userDialogs.AlertAsync(result.Message, _localization.RegisterInformation,
                    _localization.Ok);
            if (result.Status)
            {
                //TODO: link to a page when registration success
            }
        }

        #endregion

        #region Localizations

        private string _mPlaceholderUsername;

        public string PlaceholderUsername
        {
            get { return _mPlaceholderUsername = _localization.PlaceholderUsername; }
            set { SetProperty(ref _mPlaceholderUsername, value); }
        }

        private string _mPlaceholderPassword;

        public string PlaceholderPassword
        {
            get { return _mPlaceholderPassword = _localization.PlaceholderPassword; }
            set { SetProperty(ref _mPlaceholderPassword, value); }
        }

        private string _mPlaceholderConfirmPassword;

        public string PlaceholderConfirmPassword
        {
            get { return _mPlaceholderConfirmPassword = _localization.PlaceholderConfirmPassword; }
            set { SetProperty(ref _mPlaceholderConfirmPassword, value); }
        }

        private string _mPlaceholderEmail;

        public string PlaceholderEmail
        {
            get { return _mPlaceholderEmail = _localization.PlaceholderEmail; }
            set { SetProperty(ref _mPlaceholderEmail, value); }
        }

        private string _mTextRegister;

        public string TextRegister
        {
            get { return _mTextRegister = _localization.TextRegister; }
            set { SetProperty(ref _mTextRegister, value); }
        }

        #endregion
    }
}