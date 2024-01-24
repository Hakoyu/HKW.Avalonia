using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Source:
/// http://geekswithblogs.net/codingbloke/archive/2010/05/28/a-generic-boolean-value-converter.aspx
/// </summary>
/// <typeparam name="T">Generic type T which is used as TrueValue or FalseValue.</typeparam>
/// <typeparam name="TConverter">Converter type</typeparam>
public abstract class BoolToValueConverterBase<T, TConverter> : ValueConverterBase<TConverter>
    where TConverter : ValueConverterBase<TConverter>, new()
{
    public abstract T TrueValue { get; set; }

    public abstract T FalseValue { get; set; }

    public abstract bool IsInverted { get; set; }

    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        var returnValue = this.FalseValue;

        if (value is bool boolValue)
        {
            if (this.IsInverted)
            {
                returnValue = boolValue ? this.FalseValue : this.TrueValue;
            }
            else
            {
                returnValue = boolValue ? this.TrueValue : this.FalseValue;
            }
        }

        return returnValue;
    }

    public override object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        bool returnValue = false;

        if (value != null)
        {
            if (this.IsInverted)
            {
                returnValue = value.Equals(this.FalseValue);
            }
            else
            {
                returnValue = value.Equals(this.TrueValue);
            }
        }

        return returnValue;
    }
}
