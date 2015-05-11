using System.Collections.Generic;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.PersonModel;

namespace FlagMySpace.Agnostic.Repositories.PersonRepository
{
    public interface IPersonRepository
    {
        Task<ICollection<IPersonModel>> Persons();
    }
}