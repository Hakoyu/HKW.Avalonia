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
using HKW.Avalonia.Views;
using HKW.Avalonia.ViewModels;

namespace HKW.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        Ioc.Default.ConfigureServices(ConfigureServices());
    }

    /// <summary>
    /// 设置Ioc服务
    /// </summary>
    /// <returns></returns>
    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        AddMVVMDialogs(services);

        AddMainWindow(services);

        return services.BuildServiceProvider();
    }

    private static void AddMainWindow(ServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<MainView>();
        services.AddTransient<MainVM>();
    }

    /// <summary>
    /// 添加视图模型弹窗
    /// </summary>
    /// <param name="services"></param>
    private static void AddMVVMDialogs(IServiceCollection services)
    {
        // 判断是窗口视图还是单页视图
        //var messageBoxMode = Current?.IsSingleView() is true
        //    ? HanumanInstitute.MvvmDialogs.Avalonia.MessageBox.MessageBoxMode.Popup
        //    : HanumanInstitute.MvvmDialogs.Avalonia.MessageBox.MessageBoxMode.Window;
        services.AddSingleton<IDialogService>(
            new DialogService(
                new DialogManager(
                    viewLocator: new ViewLocator(),
                    dialogFactory: new DialogFactory().AddDialogHost()
                ),
                viewModelFactory: x => Ioc.Default.GetService(x)
            )
        );
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
        GC.KeepAlive(typeof(DialogService));
        Ioc.Default.GetService<IDialogService>()!.Show(null, Ioc.Default.GetService<MainVM>()!);
        base.OnFrameworkInitializationCompleted();
    }
}

public static class AppExtensions
{
    /// <summary>
    /// 是单视图
    /// </summary>
    /// <param name="application"></param>
    /// <returns>是单视图为 <see langword="true"/> 否则为 <see langword="false"/></returns>
    public static bool IsSingleView(this Application? application)
    {
        return application?.ApplicationLifetime is ISingleViewApplicationLifetime is true;
    }
}
