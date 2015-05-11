using System;
using FlagMySpace.Agnostic.Models.PersonModel;

namespace FlagMySpace.Agnostic.Models.SpaceModel
{
    public interface ISpaceModel
    {
        IPersonModel Person { get; set; }
        string Title { get; set; }
        DateTime DateTaken { get; set; }
        string Image { get; set; }
    }
}