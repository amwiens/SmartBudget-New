using Prism.Services.Dialogs;

using System;

namespace SmartBudget.Core
{
    public interface IRegionDialogService
    {
        void Show(string name, IDialogParameters dialogParameters, Action<IDialogResult> callback);
    }
}