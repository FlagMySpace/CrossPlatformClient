using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.SpaceModel;

namespace FlagMySpace.Agnostic.RepositoryServices.SpaceRepositoryService
{
    public interface ISpaceRepositoryService
    {
        Task<ICollection<ISpaceModel>> GetSpaces();
    }
}
