﻿using System;
using System.Diagnostics;

namespace HKW.HKWAvalonia.Converters;

public class DebugConverter : ValueConverterBase<DebugConverter>
{
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        System.Globalization.CultureInfo culture
    )
    {
        Debug.WriteLine(
            "DebugConverter.Convert(_value={0}, targetType={1}, parameter={2}, culture={3}",
            value ?? "null",
            (object)targetType ?? "null",
            parameter ?? "null",
            (object)culture ?? "null"
        );

        return value;
    }

    public override object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        System.Globalization.CultureInfo culture
    )
    {
        Debug.WriteLine(
            "DebugConverter.ConvertBack(_value={0}, targetType={1}, parameter={2}, culture={3}",
            value ?? "null",
            (object)targetType ?? "null",
            parameter ?? "null",
            (object)culture ?? "null"
        );

        return value;
    }
}
