using FlagMySpace.Shared.ViewFactory;
using Ninject;
using Xamarin.Forms;

namespace FlagMySpace.Shared.Bootstrap
{
    public abstract class Bootstrapper
    {
        protected Application Application { get; set; }

        public void Run(Application application)
        {
            Application = application;
            var kernel = ConfigureKernel();
            var viewFactory = kernel.Get<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(kernel);
        }

        protected abstract IKernel ConfigureKernel();
        protected abstract void RegisterViews(IViewFactory viewFactory);
        protected abstract void ConfigureApplication(IKernel kernel);
    }
}