namespace FlagMySpace.Portable.Localization
{
    public interface ILoginPageLocalizationProvider
    {
        string ButtonLoginText { get; }
        string UsernamePlaceholder { get; }
        string PasswordPlaceholder { get; }
        string LoginFailedTitle { get; }
        string LoginFailedMessage { get; }
        string LoginFailedCancel { get; }
        string TitleText { get; }
        string ErrorLoginEmpty { get; }
    }
}