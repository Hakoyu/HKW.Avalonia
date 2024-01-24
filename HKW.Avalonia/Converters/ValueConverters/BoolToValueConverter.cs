using Avalonia;

namespace HKW.HKWAvalonia.Converters;

public class BoolToValueConverter<T> : BoolToValueConverterBase<T, BoolToValueConverter<T>>
{
    public static readonly StyledProperty<T> TrueValueProperty = AvaloniaProperty.Register<
        BoolToValueConverter<T>,
        T
    >(nameof(TrueValue));
    public override T TrueValue
    {
        get => GetValue(TrueValueProperty);
        set => SetValue(TrueValueProperty, value);
    }

    public static readonly StyledProperty<T> FalseValueProperty = AvaloniaProperty.Register<
        BoolToValueConverter<T>,
        T
    >(nameof(FalseValue));
    public override T FalseValue
    {
        get => GetValue(FalseValueProperty);
        set => SetValue(FalseValueProperty, value);
    }

    public static readonly StyledProperty<bool> IsInvertedProperty = AvaloniaProperty.Register<
        BoolToValueConverter<T>,
        bool
    >(nameof(IsInverted));

    public override bool IsInverted
    {
        get => GetValue(IsInvertedProperty);
        set => SetValue(IsInvertedProperty, value);
    }
}
