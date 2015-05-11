using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Services.Login
{
    public interface ILoginService
    {
        bool IsLoggedIn { get; set; }
        Task<bool> LoginAsync();
        Task<bool> LogoutAsync();
    }
}