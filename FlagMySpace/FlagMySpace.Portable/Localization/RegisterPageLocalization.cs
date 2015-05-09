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

        public string RegisterInformation
        {
            get { return AppResources.RegisterPageLocalization_RegisterInformation_Information; }
        }

        public string Ok
        {
            get { return AppResources.Ok; }
        }

        public string RegisterSuccessTitle
        {
            get { return AppResources.RegisterPageLocalization_RegisterSuccessTitle_Registration_successful; }
        }

        public string RegisterSuccessMessage
        {
            get { return AppResources.RegisterPageLocalization_RegisterSuccessMessage_Thank_you_for_registering_with_us_; }
        }

        public string Error
        {
            get { return AppResources.RegisterPageLocalization_Error_Error; }
        }
    }
}