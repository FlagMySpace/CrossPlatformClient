using System.Threading.Tasks;

namespace FlagMySpace.Agnostic.Utilities.UsernameValidatorUtility
{
    public interface IUsernameValidatorUtility
    {
        Task ValidateUsername(string userName);
    }
}