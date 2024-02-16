using Avalonia;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 可反转的多值转换器
/// </summary>
/// <typeparam name="TConverter">转换器类型</typeparam>
public abstract class InvertibleMultiValueConverterBase<TConverter>
    : MultiValueConverterBase<TConverter>
    where TConverter : InvertibleMultiValueConverterBase<TConverter>, new()
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        InvertibleMultiValueConverterBase<TConverter>,
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
