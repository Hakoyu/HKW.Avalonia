using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using Microsoft.Extensions.Logging;

namespace HKW.HKWAvalonia.Dialogs;

/// <summary>
/// 图标文本字体
/// </summary>
public partial class IconText : ObservableObject
{
    /// <inheritdoc/>
    public IconText() { }

    #region Property
    [ObservableProperty]
    private IBrush? _foreground;

    [ObservableProperty]
    private IBrush? _background;

    [ObservableProperty]
    private int _fontSize;

    [ObservableProperty]
    private string? _text;
    #endregion
}
