﻿using Avalonia.Data.Converters;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public enum PreferredCulture
{
    /// <summary>
    /// Uses the default culture provided by <seealso cref="IValueConverter"/>.
    /// </summary>
    ConverterCulture,

    /// <summary>
    /// Overrides the default converter culture with <seealso cref="CultureInfo.CurrentCulture"/>.
    /// </summary>
    CurrentCulture,

    /// <summary>
    /// Overrides the default converter culture with <seealso cref="CultureInfo.CurrentUICulture"/>.
    /// </summary>
    CurrentUICulture,
}