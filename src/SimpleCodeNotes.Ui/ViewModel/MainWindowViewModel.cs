using ReactiveUI;
using SimpleCodeNotes.Ui.Settings;
using System.Collections.ObjectModel;

namespace SimpleCodeNotes.Ui.ViewModel;

public class MainWindowViewModel : ReactiveObject
{
    public MainWindowViewModel(
        AppSettings appSettings)
    {
        AppSettings = appSettings;
    }

    public ObservableCollection<string> Notes { get; set; } = new();

    public AppSettings AppSettings { get; set; }
}