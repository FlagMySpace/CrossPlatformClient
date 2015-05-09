using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Utilities
{
    public class MockUsernameValidatorUtility : IUsernameValidatorUtility
    {
        public Task ValidateUsername(string userName)
        {
            return Task.FromResult<object>(null);
        }
    }
}
