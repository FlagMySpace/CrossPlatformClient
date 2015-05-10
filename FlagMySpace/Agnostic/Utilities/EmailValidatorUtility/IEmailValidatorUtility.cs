using System;
using System.Text.RegularExpressions;

namespace FlagMySpace.Agnostic.Utilities.EmailValidatorUtility
{
    public interface IEmailValidatorUtility
    {
        /// <exception cref="FormatException">Invalid email address format.</exception>
        /// <exception cref="RegexMatchTimeoutException">Timeout when trying to validate email address</exception>
        void ValidateEmail(string email);
    }
}