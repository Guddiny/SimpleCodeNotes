using SimpleCodeNotes.Ui.Settings;
using System.Threading.Tasks;

namespace SimpleCodeNotes.Ui.Services;

public class AppSettingsService
{
    public const string SettingsFileName = @"appSettings.json";

    public Task SaveSettings(AppSettings appSettings)
    {
        return Task.CompletedTask;
    }

    public Task<AppSettings> LoadSettings()
    {
        return Task.FromResult(new AppSettings());
    }
}