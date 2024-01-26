using Avalonia.Media;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 布尔到字体粗细转换器
/// </summary>
public class BoolToFontWeightConverter : BoolToValueConverter<FontWeight, BoolToFontWeightConverter>
{
    /// <inheritdoc/>
    public BoolToFontWeightConverter()
    {
        TrueValue = FontWeight.Bold;
        FalseValue = FontWeight.Normal;
    }
}
