using System;
using System.Text.RegularExpressions;
using FlagMySpace.Agnostic.Resources;

namespace FlagMySpace.Agnostic.Utilities
{
    public class EmailValidatorUtility
    {
        public void ValidateEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            if (!match.Success)
            {
                throw new FormatException(Resource.EmailValidatorUtility_IsValidEmail_Invalid_email_address);
            }
        }
    }
}
