using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlagMySpace.Agnostic.IoC;
using FlagMySpace.Agnostic.Services.SpaceService;
using FlagMySpace.Portable.Pages.StreamPage;
using FlagMySpace.Portable.ViewFactory;
using FlagMySpace.Portable.ViewModels.StreamPageViewModel;
using Xamarin.Forms;

namespace FlagMySpace.Portable.Pages.HomePage
{
    public partial class HomePage : IHomePage
    {
        private readonly IIoC _ioC;
        private readonly IViewFactory _viewFactory;
        private event Func<Task> OnInitializeAsync; 

        public HomePage(IIoC ioC, IViewFactory viewFactory)
        {
            _ioC = ioC;
            _viewFactory = viewFactory;
            InitializeComponent();
            OnInitializeAsync += HomePage_OnInitializeAsync;
            if (OnInitializeAsync != null) OnInitializeAsync.Invoke();
        }

        Task HomePage_OnInitializeAsync()
        {
            if (_viewFactory.CountMapping > 0)
            {
                var freshPage = (Page) _viewFactory.Get<IStreamPageViewModel<FreshSpaceService>>();
                freshPage.Title = "Fresh";
                Children.Add(freshPage);
            }
            return Task.FromResult<object>(null);
        }
    }
}
