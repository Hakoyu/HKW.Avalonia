using Avalonia;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 相等转换器
/// <para>示例:
/// <code><![CDATA[
/// <MultiBinding Converter="{StaticResource RatioMarginConverter}">
///   <Binding Path="Value1" />
///   <Binding Path="Value2" />
/// </MultiBinding>
/// ]]></code></para>
/// </summary>
public class EqualsConverter : MultiValueConverterBase<EqualsConverter>
{
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        EqualsConverter,
        bool
    >(nameof(IsInverted));

    public bool IsInverted
    {
        get => GetValue(IsInvertedProperty);
        set => SetValue(IsInvertedProperty, value);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="values"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override object? Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (values.Count != 2)
            throw new NotImplementedException("Values length must be 2");
        return values[0]?.Equals(values[1]) ^ IsInverted;
    }
}
