using Prism.Ioc;
using Prism.Modularity;

using SmartBudget.Accounts.Views;

namespace SmartBudget.Accounts
{
    public class AccountsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AccountsView>();
            containerRegistry.RegisterForNavigation<AccountView>();
        }
    }
}