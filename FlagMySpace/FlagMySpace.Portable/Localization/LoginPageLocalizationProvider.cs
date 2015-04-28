using FlagMySpace.Portable.LocalizationResources;
using FlagMySpace.Portable.ViewModels;

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
            get { return AppResources.LoginFailedCancel; }
        }

        public string ButtonLoginText
        {
            get { return AppResources.LoginPageButtonLoginText; }
        }

        public string UsernamePlaceholder
        {
            get
            {
                return AppResources.LoginPageUsernamePlaceholder; 
            }
        }

        public string PasswordPlaceholder
        {
            get
            {
                return AppResources.LoginPagePasswordPlaceholder;
            }
        }
    }
}
