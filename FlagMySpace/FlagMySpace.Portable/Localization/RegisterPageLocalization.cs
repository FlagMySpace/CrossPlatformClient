using FlagMySpace.Portable.LocalizationResources;

namespace FlagMySpace.Portable.Localization
{
    public class RegisterPageLocalization : IRegisterPageLocalization
    {
        public string Title
        {
            get { return AppResources.RegisterPageTitle; }
        }

        public string PlaceholderPassword
        {
            get { return AppResources.Password; }
        }

        public string PlaceholderEmail
        {
            get { return AppResources.Email; }
        }

        public string TextRegister
        {
            get { return AppResources.RegisterPageLocalization_TextRegister_register; }
        }

        public string PlaceholderConfirmPassword
        {
            get { return AppResources.RegisterPageLocalization_PlaceholderConfirmPassword_confirm_password; }
        }

        public string PlaceholderUsername
        {
            get { return AppResources.RegisterPageLocalization_PlaceholderUsername_username; }
        }
    }
}