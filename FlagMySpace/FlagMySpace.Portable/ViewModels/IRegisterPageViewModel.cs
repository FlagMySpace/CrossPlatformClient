using System.Windows.Input;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.ViewModels
{
    public interface IRegisterPageViewModel : IViewModel
    {
        string Title { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string PlaceholderUsername { get; set; }
        string PlaceholderPassword { get; set; }
        string PlaceholderConfirmPassword { get; set; }
        string PlaceholderEmail { get; set; }
        string TextRegister { get; set; }
        string ConfirmPassword { get; }
        string Email { get; }
        ICommand RegisterCommand { get; }
    }
}