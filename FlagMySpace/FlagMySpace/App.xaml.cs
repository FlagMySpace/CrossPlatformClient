using FlagMySpace.Bootstrap;

namespace FlagMySpace
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            var bootstrapper = new AppBoostrapper(this);
            bootstrapper.Run();
        }
    }
}
