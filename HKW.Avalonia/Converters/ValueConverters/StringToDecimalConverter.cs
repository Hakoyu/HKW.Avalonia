using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public class StringToDecimalConverter : ValueConverterBase<StringToDecimalConverter>
{
    private static readonly NumberStyles DefaultNumberStyles = NumberStyles.Any;

    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        var dec = value as decimal?;
        if (dec != null)
        {
            return dec.Value.ToString("G", culture ?? CultureInfo.InvariantCulture);
        }

        if (value is string str)
        {
            if (
                decimal.TryParse(
                    str,
                    DefaultNumberStyles,
                    culture ?? CultureInfo.InvariantCulture,
                    out decimal result
                )
            )
            {
                return result;
            }

            return result;
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
        return this.Convert(value, targetType, parameter, culture);
    }
}
