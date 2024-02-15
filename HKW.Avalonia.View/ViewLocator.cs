using HKW.Avalonia.ViewModels;
using HKW.Avalonia.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using System;
using HKW.HKWAvalonia.Dialogs;

namespace HKW.Avalonia;

public class ViewLocator : StrongViewLocator
{
    public ViewLocator()
    {
        Register<MainVM, MainView, MainWindow>();
        this.AddHKWDialogs();
    }
}
