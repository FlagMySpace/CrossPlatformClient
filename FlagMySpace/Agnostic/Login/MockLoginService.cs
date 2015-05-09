using System.Threading.Tasks;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Agnostic.Register;

namespace FlagMySpace.Agnostic.Login
{
    public class MockLoginService : ILoginService
    {
        private readonly IIoC _ioC;

        public MockLoginService(IIoC ioC)
        {
            _ioC = ioC;
        }

        public Task<bool> Login()
        {
            return Task.FromResult(true);
        }

        public bool IsLoggedIn { get; set; }

        public Task<ResultModel> LoginAsync()
        {
            var result = _ioC.Get<ResultModel>();
            result.Status = true;
            result.Message = "Login success!";
            return Task.FromResult(result);
        }

        public Task<ResultModel> LogoutAsync()
        {
            var result = _ioC.Get<ResultModel>();
            result.Status = true;
            result.Message = "Logout success!";
            return Task.FromResult(result);
        }
    }
}
