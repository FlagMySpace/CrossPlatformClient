using FlagMySpace.Agnostic.Models.PersonModel;

namespace FlagMySpace.Agnostic.Models.SpaceModel
{
    public interface ISpaceModel
    {
        IPersonModel Person { get; set; }
        string Title { get; set; }
        string DateTaken { get; set; }
        string Image { get; set; }
    }
}