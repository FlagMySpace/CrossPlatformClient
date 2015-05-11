using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.SpaceModel;
using FlagMySpace.Agnostic.Repositories.PersonRepository;

namespace FlagMySpace.Agnostic.Repositories.SpaceRepository
{
    public class LocalSpaceRepository : ISpaceRepository
    {
        private readonly IPersonRepository _personRepository;
        private ICollection<ISpaceModel> _spaceRepository;
        private event Func<Task> OnInitializeAsync;

        public LocalSpaceRepository(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            OnInitializeAsync += OnOnInitializeAsync;
            if (OnInitializeAsync != null) OnInitializeAsync.Invoke();
        }

        private async Task OnOnInitializeAsync()
        {
            var persons = (await _personRepository.Persons()).ToArray();
            _spaceRepository = new ObservableCollection<ISpaceModel>()
            {
                new SpaceModel(){Title = "Tugu Pahlawan", DateTaken = DateTime.Now - TimeSpan.FromHours(3), Person = persons[0], Image = "http://cushtravel.com/wp-content/uploads/2013/12/heroes-monument-in-surabaya.jpg"},
                new SpaceModel(){Title = "Kebun Binatang Surabaya", DateTaken = DateTime.Now - TimeSpan.FromHours(2), Person = persons[1], Image = "http://upload.wikimedia.org/wikipedia/commons/5/54/Surabaya_Zoo.JPG"},
                new SpaceModel(){Title = "Gang Dolly", DateTaken = DateTime.Now, Person = persons[2], Image = "https://simomot.files.wordpress.com/2014/06/gang-dolly.jpg"}
            };
        }

        public Task<ICollection<ISpaceModel>> Spaces()
        {
            return Task.FromResult(_spaceRepository);
        }
    }
}