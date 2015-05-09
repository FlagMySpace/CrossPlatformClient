using System.Threading.Tasks;
using FlagMySpace.Agnostic.Register;

namespace FlagMySpace.Agnostic.Login
{
    public interface ILoginService
    {
        bool IsLoggedIn { get; set; }
        Task<ResultModel> LoginAsync();
        Task<ResultModel> LogoutAsync();
    }
}