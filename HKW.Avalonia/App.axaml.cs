using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using CommunityToolkit.Mvvm.DependencyInjection;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;

namespace HKW.HKWAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        //if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        //{
        //    // 用于桌面
        //    desktop.MainWindow = Ioc.Default
        //        .GetService<MainWindow>()!
        //        .SetDataContext<MainWindow, MainVM>();
        //}
        //else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        //{
        //    // 用于单页面视图(例如网页和手机)
        //    singleViewPlatform.MainView = Ioc.Default
        //        .GetService<MainView>()!
        //        .SetDataContext<MainView, MainVM>();
        //}
        //GC.KeepAlive(typeof(DialogService));
        //Ioc.Default.GetService<IDialogService>()!.Show(null, Ioc.Default.GetService<MainVM>()!);
        base.OnFrameworkInitializationCompleted();
    }
}
