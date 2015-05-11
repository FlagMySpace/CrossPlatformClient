using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Services.Register
{
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(string username, string password, string confrimPassword, string email);
    }
}
