﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using SmartBudget.Domain.Models;

using System.Collections.ObjectModel;

namespace SmartBudget.Accounts.ViewModels
{
    public class FavoriteAccountsViewModel : BindableBase
    {
        IRegionManager _regionManager;

        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        public DelegateCommand<Account> AccountSelectedCommand { get; private set; }

        public FavoriteAccountsViewModel(IRegionManager regionManager)
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
                    AccountNumber = "1",
                    RoutingNumber = "2",
                    Balance = 250
                });
            }

            Accounts = accounts;
        }
    }
}