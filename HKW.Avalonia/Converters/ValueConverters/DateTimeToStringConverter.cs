﻿using System;
using System.Globalization;
using Avalonia;
using HKW.HKWAvalonia;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 日期时间到字符串转换器
/// </summary>
public class DateTimeToStringConverter : ValueConverterBase<DateTimeToStringConverter>
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
    public DateTimeToStringConverter()
        : this(SystemTimeZoneInfo.Current) { }

    internal DateTimeToStringConverter(ITimeZoneInfo timeZone)
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
        if (value is DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return MinValueString;
            }

            var localDateTime = dateTime.WithTimeZone(_timeZone.Local);
            return localDateTime.ToString(Format, culture);
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

        return null;
    }
}
