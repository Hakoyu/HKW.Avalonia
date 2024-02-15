using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKW.HKWAvalonia.Dialogs;

public static class DialogExtensions
{
    public static async Task<bool?> ShowMessageBoxAsync(
        this IDialogService service,
        INotifyPropertyChanged ownerViewModel,
        MessageBoxVM messageBox,
        DialogHostSettings? hostSettings = null
    )
    {
        hostSettings ??= new DialogHostSettings(messageBox);
        await service.ShowDialogHostAsync(ownerViewModel, hostSettings);
        return messageBox.DialogResult;
    }

    /// <summary>
    /// 添加HKW提示框
    /// </summary>
    /// <param name="viewLocator"></param>
    /// <returns></returns>
    public static IViewLocator AddHKWDialogs(this StrongViewLocator viewLocator)
    {
        viewLocator.Register<MessageBoxVM, MessageBoxView>();
        return viewLocator;
    }
}
