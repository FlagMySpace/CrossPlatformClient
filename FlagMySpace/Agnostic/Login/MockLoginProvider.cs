using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Login
{
    public class MockLoginProvider : ILoginProvider
    {
        public Task<bool> Login()
        {
            return Task.FromResult(true);
        }

        public bool IsLoggedIn { get; set; }

        public Task<bool> LoginAsync()
        {
            IsLoggedIn = true;
            return Task.FromResult(true);
        }

        public Task<bool> LogoutAsync()
        {
            IsLoggedIn = false;
            return Task.FromResult(true);
        }
    }
}
