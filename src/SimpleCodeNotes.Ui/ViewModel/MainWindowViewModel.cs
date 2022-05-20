using ReactiveUI;
using System.Collections.ObjectModel;

namespace SimpleCodeNotes.Ui.ViewModel;

public class MainWindowViewModel : ReactiveObject
{
    public ObservableCollection<string> Notes { get; set; } = new();
}