using FlagMySpace.Agnostic.Models.Person;

namespace FlagMySpace.Agnostic.Models.Space
{
    public class SpaceModel : ISpaceModel
    {
        public IPersonModel Person { get; set; }

        public string Title { get; set; }

        public string DateTaken { get; set; }

        public string Image { get; set; }
    }
}