using Prism.Mvvm;
using Prism.Regions;

namespace SmartBudget.Accounts.ViewModels
{
    public class AccountsViewModel : BindableBase, INavigationAware
    {
        private string _title = "Accounts";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public AccountsViewModel()
        {

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