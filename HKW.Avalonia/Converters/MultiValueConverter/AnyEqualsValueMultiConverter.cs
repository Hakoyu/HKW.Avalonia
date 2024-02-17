﻿using Avalonia;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 任意相等于值转换器
/// </summary>
public class AnyEqualsValueMultiConverter
    : AnyEqualsValueMultiConverter<object, AnyEqualsValueMultiConverter> { }

/// <summary>
/// 任意相等于值转换器
/// </summary>
/// <typeparam name="T">值类型</typeparam>
/// <typeparam name="TConverter">转换器类型</typeparam>
public class AnyEqualsValueMultiConverter<T, TConverter>
    : InvertibleMultiValueConverterBase<TConverter>
    where TConverter : AnyEqualsValueMultiConverter<T, TConverter>, new()
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<T> ValueProperty = AvaloniaProperty.Register<
        AnyEqualsValueMultiConverter<T, TConverter>,
        T
    >(nameof(Value));

    /// <summary>
    /// 值
    /// </summary>
    public T Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    /// <inheritdoc/>
    public override object? Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (IsInverted)
            return values.Any(o => o?.Equals(Value) is true);
        else
            return values.Any(o => o?.Equals(Value) is not true);
    }
}
