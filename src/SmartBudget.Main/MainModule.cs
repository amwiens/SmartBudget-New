using Prism.Ioc;
using Prism.Modularity;

using SmartBudget.Main.Views;

namespace SmartBudget.Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Dashboard>();
        }
    }
}