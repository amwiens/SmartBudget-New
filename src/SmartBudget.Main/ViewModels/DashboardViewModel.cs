using Prism.Mvvm;
using Prism.Regions;

namespace SmartBudget.Main.ViewModels
{
    public class DashboardViewModel : BindableBase, INavigationAware
    {
        private string _title = "Dashboard";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DashboardViewModel()
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