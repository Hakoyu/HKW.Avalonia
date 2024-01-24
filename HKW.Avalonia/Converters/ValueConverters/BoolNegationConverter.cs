namespace HKW.HKWAvalonia.Converters;

public class BoolNegationConverter : BoolToValueConverter<bool>
{
    public BoolNegationConverter()
    {
        TrueValue = true;
        FalseValue = false;
        IsInverted = true;
    }
}
