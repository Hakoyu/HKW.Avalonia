using Avalonia;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 全部相等于值转换器
/// </summary>
public abstract class AllEqualsValueMultiConverter<T, TConverter>
    : InvertibleMultiValueConverterBase<TConverter>
    where TConverter : AllEqualsValueMultiConverter<T, TConverter>, new()
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<T> ValueProperty = AvaloniaProperty.Register<
        AllEqualsValueMultiConverter<T, TConverter>,
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
    public override object Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (IsInverted)
            return values.All(o => o?.Equals(Value) is true);
        else
            return values.All(o => o?.Equals(Value) is not true);
    }
}
