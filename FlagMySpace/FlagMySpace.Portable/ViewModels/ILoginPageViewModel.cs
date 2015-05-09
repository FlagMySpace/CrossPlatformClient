using System.Windows.Input;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels
{
    public interface ILoginPageViewModel : IViewModel
    {
        string Title { get; set; }
        string Username { get; set; }
        string UsernamePlaceholder { get; set; }
        string Password { get; set; }
        string PasswordPlaceholder { get; set; }
        string ButtonLoginText { get; set; }
        ICommand LoginCommand { get; }
    }
}