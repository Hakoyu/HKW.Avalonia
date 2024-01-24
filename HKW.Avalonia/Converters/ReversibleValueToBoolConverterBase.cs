using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public abstract class ReversibleValueToBoolConverterBase<T, TConverter>
    : ValueToBoolConverterBase<T, TConverter>
    where TConverter : ValueConverterBase<TConverter>, new()
{
    public abstract T FalseValue { get; set; }

    public bool BaseOnFalseValue
    {
        get => GetValue(BaseOnFalseValueProperty);
        set => SetValue(BaseOnFalseValueProperty, value);
    }

    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (!BaseOnFalseValue)
        {
            return base.Convert(value, targetType, parameter, culture);
        }

        var falseValue = FalseValue;
        return !Equals(value, falseValue) ^ IsInverted;
    }

    public override object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        return true.Equals(value) ^ IsInverted ? TrueValue : FalseValue;
    }

    public static readonly StyledProperty<bool> BaseOnFalseValueProperty =
        AvaloniaProperty.Register<ValueToBoolConverterBase<T, TConverter>, bool>(
            nameof(BaseOnFalseValueProperty)
        );
}
