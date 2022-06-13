using AvaloniaEdit.Document;
using ReactiveUI;
using SimpleCodeNotes.Ui.Common;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class ContentViewModel : BaseViewModel
{
    private TextDocument _document = new();

    public TextDocument Document
    {
        get => _document;
        set => this.RaiseAndSetIfChanged(ref _document, value);
    }
}
