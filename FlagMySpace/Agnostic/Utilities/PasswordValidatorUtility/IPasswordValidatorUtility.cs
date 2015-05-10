using System;

namespace FlagMySpace.Agnostic.Utilities.PasswordValidatorUtility
{
    public interface IPasswordValidatorUtility
    {
        /// <exception cref="FormatException">Password mismatch or empty.</exception>
        void ValidatePassword(string password, string confirmPassword);
    }
}