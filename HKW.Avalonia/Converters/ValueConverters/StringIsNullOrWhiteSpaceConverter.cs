using Avalonia;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public class StringIsNullOrWhiteSpaceConverter
    : ValueConverterBase<StringIsNullOrWhiteSpaceConverter>
{
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        StringIsNullOrWhiteSpaceConverter,
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
            return !string.IsNullOrWhiteSpace(value as string);
        }

        return string.IsNullOrWhiteSpace(value as string);
    }
}
