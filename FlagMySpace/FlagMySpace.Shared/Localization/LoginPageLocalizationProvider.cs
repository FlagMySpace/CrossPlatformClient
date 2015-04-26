using System;
using System.Collections.Generic;
using System.Text;
using FlagMySpace.Shared.ViewModels;

namespace FlagMySpace.Shared.Localization
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
