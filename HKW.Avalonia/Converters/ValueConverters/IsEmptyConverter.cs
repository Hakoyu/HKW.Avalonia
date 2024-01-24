using Avalonia;
using System;
using System.Collections;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public class IsEmptyConverter : ValueConverterBase<IsEmptyConverter>
{
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        IsEmptyConverter,
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
        if (value is IEnumerable enumerable)
        {
            var hasAtLeastOne = enumerable.GetEnumerator().MoveNext();
            return (hasAtLeastOne == false) ^ IsInverted;
        }

        return true ^ IsInverted;
    }
}
