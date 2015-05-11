using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Services.RegisterService
{
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(string username, string password, string confrimPassword, string email);
    }
}
