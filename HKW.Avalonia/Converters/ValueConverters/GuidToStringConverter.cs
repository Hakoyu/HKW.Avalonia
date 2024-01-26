using Avalonia;
using System;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Guid到字符串转换器
/// </summary>
public class GuidToStringConverter : ValueConverterBase<GuidToStringConverter>
{
    /// <summary>
    /// 默认格式化
    /// </summary>
    protected const string DefaultFormat = "D";

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> ToUpperProperty = AvaloniaProperty.Register<
        GuidToStringConverter,
        bool
    >(nameof(ToUpper));

    /// <summary>
    /// 转换为大写
    /// </summary>
    public bool ToUpper
    {
        get => GetValue(ToUpperProperty);
        set => SetValue(ToUpperProperty, value);
    }

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<string> FormatProperty = AvaloniaProperty.Register<
        GuidToStringConverter,
        string
    >(nameof(Format), DefaultFormat);

    /// <summary>
    /// 格式化
    /// </summary>
    public string Format
    {
        get => GetValue(FormatProperty);
        set => SetValue(FormatProperty, value);
    }

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
            var guidString = guid.ToString(Format);

            if (ToUpper)
                return guidString.ToUpperInvariant();

            return guidString;
        }

        return null;
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

        return null;
    }
}
