using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

using SmartBudget.Accounts;
using SmartBudget.Core;
using SmartBudget.Main;
using SmartBudget.WPF.Core.Dialogs;
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
            containerRegistry.RegisterSingleton<IRegionDialogService, RegionDialogService>();

            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<AccountsModule>();
        }
    }
}