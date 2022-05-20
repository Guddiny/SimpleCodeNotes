using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCodeNotes.Ui.Services;
using SimpleCodeNotes.Ui.Settings;
using SimpleCodeNotes.Ui.ViewModel;

namespace SimpleCodeNotes.Ui;

public class Startup
{
    public IConfiguration? Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var appSettings = AppSettingsService.LoadSettings() ?? new AppSettings();

        services.AddSingleton(appSettings);
        services.AddSingleton<MainWindowViewModel>();
    }
}