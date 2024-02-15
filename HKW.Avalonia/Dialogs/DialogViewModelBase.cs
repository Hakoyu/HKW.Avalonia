using CommunityToolkit.Mvvm.ComponentModel;
using HanumanInstitute.MvvmDialogs;

namespace HKW.HKWAvalonia.Dialogs;

/// <summary>
/// 对话框基础视图模型
/// </summary>
public partial class DialogViewModelBase : ObservableObject, IModalDialogViewModel, ICloseable
{
    /// <inheritdoc/>
    public bool? DialogResult { get; set; }

    /// <summary>
    /// 关闭对话框
    /// </summary>
    /// <param name="args"></param>
    public void Close(EventArgs? args = null)
    {
        RequestClose?.Invoke(this, args ?? new());
    }

    /// <inheritdoc/>
    public event EventHandler? RequestClose;
}
