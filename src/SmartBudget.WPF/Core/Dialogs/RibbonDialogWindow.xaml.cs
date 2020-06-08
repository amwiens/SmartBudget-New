using Prism.Services.Dialogs;

namespace SmartBudget.WPF.Core.Dialogs
{
    /// <summary>
    /// Interaction logic for RibbonDialogWindow.xaml
    /// </summary>
    public partial class RibbonDialogWindow : IDialogWindow
    {
        public RibbonDialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}