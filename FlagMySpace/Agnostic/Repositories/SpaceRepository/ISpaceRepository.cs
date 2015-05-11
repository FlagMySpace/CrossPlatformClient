using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.SpaceModel;

namespace FlagMySpace.Agnostic.Repositories.SpaceRepository
{
    public interface ISpaceRepository
    {
        Task<ICollection<ISpaceModel>> Spaces();
    }
}