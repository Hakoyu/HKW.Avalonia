using Avalonia;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 可反转的值转换器基类
/// </summary>
/// <typeparam name="TConverter">转换器类型</typeparam>
public abstract class InvertibleValueConverterBase<TConverter> : ValueConverterBase<TConverter>
    where TConverter : InvertibleValueConverterBase<TConverter>, new()
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        InvertibleValueConverterBase<TConverter>,
        bool
    >(nameof(IsInverted));

    /// <summary>
    /// 是反转的
    /// </summary>
    public bool IsInverted
    {
        get => GetValue(IsInvertedProperty);
        set => SetValue(IsInvertedProperty, value);
    }
}
