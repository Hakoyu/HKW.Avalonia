using System.Globalization;
using System;
using System.Collections;
using Avalonia;

namespace HKW.HKWAvalonia.Converters;

public class NullToBoolConverter : ValueConverterBase<NullToBoolConverter>
{
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        NullToBoolConverter,
        bool
    >(nameof(IsInverted));

    public bool IsInverted
    {
        get => GetValue(IsInvertedProperty);
        set => SetValue(IsInvertedProperty, value);
    }

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
