﻿using System;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Converts a <seealso cref="Guid"/> to <seealso cref="string"/>
/// </summary>
public class GuidToStringConverter : ValueConverterBase<GuidToStringConverter>
{
    /// <summary>
    /// Determines if the string needs to be upper case.
    /// </summary>
    public bool ToUpper { get; set; }

    /// <summary>
    /// The format used to convert the Guid to string.
    /// </summary>
    public string Format { get; set; } = "D";

    /// <inheritdoc/>
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        System.Globalization.CultureInfo culture
    )
    {
        if (value is Guid guid)
        {
            var guidString = guid.ToString(this.Format);

            if (this.ToUpper)
            {
                return guidString.ToUpperInvariant();
            }

            return guidString;
        }

        return UnsetValue;
    }

    /// <inheritdoc/>
    public override object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        System.Globalization.CultureInfo culture
    )
    {
        if (value is string guidString)
        {
            var guid = new Guid(guidString);
            return guid;
        }

        return UnsetValue;
    }
}