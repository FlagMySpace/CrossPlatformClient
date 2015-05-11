using FlagMySpace.Agnostic.Models.Person;

namespace FlagMySpace.Agnostic.Models.Space
{
    public interface ISpaceModel
    {
        IPersonModel Person { get; set; }
        string Title { get; set; }
        string DateTaken { get; set; }
        string Image { get; set; }
    }
}