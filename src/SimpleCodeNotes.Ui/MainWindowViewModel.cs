using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Pages.Notes;
using SimpleCodeNotes.Ui.Settings;

namespace SimpleCodeNotes.Ui;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(
        AppSettings appSettings,
        NotesPageViewModel notesViewModel)
    {
        AppSettings = appSettings;
        NotesViewModel = notesViewModel;
    }

    public NotesPageViewModel NotesViewModel { get; set; }

    public AppSettings AppSettings { get; set; }
}