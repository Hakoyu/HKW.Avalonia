using Avalonia;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Checks if the value is between MinValue and MaxValue,
/// returning true if the value is within the range and false if the value is out of the range.
///
/// All involved values (converter parameter 'value', MinValue and MaxValue) must be of the same type
/// and must implement <seealso cref="IComparable"/> (https://docs.microsoft.com/en-us/dotnet/api/system.icomparable).
/// </summary>
public class MinMaxValueToBoolConverter : ValueConverterBase<MinMaxValueToBoolConverter>
{
    public static readonly StyledProperty<object> MaxValueProperty = AvaloniaProperty.Register<
        MinMaxValueToBoolConverter,
        object
    >(nameof(MaxValue));
    public object MaxValue
    {
        get => GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public static readonly StyledProperty<object> MinValueProperty = AvaloniaProperty.Register<
        MinMaxValueToBoolConverter,
        object
    >(nameof(MinValue));

    public object MinValue
    {
        get => GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    /// <inheritdoc/>
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value is not IComparable comparable)
        {
            return UnsetValue;
        }

        if (MinValue is not IComparable)
        {
            throw new ArgumentException(
                "MinValue must implement IComparable interface",
                nameof(MinValue)
            );
        }

        if (MaxValue is not IComparable)
        {
            throw new ArgumentException(
                "MaxValue must implement IComparable interface",
                nameof(MaxValue)
            );
        }

        var minValue = System.Convert.ChangeType(MinValue, comparable.GetType());
        var maxValue = System.Convert.ChangeType(MaxValue, comparable.GetType());

        return (comparable.CompareTo(minValue) >= 0 && comparable.CompareTo(maxValue) <= 0);
    }
}
