using System;
using System.Text.RegularExpressions;
using FlagMySpace.Agnostic.Resources;

namespace FlagMySpace.Agnostic.Utilities
{
    public class EmailValidatorUtility
    {
        /// <exception cref="FormatException">Invalid email address format.</exception>
        /// <exception cref="RegexMatchTimeoutException">Timeout when trying to validate email address</exception>
        public void ValidateEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var match = regex.Match(email);
                if (!match.Success)
                {
                    throw new FormatException(Resource.EmailValidatorUtility_IsValidEmail_Invalid_email_address);
                }
            }
            catch (RegexMatchTimeoutException regexMatchTimeoutException)
            {
                throw new RegexMatchTimeoutException(Resource.EmailValidatorUtility_ValidateEmail_Timeout_when_trying_to_validate_email_address, regexMatchTimeoutException);
            }
        }
    }
}
