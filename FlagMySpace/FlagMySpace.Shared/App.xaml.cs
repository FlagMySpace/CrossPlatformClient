using FlagMySpace.Bootstrap;
using Parse;

namespace FlagMySpace
{
    public partial class App
    {
        public App(Bootstrapper bootstrapper)
        {
            InitializeComponent();
            bootstrapper.Run(this);
            ParseClient.Initialize("L3POUewF4K1RgkRtKcZTDLne4Zp2kCgwQUmeW0Ru",
                             "5qgD6FO6sAR4NWN5FehNtuaGBqHXIikQSg7yj1fu");
        }
    }
}
