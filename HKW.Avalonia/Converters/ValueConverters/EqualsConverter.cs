using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 相等转换器
/// </summary>
public class EqualsConverter : InvertibleValueConverterBase<EqualsConverter>
{
    /// <inheritdoc/>
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        return value?.Equals(parameter) ^ IsInverted;
    }
}
