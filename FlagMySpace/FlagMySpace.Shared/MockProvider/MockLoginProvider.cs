using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.Shared.ViewModels;

namespace FlagMySpace.Shared.MockProvider
{
    public class MockLoginProvider : ILoginProvider
    {
        public Task<bool> Login()
        {
            return Task.FromResult(true);
        }
    }
}
