using Prism.Regions;

using System.Windows;

namespace SmartBudget.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            // view discovery
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(DashboardView));
        }
    }
}