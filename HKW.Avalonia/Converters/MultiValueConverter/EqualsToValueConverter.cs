using HKW.HKWUtils.Extensions;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 相等到值转换器
/// <para>示例:
/// <code><![CDATA[
/// <MultiBinding Converter="{StaticResource EqualsToValueConverter}">
///   <Binding Path="Value1" />
///   <Binding Path="Value2" />
///   <Binding Path="TrueValue" />
///   <Binding Path="FalueValue" /> // default is null
/// </MultiBinding>
/// ]]></code></para>
/// </summary>
public abstract class EqualsToValueConverter<TValue, TConverter>
    : InvertibleMultiValueConverterBase<TConverter>
    where TConverter : EqualsToValueConverter<TValue, TConverter>, new()
{
    /// <inheritdoc/>
    /// <exception cref="ArgumentException">参数数量必须为3或4</exception>
    public override object? Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (values.Count != 3 && values.Count != 4)
            throw new ArgumentException("Values count must be 3 or 4");
        var result = values[0]?.Equals(values[1]) is true ^ IsInverted;
        return result ? values[2] : values.GetValueOrDefault(3);
    }
}
