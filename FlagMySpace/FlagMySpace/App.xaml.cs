using FlagMySpace.Bootstrap;

namespace FlagMySpace
{
    public partial class App
    {
        public App(Bootstrapper bootstrapper)
        {
            InitializeComponent();
            bootstrapper.Run(this);
        }
    }
}
