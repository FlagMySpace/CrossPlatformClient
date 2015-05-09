using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Utilities
{
    public interface IUsernameValidatorUtility
    {
        Task ValidateUsername(string userName);
    }
}