using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

using SmartBudget.WPF.Views;

using System.Windows;

namespace SmartBudget.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Main.MainModule>();
            moduleCatalog.AddModule<Accounts.AccountsModule>();
        }
    }
}