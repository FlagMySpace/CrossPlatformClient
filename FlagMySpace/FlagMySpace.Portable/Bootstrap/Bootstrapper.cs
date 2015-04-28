using FlagMySpace.Portable.ViewFactory;
using Ninject;
using Xamarin.Forms;

namespace FlagMySpace.Portable.Bootstrap
{
    public abstract class Bootstrapper
    {

        protected abstract IKernel ConfigureKernel();
        protected abstract void RegisterViews(IViewFactory viewFactory);
        protected abstract void ConfigureApplication(IKernel kernel);
    }
}