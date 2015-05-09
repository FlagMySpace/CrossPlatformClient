using System.Threading.Tasks;
using FlagMySpace.Agnostic.IoC;

namespace FlagMySpace.Agnostic.Register
{
    class MockRegisterService : IRegisterService
    {
        private readonly IIoC _ioC;

        public MockRegisterService(IIoC ioC)
        {
            _ioC = ioC;
        }

        public Task<ResultModel> RegisterAsync(string username, string password, string email)
        {
            var result = _ioC.Get<ResultModel>();
            result.Status = true;
            result.Message = "Registration success!";
            return Task.FromResult(result);
        }
    }
}