using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public class StringIsNullOrEmptyConverter : ValueConverterBase<StringIsNullOrEmptyConverter>
{
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        StringIsNullOrEmptyConverter,
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
        if (IsInverted)
        {
            return !string.IsNullOrEmpty(value as string);
        }

        return string.IsNullOrEmpty(value as string);
    }
}
