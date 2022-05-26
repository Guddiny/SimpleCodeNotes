using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Pages.Info;
using SimpleCodeNotes.Ui.Pages.Notes;
using SimpleCodeNotes.Ui.Pages.Settings;
using SimpleCodeNotes.Ui.Settings;

namespace SimpleCodeNotes.Ui;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(
        AppSettings appSettings,
        NotesPageViewModel notesViewModel,
        SettingsPageViewModel settingsPageViewModel,
        InfoPageViewModel infoPageViewModel)
    {
        AppSettings = appSettings;
        NotesViewModel = notesViewModel;
        SettingsViewModel = settingsPageViewModel;
        InfoViewModel = infoPageViewModel;
    }

    public NotesPageViewModel NotesViewModel { get; set; }

    public SettingsPageViewModel SettingsViewModel { get; set; }

    public InfoPageViewModel InfoViewModel { get; set; }

    public AppSettings AppSettings { get; set; }
}