using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Utilities.EmailValidatorUtility;
using FlagMySpace.Agnostic.Utilities.PasswordValidatorUtility;
using FlagMySpace.Agnostic.Utilities.UsernameValidatorUtility;

namespace FlagMySpace.Agnostic.Services.Register
{
    public class MockRegisterService : IRegisterService
    {
        private readonly IUsernameValidatorUtility _usernameValidatorUtility;
        private readonly IPasswordValidatorUtility _passwordValidatorUtility;
        private readonly IEmailValidatorUtility _emailValidatorUtility;

        public MockRegisterService(
            IUsernameValidatorUtility usernameValidatorUtility, 
            IPasswordValidatorUtility passwordValidatorUtility, 
            IEmailValidatorUtility emailValidatorUtility)
        {
            _usernameValidatorUtility = usernameValidatorUtility;
            _passwordValidatorUtility = passwordValidatorUtility;
            _emailValidatorUtility = emailValidatorUtility;
        }

        /// <exception cref="RegexMatchTimeoutException">Timeout when trying to validate email address</exception>
        public Task<bool> RegisterAsync(string username, string password, string confirmPassword, string email)
        {
            _usernameValidatorUtility.ValidateUsername(username);
            _passwordValidatorUtility.ValidatePassword(password, confirmPassword);
            _emailValidatorUtility.ValidateEmail(email);
            return Task.FromResult(true);
        }
    }
}