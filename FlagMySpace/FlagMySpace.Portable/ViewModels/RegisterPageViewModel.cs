using FlagMySpace.Portable.Localization;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels
{
    public class RegisterPageViewModel : ViewModel, IRegisterPageViewModel
    {
        private readonly IRegisterPageLocalization _localization;

        public RegisterPageViewModel(IRegisterPageLocalization localization)
        {
            _localization = localization;
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