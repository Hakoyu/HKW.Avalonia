using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HKW.HKWAvalonia.Converters;

namespace HKW.Avalonia.ViewModels;

public partial class MainVM : ObservableObject
{
    public MainVM() { }

    #region Property
    [ObservableProperty]
    private string _text;
    #endregion

    #region Command

    #endregion
}
