using System;
using FlagMySpace.Agnostic.Models.PersonModel;

namespace FlagMySpace.Agnostic.Models.SpaceModel
{
    public class SpaceModel : ISpaceModel
    {
        public IPersonModel Person { get; set; }

        public string Title { get; set; }

        public DateTime DateTaken { get; set; }

        public string Image { get; set; }
    }
}