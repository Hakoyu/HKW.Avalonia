using Avalonia;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 全部相等于值转换器
/// </summary>
/// <typeparam name="T">值类型</typeparam>
/// <typeparam name="TConverter">转换器类型</typeparam>
public class AnyEqualsValueConverter<T, TConverter> : MultiValueConverterBase<TConverter>
    where TConverter : MultiValueConverterBase<TConverter>, new()
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        AnyEqualsValueConverter<T, TConverter>,
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

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<T> ValueProperty = AvaloniaProperty.Register<
        AnyEqualsValueConverter<T, TConverter>,
        T
    >(nameof(Value));

    /// <summary>
    /// 值
    /// </summary>
    public T Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    /// <inheritdoc/>
    public override object? Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (IsInverted)
            return values.Any(o => o?.Equals(Value) is true);
        else
            return values.Any(o => o?.Equals(Value) is not true);
    }
}
