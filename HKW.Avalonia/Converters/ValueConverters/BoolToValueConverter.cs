using Avalonia;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 布尔到值转换器
/// </summary>
/// <typeparam name="T">值类型</typeparam>
/// <typeparam name="TConverter">转换器类型</typeparam>
public class BoolToValueConverter<T, TConverter> : ValueConverterBase<TConverter>
    where TConverter : BoolToValueConverter<T, TConverter>, new()
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<T> TrueValueProperty = AvaloniaProperty.Register<
        BoolToValueConverter<T, TConverter>,
        T
    >(nameof(TrueValue));

    /// <summary>
    /// 为真时的值
    /// </summary>
    public T TrueValue
    {
        get => GetValue(TrueValueProperty);
        set => SetValue(TrueValueProperty, value);
    }

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<T> FalseValueProperty = AvaloniaProperty.Register<
        BoolToValueConverter<T, TConverter>,
        T
    >(nameof(FalseValue));

    /// <summary>
    /// 为假时的值
    /// </summary>
    public T FalseValue
    {
        get => GetValue(FalseValueProperty);
        set => SetValue(FalseValueProperty, value);
    }

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> NullValueProperty = AvaloniaProperty.Register<
        BoolToValueConverter<T, TConverter>,
        bool
    >(nameof(NullValue));

    /// <summary>
    /// 为空时的布尔值
    /// </summary>
    public bool NullValue
    {
        get => GetValue(NullValueProperty);
        set => SetValue(NullValueProperty, value);
    }

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        BoolToValueConverter<T, TConverter>,
        bool
    >(nameof(IsInverted));

    /// <summary>
    /// 是反转的
    /// </summary>
    public bool IsInverted
    {
        get => GetValue(IsInvertedProperty);
        set => SetValue(IsInvertedProperty, value);
    }

    /// <inheritdoc/>
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value is null)
            return NullValue ? TrueValue : FalseValue;
        if (value is bool boolValue || (value is string str && bool.TryParse(str, out boolValue)))
            return boolValue ^ IsInverted ? FalseValue : TrueValue;
        else
            return FalseValue;
    }

    /// <inheritdoc/>
    public override object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value != null)
            return IsInverted ? value.Equals(FalseValue) : value.Equals(TrueValue);
        else
            return false;
    }
}
