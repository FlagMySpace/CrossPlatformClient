using System.Collections.Generic;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.SpaceModel;

namespace FlagMySpace.Agnostic.Services.SpaceService
{
    public interface ISpaceService
    {
        Task<ICollection<ISpaceModel>> GetSpaces();
    }
}
