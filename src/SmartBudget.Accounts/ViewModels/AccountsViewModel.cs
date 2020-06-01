using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using SmartBudget.Domain.Models;

using System.Collections.ObjectModel;
using System.Linq;

namespace SmartBudget.Accounts.ViewModels
{
    public class AccountsViewModel : BindableBase, INavigationAware
    {
        IRegionManager _regionManager;

        private string _title = "Accounts";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        public ObservableCollection<Account> BankAccounts => (ObservableCollection<Account>)Accounts.Where(a => a.Type == AccountType.Bank);
        public ObservableCollection<Account> CreditAccounts => (ObservableCollection<Account>)Accounts.Where(a => a.Type == AccountType.CreditCard);

        public DelegateCommand<Account> AccountSelectedCommand { get; private set; }

        public AccountsViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            AccountSelectedCommand = new DelegateCommand<Account>(AccountSelected);
            CreateAccounts();
        }

        private void AccountSelected(Account account)
        {
            var parameters = new NavigationParameters();
            parameters.Add("account", account);

            if (account != null)
                _regionManager.RequestNavigate("ContentRegion", "AccountDetail", parameters);
        }

        private void CreateAccounts()
        {
            var accounts = new ObservableCollection<Account>();
            for (int i = 0; i < 3; i++)
            {
                accounts.Add(new Account()
                {
                    Name = "Checking",
                    Type = AccountType.Bank,
                    AccountNumber = i.ToString(),
                    RoutingNumber = i.ToString(),
                    Balance = 250
                });
            }
            for (int i = 0; i < 3; i++)
            {
                accounts.Add(new Account()
                {
                    Name = "Visa",
                    Type = AccountType.CreditCard,
                    AccountNumber = i.ToString(),
                    RoutingNumber = i.ToString(),
                    Balance = 250
                });
            }

            Accounts = accounts;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}