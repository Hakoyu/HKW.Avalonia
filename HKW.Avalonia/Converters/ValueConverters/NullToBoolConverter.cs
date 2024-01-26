using System.Globalization;
using System;
using System.Collections;
using Avalonia;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 空到布尔转换器
/// </summary>
public class NullToBoolConverter : ValueConverterBase<NullToBoolConverter>
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        NullToBoolConverter,
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
        return value == null ^ IsInverted;
    }
}
