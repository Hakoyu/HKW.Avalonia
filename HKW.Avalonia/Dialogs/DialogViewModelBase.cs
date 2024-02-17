using CommunityToolkit.Mvvm.ComponentModel;
using HanumanInstitute.MvvmDialogs;
using System.ComponentModel;

namespace HKW.HKWAvalonia.Dialogs;

/// <summary>
/// 对话框基础视图模型
/// </summary>
public abstract partial class DialogViewModelBase
    : ObservableObject,
        IModalDialogViewModel,
        ICloseable
{
    /// <inheritdoc/>
    public bool? DialogResult { get; set; }

    /// <summary>
    /// 关闭对话框
    /// </summary>
    /// <param name="dialogResult">对话框结果</param>
    /// <returns>成功关闭为 <see langword="true"/> 失败为 <see langword="false"/></returns>
    public virtual bool Close(bool? dialogResult)
    {
        var c = new CancelEventArgs();
        DialogClosing?.Invoke(this, c);
        if (c.Cancel)
            return false;
        DialogResult = dialogResult;
        var e = new EventArgs();
        RequestClose?.Invoke(this, e);
        DialogClosed?.Invoke(this, e);
        return true;
    }

    /// <inheritdoc/>
    public event EventHandler? RequestClose;

    /// <summary>
    /// 对话框关闭前
    /// </summary>
    public event DialogClosing<DialogViewModelBase>? DialogClosing;

    /// <summary>
    /// 对话框关闭后
    /// </summary>
    public event DialogClosed<DialogViewModelBase>? DialogClosed;
}
