using System.Threading.Tasks;
using FlagMySpace.Agnostic.EventAggregator;
using FlagMySpace.Portable.ViewModels;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.Pages
{
    public partial class LoginPage : ContentPage, ILoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
