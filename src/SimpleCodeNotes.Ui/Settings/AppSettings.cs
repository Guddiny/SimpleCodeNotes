namespace SimpleCodeNotes.Ui.Settings;

public class AppSettings
{
    public WindowSettings WindowSettings { get; set; } = new();

    public DatabaseSettings DatabaseSettings { get; set; } = new();
}
