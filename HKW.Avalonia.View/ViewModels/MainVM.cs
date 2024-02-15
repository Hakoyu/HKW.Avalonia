using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HKW.HKWAvalonia.Converters;
using HKW.HKWAvalonia.Dialogs;
using System.ComponentModel.DataAnnotations;

namespace HKW.Avalonia.ViewModels;

public partial class MainVM : ObservableObject
{
    private readonly IDialogService _dialogService = Ioc.Default.GetService<IDialogService>()!;

    public MainVM() { }

    #region Property
    [ObservableProperty]
    private string _text;
    #endregion

    #region Command
    [RelayCommand]
    private async Task ShowMessageBox()
    {
        await _dialogService.ShowMessageBoxAsync(this, new MessageBoxVM("Hello"));
    }
    #endregion
}
