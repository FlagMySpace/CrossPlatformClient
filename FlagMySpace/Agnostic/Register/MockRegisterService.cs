using System;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Utilities;

namespace FlagMySpace.Agnostic.Register
{
    public class MockRegisterService : IRegisterService
    {
        private readonly IUsernameValidatorUtility _usernameValidatorUtility;
        private readonly PasswordValidatorUtility _passwordValidatorUtility;
        private readonly EmailValidatorUtility _emailValidatorUtility;

        public MockRegisterService(IUsernameValidatorUtility usernameValidatorUtility, PasswordValidatorUtility passwordValidatorUtility, EmailValidatorUtility emailValidatorUtility)
        {
            _usernameValidatorUtility = usernameValidatorUtility;
            _passwordValidatorUtility = passwordValidatorUtility;
            _emailValidatorUtility = emailValidatorUtility;
        }

        public Task<bool> RegisterAsync(string username, string password, string confirmPassword, string email)
        {
            _usernameValidatorUtility.ValidateUsername(username);
            _passwordValidatorUtility.ValidatePassword(password, confirmPassword);
            _emailValidatorUtility.ValidateEmail(email);
            return Task.FromResult(true);
        }
    }
}