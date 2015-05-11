namespace FlagMySpace.Agnostic.Models.Person
{
    public class PersonModel : IPersonModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}