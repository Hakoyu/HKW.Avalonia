using Avalonia;

namespace HKW.HKWAvalonia.Converters;

public class ValueToBoolConverter<T>
    : ReversibleValueToBoolConverterBase<T, ValueToBoolConverter<T>>
{
    public override T TrueValue
    {
        get => (T)this.GetValue(TrueValueProperty);
        set => this.SetValue(TrueValueProperty, value);
    }

    public static readonly StyledProperty<T> TrueValueProperty = AvaloniaProperty.Register<
        ValueToBoolConverter<T>,
        T
    >(nameof(TrueValue));

    public override T FalseValue
    {
        get => (T)this.GetValue(FalseValueProperty);
        set => this.SetValue(FalseValueProperty, value);
    }

    public static readonly StyledProperty<T> FalseValueProperty = AvaloniaProperty.Register<
        ValueToBoolConverter<T>,
        T
    >(nameof(FalseValue));
}

public class ValueToBoolConverter : ValueToBoolConverter<object> { }
