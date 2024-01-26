﻿using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 时间范围到字符串转换器
/// </summary>
public class TimeSpanToStringConverter : ValueConverterBase<TimeSpanToStringConverter>
{
    /// <summary>
    /// 默认格式化
    /// </summary>
    protected const string DefaultFormat = "g";

    /// <summary>
    /// 默认最小值
    /// </summary>
    protected const string DefaultMinValueString = "";

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<string> FormatProperty = AvaloniaProperty.Register<
        TimeSpanToStringConverter,
        string
    >(nameof(Format), DefaultFormat);

    /// <summary>
    /// 时间格式化
    /// <para>
    /// 时间格式化参考s: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-timespan-format-strings
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
        AvaloniaProperty.Register<TimeSpanToStringConverter, string>(
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
        if (value is TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.MinValue)
            {
                return MinValueString;
            }

            return timeSpan.ToString(Format, culture);
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
