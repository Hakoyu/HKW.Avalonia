using System;
using System.Globalization;
using Avalonia;
using HKW.HKWAvalonia;
using HKW.HKWAvalonia.Converters.Services;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Converts a <seealso cref="DateTimeOffset"/> value to string using formatting specified in <seealso cref="DefaultFormat"/>.
/// </summary>
public class DateTimeOffsetToStringConverter : ValueConverterBase<DateTimeOffsetToStringConverter>
{
    protected const string DefaultFormat = "g";
    protected const string DefaultMinValueString = "";

    private readonly ITimeZoneInfo _timeZone;

    public DateTimeOffsetToStringConverter()
        : this(SystemTimeZoneInfo.Current) { }

    internal DateTimeOffsetToStringConverter(ITimeZoneInfo timeZone)
    {
        _timeZone = timeZone;
    }

    public static readonly StyledProperty<string> FormatProperty = AvaloniaProperty.Register<
        DateTimeOffsetToStringConverter,
        string
    >(nameof(Format), DefaultFormat);

    public static readonly StyledProperty<string> MinValueStringProperty =
        AvaloniaProperty.Register<DateTimeOffsetToStringConverter, string>(
            nameof(MinValueString),
            DefaultMinValueString
        );

    /// <summary>
    /// The datetime format property.
    /// Standard date and time format strings: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
    /// </summary>
    public string Format
    {
        get => GetValue(FormatProperty);
        set => SetValue(FormatProperty, value);
    }

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
        if (value is DateTimeOffset dateTimeOffset)
        {
            if (dateTimeOffset == DateTimeOffset.MinValue)
            {
                return MinValueString;
            }

            return dateTimeOffset.WithTimeZone(_timeZone.Local).ToString(Format, culture);
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
            if (value is DateTimeOffset dateTimeOffset)
            {
                return dateTimeOffset;
            }

            if (value is string str)
            {
                if (DateTimeOffset.TryParse(str, out var parsedDateTimeOffset))
                {
                    return parsedDateTimeOffset.WithTimeZone(_timeZone.Utc);
                }
            }
        }

        return UnsetValue;
    }
}
