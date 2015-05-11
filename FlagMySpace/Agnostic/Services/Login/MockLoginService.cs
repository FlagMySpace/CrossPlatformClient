using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Services.Login
{
    public class MockLoginService : ILoginService
    {
        public bool IsLoggedIn { get; set; }

        public Task<bool> LoginAsync()
        {
            return Task.FromResult(true);
        }

        public Task<bool> LogoutAsync()
        {
            return Task.FromResult(true);
        }
    }
}
