namespace FlagMySpace.Agnostic.Models.PersonModel
{
    public interface IPersonModel
    {
        string Username { get; set; }
        string Email { get; set; }
        string Image { get; set; }
    }
}