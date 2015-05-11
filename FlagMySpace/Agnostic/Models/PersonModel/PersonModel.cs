namespace FlagMySpace.Agnostic.Models.PersonModel
{
    public class PersonModel : IPersonModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}