using Prism.Mvvm;
using Prism.Regions;

using SmartBudget.Domain.Models;

namespace SmartBudget.Accounts.ViewModels
{
    public class AccountViewModel : BindableBase, INavigationAware
    {
        private IRegionManager _regionManager;

        private Account _account;

        public Account Account
        {
            get { return _account; }
            set { SetProperty(ref _account, value); }
        }

        public AccountViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var account = navigationContext.Parameters["account"] as Account;
            if (account != null)
                Account = account;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var account = navigationContext.Parameters["account"] as Account;
            if (account != null)
                return Account != null && Account.Name == account.Name;
            else
                return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}