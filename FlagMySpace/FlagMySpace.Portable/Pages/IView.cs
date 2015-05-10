using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace FlagMySpace.Portable.Pages
{
    public interface IView
    {
        object BindingContext { get; set; }
        INavigation Navigation { get; }
    }
}
