using FlagMySpace.Portable.LocalizationResources;

namespace FlagMySpace.Portable.Localization
{
    public class LoginPageLocalizationProvider : ILoginPageLocalizationProvider
    {
        public string LoginFailedTitle
        {
            get { return AppResources.LoginFailedTitle; }
        }

        public string LoginFailedMessage
        {
            get { return AppResources.LoginFailedMessage; }
        }

        public string LoginFailedCancel
        {
            get { return AppResources.Ok; }
        }

        public string TitleText
        {
            get { return AppResources.LoginPageTitle; }
        }

        public string ErrorLoginEmpty { get { return AppResources.LoginPageErrorLoginEmpty; } }

        public string ButtonLoginText
        {
            get { return AppResources.LoginPageButtonLoginText; }
        }

        public string UsernamePlaceholder
        {
            get
            {
                return AppResources.Username; 
            }
        }

        public string PasswordPlaceholder
        {
            get { return AppResources.Password; }
        }
    }
}
