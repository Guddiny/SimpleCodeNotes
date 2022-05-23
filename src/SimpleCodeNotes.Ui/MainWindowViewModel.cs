using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Settings;
using System.Collections.ObjectModel;

namespace SimpleCodeNotes.Ui;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(
        AppSettings appSettings)
    {
        AppSettings = appSettings;
    }

    public ObservableCollection<string> Notes { get; set; } = new();

    public AppSettings AppSettings { get; set; }
}