using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using SmartBudget.Core;

using System;

namespace SmartBudget.WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Smart Budget";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand<string> _navigateCommand;
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

        public MainWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
            _regionManager = regionManager;
            applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        void ExecuteNavigateCommand(string navigatePath)
        {
            if (string.IsNullOrEmpty(navigatePath))
                throw new ArgumentNullException();

            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath);
        }
    }
}