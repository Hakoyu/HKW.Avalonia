using System;
using System.Globalization;
using Avalonia;
using HKW.HKWAvalonia;
using HKW.HKWAvalonia.Converters.Services;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Converts a <seealso cref="DateTime"/> value to string using formatting specified in <seealso cref="DefaultFormat"/>.
/// </summary>
public class DateTimeToStringConverter : ValueConverterBase<DateTimeToStringConverter>
{
    protected const string DefaultFormat = "g";
    protected const string DefaultMinValueString = "";

    private readonly ITimeZoneInfo _timeZone;

    public DateTimeToStringConverter()
        : this(SystemTimeZoneInfo.Current) { }

    internal DateTimeToStringConverter(ITimeZoneInfo timeZone)
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
        if (value is DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return MinValueString;
            }

            var localDateTime = dateTime.WithTimeZone(_timeZone.Local);
            return localDateTime.ToString(Format, culture);
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
            if (value is DateTime dateTime)
            {
                return dateTime;
            }

            if (value is string str)
            {
                if (DateTime.TryParse(str, out var parsedDateTime))
                {
                    return parsedDateTime.WithTimeZone(_timeZone.Utc);
                }
            }
        }

        return UnsetValue;
    }
}
