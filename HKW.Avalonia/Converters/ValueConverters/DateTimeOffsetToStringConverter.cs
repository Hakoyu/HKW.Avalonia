using System;
using System.Globalization;
using Avalonia;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 日期时间偏移到字符串转换器
/// </summary>
public class DateTimeOffsetToStringConverter : ValueConverterBase<DateTimeOffsetToStringConverter>
{
    /// <summary>
    /// 默认格式化
    /// </summary>
    protected const string DefaultFormat = "g";

    /// <summary>
    /// 默认最小值
    /// </summary>
    protected const string DefaultMinValueString = "";

    private readonly ITimeZoneInfo _timeZone;

    /// <inheritdoc/>
    public DateTimeOffsetToStringConverter()
        : this(SystemTimeZoneInfo.Current) { }

    internal DateTimeOffsetToStringConverter(ITimeZoneInfo timeZone)
    {
        _timeZone = timeZone;
    }

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<string> FormatProperty = AvaloniaProperty.Register<
        DateTimeOffsetToStringConverter,
        string
    >(nameof(Format), DefaultFormat);

    /// <summary>
    /// 日期时间格式化
    /// <para>
    /// 格式化参考: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
    /// </para>
    /// </summary>
    public string Format
    {
        get => GetValue(FormatProperty);
        set => SetValue(FormatProperty, value);
    }

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<string> MinValueStringProperty =
        AvaloniaProperty.Register<DateTimeOffsetToStringConverter, string>(
            nameof(MinValueString),
            DefaultMinValueString
        );

    /// <summary>
    /// 最小值
    /// </summary>
    public string MinValueString
    {
        get => GetValue(MinValueStringProperty);
        set => SetValue(MinValueStringProperty, value);
    }

    /// <inheritdoc/>
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

            return TimeZoneInfo
                .ConvertTime(dateTimeOffset, _timeZone.Local)
                .ToString(Format, culture);
        }

        return null;
    }

    /// <inheritdoc/>
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
                    return TimeZoneInfo.ConvertTime(parsedDateTimeOffset, _timeZone.Utc);
                }
            }
        }

        return null;
    }
}
