using Avalonia.Media;

namespace HKW.HKWAvalonia.Converters;

public class BoolToFontWeightConverter : BoolToValueConverter<FontWeight>
{
    public BoolToFontWeightConverter()
    {
        this.TrueValue = FontWeight.Bold;
        this.FalseValue = FontWeight.Normal;
    }
}
