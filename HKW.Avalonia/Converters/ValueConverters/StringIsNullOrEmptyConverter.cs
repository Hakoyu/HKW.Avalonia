﻿using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 字符串是null或者空转换器
/// </summary>
public class StringIsNullOrEmptyConverter
    : InvertibleValueConverterBase<StringIsNullOrEmptyConverter>
{
    /// <inheritdoc/>
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        return string.IsNullOrEmpty(value as string) ^ IsInverted;
    }
}
