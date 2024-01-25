using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 字符串格式化器
/// <para>示例:
/// <code><![CDATA[
/// <MultiBinding Converter="{StaticResource MarginConverter}">
///   <Binding Path="StringFormat" />
///   <Binding Path="Value1" />
///   <Binding Path="Value2" />
/// </MultiBinding>
/// OR
/// <MultiBinding Converter="{StaticResource MarginConverter}" ConverterParameter="{}{0}{1}">
///   <Binding Path="Value1" />
///   <Binding Path="Value2" />
/// </MultiBinding>
/// ]]></code></para>
/// </summary>
public class StringFormatConverter : MultiValueConverterBase<StringFormatConverter>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="values"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public override object? Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (parameter is string formatStr && string.IsNullOrWhiteSpace(formatStr))
        {
            return string.Format(formatStr, values);
        }
        else
        {
            formatStr = (string)values[0]!;
            return string.Format(formatStr, values.Skip(1).ToArray());
        }
    }
}
