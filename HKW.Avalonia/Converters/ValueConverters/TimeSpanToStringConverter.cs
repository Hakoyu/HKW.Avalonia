using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public class TimeSpanToStringConverter : ValueConverterBase<TimeSpanToStringConverter>
{
    protected const string DefaultFormat = @"g";
    protected const string DefaultMinValueString = "";

    public static readonly StyledProperty<string> FormatProperty = AvaloniaProperty.Register<
        TimeSpanToStringConverter,
        string
    >(nameof(Format), DefaultFormat);

    /// <summary>
    /// The timespan format property.
    /// Standard date and time format strings: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-timespan-format-strings
    /// </summary>
    public string Format
    {
        get => GetValue(FormatProperty);
        set => SetValue(FormatProperty, value);
    }

    public static readonly StyledProperty<string> MinValueStringProperty =
        AvaloniaProperty.Register<TimeSpanToStringConverter, string>(
            nameof(MinValueString),
            DefaultMinValueString
        );

    public string MinValueString
    {
        get => GetValue(MinValueStringProperty);
        set => SetValue(MinValueStringProperty, value);
    }

    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value is TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.MinValue)
            {
                return MinValueString;
            }

            return timeSpan.ToString(Format, culture);
        }

        return UnsetValue;
    }

    public override object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value != null)
        {
            if (value is TimeSpan timeSpan)
            {
                return timeSpan;
            }

            if (value is string str && TimeSpan.TryParse(str, out var resultTimeSpan))
            {
                return resultTimeSpan;
            }
        }
        return null;
    }
}
