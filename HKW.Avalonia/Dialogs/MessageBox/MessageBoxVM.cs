using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Microsoft.Extensions.Logging;

namespace HKW.HKWAvalonia.Dialogs;

/// <summary>
/// 消息窗口视图模型
/// </summary>
public partial class MessageBoxVM : DialogViewModelBase
{
    /// <inheritdoc/>
    public MessageBoxVM() { }

    /// <inheritdoc/>
    /// <param name="message">消息</param>
    public MessageBoxVM(string message)
    {
        Message = message;
    }

    #region Property
    /// <summary>
    /// 标题
    /// </summary>
    [ObservableProperty]
    private string? _title;

    /// <summary>
    /// 消息
    /// </summary>
    [ObservableProperty]
    private string? _message;

    /// <summary>
    /// 按钮
    /// </summary>
    [ObservableProperty]
    private MessageBoxButton _button = MessageBoxButton.Ok;

    /// <summary>
    /// 反转按钮位置
    /// <para>
    /// 默认 Yes 或 OK 是在左边 No Cancel 在右边
    /// </para>
    /// </summary>
    [ObservableProperty]
    private bool _invertButtonPosition;

    #endregion

    #region Command

    [RelayCommand]
    private void OK()
    {
        DialogResult = true;
        Close();
    }

    [RelayCommand]
    private void Cancel()
    {
        DialogResult = null;
        Close();
    }

    [RelayCommand]
    private void Yes()
    {
        DialogResult = true;
        Close();
    }

    [RelayCommand]
    private void No()
    {
        DialogResult = false;
        Close();
    }
    #endregion
}
