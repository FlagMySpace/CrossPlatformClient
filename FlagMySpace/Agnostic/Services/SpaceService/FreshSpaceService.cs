﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.Models.SpaceModel;
using FlagMySpace.Agnostic.Repositories.SpaceRepository;

namespace FlagMySpace.Agnostic.Services.SpaceService
{
    public class FreshSpaceService : ISpaceService
    {
        private readonly ISpaceRepository _spaceRepository;

        public FreshSpaceService(ISpaceRepository spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        public async Task<ICollection<ISpaceModel>> GetSpaces()
        {
            var freshResult = (await _spaceRepository.Spaces()).OrderBy(model => model.DateTaken).ToList();
            return freshResult;
        }
    }
}