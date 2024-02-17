using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
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
    private MessageBoxButton[] _buttons = Enum.GetValues<MessageBoxButton>();
    private MessageBoxImage[] _images = Enum.GetValues<MessageBoxImage>();
    private int _buttonIndex = 0;
    private int _imageIndex = 0;
    private bool _invert = false;

    [RelayCommand]
    private async Task ShowMessageBox()
    {
        if (_buttonIndex >= _buttons.Length)
            _buttonIndex = 0;
        if (_imageIndex >= _images.Length)
            _imageIndex = 0;
        var button = _buttons[_buttonIndex++];
        var image = _images[_imageIndex++];
        await _dialogService.ShowMessageBoxAsync(
            this,
            new MessageBoxVM("Hello\nHow are you\nFuck you beach")
            {
                Button = button,
                Icon = image,
                Title = Enum.GetName<MessageBoxImage>(image)
            },
            new() { CloseOnClickAway = true }
        );
    }
    #endregion
}
