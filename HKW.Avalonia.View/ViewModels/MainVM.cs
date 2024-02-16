using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using HKW.HKWAvalonia.Converters;
//using HKW.HKWAvalonia.Dialogs;
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
    private MessageBoxButton[] _array = Enum.GetValues<MessageBoxButton>();
    private int _index = 0;
    private bool _invert = false;

    [RelayCommand]
    private async Task ShowMessageBox()
    {
        //if (_index >= _array.Length)
        //{
        //    _index = 0;
        //    _invert = !_invert;
        //}
        //var result = _array[_index++];
        //await _dialogService.ShowMessageBoxAsync(
        //    this,
        //    new MessageBoxVM("Hello\nHow are you\nFuck you beach")
        //    {
        //        Button = result,
        //        InvertButtonPosition = _invert,
        //        Title = "Title"
        //    }
        //);
    }
    #endregion
}
