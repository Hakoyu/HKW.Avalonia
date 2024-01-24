﻿using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Converts System.Version objects to string. Parameter can be used to limit the number of Version components to return.
/// [1] Major Version
/// [2] Minor Version
/// [3] Build Number
/// [4] Revision
/// </summary>
public class VersionToStringConverter : ValueConverterBase<VersionToStringConverter>
{
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        var version = value as Version;
        if (version != null)
        {
            if (int.TryParse(parameter as string, out int fieldCount))
            {
                return version.ToString(fieldCount);
            }

            return version.ToString();
        }

        return UnsetValue;
    }
}