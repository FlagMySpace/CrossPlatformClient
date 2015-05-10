using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Register
{
    public interface IUsernameValidatorUtility
    {
        Task ValidateUsername(string userName);
    }
}