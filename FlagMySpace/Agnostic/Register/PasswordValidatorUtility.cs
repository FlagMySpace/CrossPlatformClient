using System;
using FlagMySpace.Agnostic.Resources;

namespace FlagMySpace.Agnostic.Register
{
    public class PasswordValidatorUtility
    {
        /// <exception cref="FormatException">Password mismatch or empty.</exception>
        public void ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new FormatException(Resource.PasswordValidatorUtility_ValidatePassword_Password_must_not_be_empty);
            }

            if (!password.Equals(confirmPassword))
            {
                throw new FormatException(Resource.PasswordValidatorUtility_ValidatePassword_Password_mismatch);
            }
        }
    }
}
