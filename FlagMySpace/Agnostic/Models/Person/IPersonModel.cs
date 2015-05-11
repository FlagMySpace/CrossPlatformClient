namespace FlagMySpace.Agnostic.Models.Person
{
    public interface IPersonModel
    {
        string Username { get; set; }
        string Email { get; set; }
        string Image { get; set; }
    }
}