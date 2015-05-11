using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.PersonModel;

namespace FlagMySpace.Agnostic.Repositories.PersonRepository
{
    public class LocalPersonRepository : IPersonRepository
    {
        private readonly ICollection<IPersonModel> _personList;

        public LocalPersonRepository()
        {
            _personList = new ObservableCollection<IPersonModel>()
            {
                new PersonModel(){Username = "yowanda6361", Email = "yowanda6361@gmail.com", Image = "https://fbcdn-profile-a.akamaihd.net/hprofile-ak-xtf1/v/t1.0-1/p160x160/11116454_10205451129671233_7096350416150775262_n.jpg?oh=33a87aa7df3beb35925fc21b2d96df77&oe=55C17D52&__gda__=1440352196_f6c8b36bea5e1b77ad5bdc0421e08b4c"},
                new PersonModel(){Username = "lheliy", Email = "zahroh.lailiyah@gmail.com", Image = "https://fbcdn-profile-a.akamaihd.net/hprofile-ak-xfp1/v/t1.0-1/p160x160/10399442_10204246132654626_5910715620656434466_n.jpg?oh=0ac424c2cf504639ed1f75890a42cfb1&oe=55CB7612&__gda__=1439544709_51737a610eeaf4a516fc3c5ee5d4d2ec"},
                new PersonModel(){Username = "sigitbn", Email = "sigit.kariagil@gmail.com", Image = "https://fbcdn-profile-a.akamaihd.net/hprofile-ak-xfp1/v/t1.0-1/c0.39.160.160/p160x160/1982321_814449698583857_1145462521_n.jpg?oh=4e072c7112830aeb1e421a00961b512a&oe=55D63A95&__gda__=1439634809_284a99e0efbd0ef957035370b6bd0c00"}
            };
        }

        public Task<ICollection<IPersonModel>> Persons()
        {
            return Task.FromResult(_personList);
        }
    }
}
