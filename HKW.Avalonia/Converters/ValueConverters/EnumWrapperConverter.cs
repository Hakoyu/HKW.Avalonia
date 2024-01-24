using Avalonia;

namespace HKW.HKWAvalonia.Converters;

public class EnumWrapperConverter : EnumWrapperConverterBase<EnumWrapperConverter>
{
    public static readonly StyledProperty<EnumWrapperConverterNameStyle> NameStyleProperty =
        AvaloniaProperty.Register<EnumWrapperConverter, EnumWrapperConverterNameStyle>(
            nameof(NameStyle),
            EnumWrapperConverterNameStyle.LongName
        );

    public override EnumWrapperConverterNameStyle NameStyle
    {
        get => GetValue(NameStyleProperty);
        set => SetValue(NameStyleProperty, value);
    }
}
