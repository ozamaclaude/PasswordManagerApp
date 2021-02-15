using PasswordManagerApp.Services;
using PasswordManagerApp.Views;
using PasswordManagerApp.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace PasswordManagerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<ServiceDialog, ViewModels.ServiceDialogViewModel>();
            containerRegistry.Register<IAccountFileReader, AccountFileReader>();
        }
    }
}
