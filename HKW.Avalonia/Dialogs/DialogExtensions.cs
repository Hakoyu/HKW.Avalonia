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
    public static StrongViewLocator AddHKWDialogs(this StrongViewLocator viewLocator)
    {
        viewLocator.Register<MessageBoxVM, MessageBoxView>();
        return viewLocator;
    }
}

//public class DialogHostDialogFactory : DialogFactoryBase
//{
//    //
//    // 摘要:
//    //     Initializes a new instance of a FrameworkDialog.
//    //
//    // 参数:
//    //   chain:
//    //     If the dialog is not handled by this class, calls this other handler next.
//    public DialogHostDialogFactory(IDialogFactory? chain = null)
//        : base(chain) { }

//    public override async Task<object?> ShowDialogAsync<TSettings>(IView? owner, TSettings settings)
//    {
//        return (!((object)settings is DialogHostSettings settings2))
//            ? (
//                await base.ShowDialogAsync(owner, settings)
//                    .ConfigureAwait(continueOnCapturedContext: true)
//            )
//            : (await ShowDialogHostAsync(owner, settings2));
//    }

//    private async Task<object?> ShowDialogHostAsync(IView? owner, DialogHostSettings settings)
//    {
//        if (owner == null)
//        {
//            throw new ArgumentNullException("owner");
//        }

//        DialogHostView view = new DialogHostView(settings);
//        if (view.ViewModel != null)
//        {
//            GetDialogManager().HandleDialogEvents(view.ViewModel, view);
//        }

//        await view.ShowDialogAsync(owner).ConfigureAwait(continueOnCapturedContext: true);
//        return view.DialogResult;
//    }
//}
