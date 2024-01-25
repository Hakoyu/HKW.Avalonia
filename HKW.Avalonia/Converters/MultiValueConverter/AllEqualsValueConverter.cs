﻿using Avalonia;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 全部相等于值转换器
/// </summary>
public class AllEqualsValueConverter<T> : AllEqualsValueConverterBase<T, AllEqualsValueConverter<T>>
{
    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        AllEqualsValueConverter<T>,
        bool
    >(nameof(IsInverted));

    public bool IsInverted
    {
        get => GetValue(IsInvertedProperty);
        set => SetValue(IsInvertedProperty, value);
    }

    public static readonly StyledProperty<T> ValueProperty = AvaloniaProperty.Register<
        AllEqualsValueConverter<T>,
        T
    >(nameof(Value));
    public T Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public override object Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (IsInverted)
            return values.All(o => o?.Equals(Value) is true);
        else
            return values.All(o => o?.Equals(Value) is not true);
    }
}
