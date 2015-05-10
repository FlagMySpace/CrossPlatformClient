using System;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Resources;

namespace FlagMySpace.Agnostic.Register
{
    public class MockUsernameValidatorUtility : IUsernameValidatorUtility
    {
        /// <exception cref="FormatException">Username invalid.</exception>
        public Task ValidateUsername(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new FormatException(Resource.MockUsernameValidatorUtility_ValidateUsername_Username_must_not_be_empty);
            }
            return Task.FromResult<object>(null);
        }
    }
}
