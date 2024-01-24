using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public abstract class ValueToBoolConverterBase<T, TConverter> : ValueConverterBase<TConverter>
    where TConverter : ValueConverterBase<TConverter>, new()
{
    public abstract T TrueValue { get; set; }

    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        ValueToBoolConverterBase<T, TConverter>,
        bool
    >(nameof(IsInverted));
    public bool IsInverted
    {
        get => GetValue(IsInvertedProperty);
        set => SetValue(IsInvertedProperty, value);
    }

    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        var trueValue = TrueValue;
        return Equals(value, trueValue) ^ IsInverted;
    }
}
