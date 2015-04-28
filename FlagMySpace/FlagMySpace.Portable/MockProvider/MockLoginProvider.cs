using System.Threading.Tasks;
using FlagMySpace.Portable.ViewModels;

namespace FlagMySpace.Portable.MockProvider
{
    public class MockLoginProvider : ILoginProvider
    {
        public Task<bool> Login()
        {
            return Task.FromResult(true);
        }
    }
}
