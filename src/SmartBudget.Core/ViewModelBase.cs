using Prism.Mvvm;
using Prism.Regions;

using System;

namespace SmartBudget.Core
{
    public class ViewModelBase : BindableBase, IConfirmNavigationRequest
    {
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // reuse view instance by default
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}