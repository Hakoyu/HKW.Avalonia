using Avalonia;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 相等转换器
/// <para>示例:
/// <code><![CDATA[
/// <MultiBinding Converter="{StaticResource EqualsConverter}">
///   <Binding Path="Value1" />
///   <Binding Path="Value2" />
/// </MultiBinding>
/// ]]></code></para>
/// </summary>
public class EqualsConverter : InvertibleMultiValueConverterBase<EqualsConverter>
{
    /// <inheritdoc/>
    /// <exception cref="NotImplementedException">参数必须为2</exception>
    public override object? Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (values.Count != 2)
            throw new ArgumentException("Values count must be 2");
        return values[0]?.Equals(values[1]) is true ^ IsInverted;
    }
}
