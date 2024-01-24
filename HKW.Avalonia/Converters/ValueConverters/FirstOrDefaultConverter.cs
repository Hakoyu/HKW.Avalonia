using System;
using System.Collections;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public class FirstOrDefaultConverter : ValueConverterBase<FirstOrDefaultConverter>
{
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value is IEnumerable enumerable)
        {
            var enumerator = enumerable.GetEnumerator();
            {
                if (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }
        }

        return UnsetValue;
    }
}
