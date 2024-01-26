using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 字符串是null或者空转换器
/// </summary>
public class StringIsNullOrEmptyConverter : ValueConverterBase<StringIsNullOrEmptyConverter>
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        StringIsNullOrEmptyConverter,
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

    /// <inheritdoc/>
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        return string.IsNullOrEmpty(value as string) ^ IsInverted;
    }
}
