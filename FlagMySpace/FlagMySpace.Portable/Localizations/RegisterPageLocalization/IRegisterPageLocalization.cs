namespace FlagMySpace.Portable.Localization.RegisterPageLocalization
{
    public interface IRegisterPageLocalization
    {
        string Title { get; }
        string PlaceholderPassword { get; }
        string PlaceholderEmail { get; }
        string TextRegister { get; }
        string PlaceholderConfirmPassword { get; }
        string PlaceholderUsername { get; }
        string RegisterInformation { get; }
        string Ok { get; }
        string RegisterSuccessTitle { get; }
        string RegisterSuccessMessage { get; }
        string Error { get; }
    }
}