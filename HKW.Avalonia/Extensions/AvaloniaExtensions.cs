using Avalonia;
using System.ComponentModel;

namespace HKW.HKWAvalonia;

/// <summary>
/// Avalonia扩展
/// </summary>
public static class AvaloniaExtensions
{
    /// <summary>
    /// 设置数据上下文
    /// </summary>
    /// <typeparam name="TElement">控件类型</typeparam>
    /// <typeparam name="TViewModel">视图模型类型</typeparam>
    /// <param name="element">控件</param>
    /// <param name="viewModel">视图模型</param>
    /// <returns>控件</returns>
    public static TElement SetDataContext<TElement, TViewModel>(
        this TElement element,
        TViewModel viewModel
    )
        where TElement : StyledElement
        where TViewModel : INotifyPropertyChanged
    {
        element.DataContext = viewModel;
        return element;
    }
}
