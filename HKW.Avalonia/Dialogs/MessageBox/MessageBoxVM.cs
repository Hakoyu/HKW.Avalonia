using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace HKW.HKWAvalonia.Dialogs;

/// <summary>
/// 消息窗口视图模型
/// </summary>
public partial class MessageBoxVM : DialogViewModelBase
{
    /// <summary>
    /// 通过平台自动设置按钮位置
    /// <para>
    /// 在安卓中自动反转按钮位置
    /// </para>
    /// </summary>
    [DefaultValue(true)]
    public static bool SetButtonPositionByPlatform { get; set; } = true;

    /// <summary>
    /// 默认信息图标
    /// </summary>
    public static IconText DefaultInformationIcon { get; set; } =
        new()
        {
            Text = "\uea07",
            Foreground = Brushes.Aqua,
            FontSize = 64
        };

    /// <summary>
    /// 默认警告图标
    /// </summary>
    public static IconText DefaultWarningIcon { get; set; } =
        new()
        {
            Text = "\uea07",
            Foreground = Brushes.Yellow,
            FontSize = 64
        };

    /// <summary>
    /// 默认错误图标
    /// </summary>
    public static IconText DefaultErrorIcon { get; set; } =
        new()
        {
            Text = "\uea0d",
            Foreground = Brushes.Red,
            FontSize = 64
        };

    /// <summary>
    /// 默认停止图标
    /// </summary>
    public static IconText DefaultStopIcon { get; set; } =
        new()
        {
            Text = "\uea0e",
            Foreground = Brushes.Red,
            FontSize = 64
        };

    /// <summary>
    /// 默认感叹图标
    /// </summary>
    public static IconText DefaultExclamationIcon { get; set; } =
        new()
        {
            Text = "\uea08",
            Foreground = Brushes.Lime,
            FontSize = 64
        };

    /// <summary>
    /// 获取默认图标文本
    /// </summary>
    /// <param name="image"></param>
    /// <returns>图标文本</returns>
    public static IconText? GetDefaultIconText(MessageBoxImage image)
    {
        return image switch
        {
            MessageBoxImage.None => null,
            MessageBoxImage.Information => DefaultInformationIcon,
            MessageBoxImage.Warning => DefaultWarningIcon,
            MessageBoxImage.Error => DefaultErrorIcon,
            MessageBoxImage.Stop => DefaultStopIcon,
            MessageBoxImage.Exclamation => DefaultExclamationIcon,
            _ => throw new NotImplementedException(),
        };
    }

    /// <inheritdoc/>
    public MessageBoxVM()
    {
        if (SetButtonPositionByPlatform)
            InvertButtonPosition = OperatingSystem.IsAndroid();
#if DEBUG
        Icon = MessageBoxImage.Information;
#endif
    }

    /// <inheritdoc/>
    /// <param name="message">消息</param>
    public MessageBoxVM(string message)
        : this()
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
    /// <para>
    /// 如果设置为 <see langword="null"/> 需要启用 <see cref="DialogHostSettings.CloseOnClickAway"/>
    /// </para>
    /// <para>
    /// 否则你可能无法关闭窗口
    /// </para>
    /// </summary>
    [DefaultValue(MessageBoxButton.Ok)]
    [ObservableProperty]
    private MessageBoxButton? _button = MessageBoxButton.Ok;

    /// <summary>
    /// 图标
    /// </summary>
    [DefaultValue(MessageBoxImage.None)]
    [ObservableProperty]
    private MessageBoxImage _icon = MessageBoxImage.None;

    partial void OnIconChanged(MessageBoxImage value)
    {
        IconText = GetDefaultIconText(value);
    }

    /// <summary>
    /// 反转按钮位置
    /// <para>
    /// 默认 Yes 或 OK 是在左边 No Cancel 在右边
    /// </para>
    /// </summary>
    [DefaultValue(false)]
    [ObservableProperty]
    private bool _invertButtonPosition;

    /// <summary>
    /// OK按钮内容
    /// </summary>
    [DefaultValue("OK")]
    [ObservableProperty]
    private string _oKContent = "OK";

    /// <summary>
    /// Cancel按钮内内容
    /// </summary>
    [DefaultValue("Cancel")]
    [ObservableProperty]
    private string _cancelContent = "Cancel";

    /// <summary>
    /// Yes按钮内容
    /// </summary>
    [DefaultValue("Yes")]
    [ObservableProperty]
    private string _yesContent = "Yes";

    /// <summary>
    /// No按钮内容
    /// </summary>
    [DefaultValue("No")]
    [ObservableProperty]
    private string _noContent = "No";

    /// <summary>
    /// 图标文本
    /// </summary>
    [ObservableProperty]
    private IconText? _iconText;

    // TODO: DefaultButton
    /// <summary>
    /// 默认按钮 (即按下Enter时触发的按钮)
    /// </summary>
    //[DefaultValue(DefaultButton.OKOrYes)]
    //[ObservableProperty]
    //private DefaultButton _defaultButton = DefaultButton.OKOrYes;

    #endregion

    #region Command

    [RelayCommand]
    private void OK()
    {
        Close(true);
    }

    [RelayCommand]
    private void Cancel()
    {
        Close(null);
    }

    [RelayCommand]
    private void Yes()
    {
        Close(true);
    }

    [RelayCommand]
    private void No()
    {
        Close(false);
    }
    #endregion
}
