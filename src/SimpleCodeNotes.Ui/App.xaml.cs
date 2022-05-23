using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Services;
using SimpleCodeNotes.Ui.Settings;
using SimpleCodeNotes.Ui.ViewModel;

namespace SimpleCodeNotes.Ui;

public partial class App : Application
{
    public App()
    {
        var appSettings = AppSettingsService.LoadSettings() ?? new AppSettings();

        ServiceProvider = new ServiceCollection()
            .AddSingleton<AppSettings>(appSettings)
            .AddSingleton<MainWindowViewModel>()
            .BuildServiceProvider();

        DataTemplates.Add(new ViewLocator());
    }

    private ServiceProvider ServiceProvider { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetService<MainWindowViewModel>()
            };

            desktop.ShutdownRequested += Desktop_ShutdownRequested;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void Desktop_ShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        var settings = ServiceProvider?.GetService<AppSettings>();
        AppSettingsService.SaveSettings(settings!);
    }
}