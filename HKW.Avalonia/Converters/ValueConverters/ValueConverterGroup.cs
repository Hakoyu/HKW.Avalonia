using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Value converters which aggregates the results of a sequence of converters: Converter1 >> Converter2 >> Converter3
/// The output of converter N becomes the input of converter N+1.
/// </summary>
public class ValueConverterGroup : ValueConverterBase<ValueConverterGroup>
{
    public List<IValueConverter> Converters { get; set; } = [];

    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (Converters is not IEnumerable<IValueConverter> converters)
            return UnsetValue;

        return converters.Aggregate(
            value,
            (current, converter) => converter.Convert(current, targetType, parameter, culture)
        );
    }

    public override object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (Converters is not IEnumerable<IValueConverter> converters)
            return UnsetValue;

        return converters
            .Reverse()
            .Aggregate(
                value,
                (current, converter) => converter.Convert(current, targetType, parameter, culture)
            );
    }
}
