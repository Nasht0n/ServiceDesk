using Caliburn.Micro;
using NotifyManager.ViewModels;
using System.Windows;

namespace NotifyManager
{
    public class AppBootstrapper:BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<AuthenticationViewModel>();
        }
    }
}
