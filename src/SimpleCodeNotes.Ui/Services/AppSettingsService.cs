using SimpleCodeNotes.Ui.Settings;
using System.IO;
using System.Text.Json;

namespace SimpleCodeNotes.Ui.Services;

public static class AppSettingsService
{
    public const string SettingsFileName = @"appSettings.json";

    public static void SaveSettings(AppSettings appSettings, string filePath = SettingsFileName)
    {
        var lines = JsonSerializer.Serialize(appSettings, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(filePath, lines);
    }

    public static AppSettings? LoadSettings(string filePath = SettingsFileName)
    {
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllText(filePath);
            var appSettings = JsonSerializer.Deserialize<AppSettings>(lines!);

            return appSettings;
        }

        return null;
    }
}