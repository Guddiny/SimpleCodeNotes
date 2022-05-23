using Avalonia.Collections;
using SimpleCodeNotes.DataAccess.Entities;
using SimpleCodeNotes.Ui.Common;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class NotesPageViewModel : ViewModelBase
{
    public NotesPageViewModel()
    {
    }

    public AvaloniaList<Note> Notes { get; set; } = new()
    {
        new()
        {
            Name = "Note 1"
        },
        new()
        {
            Name = "Note 2"
        }
    };
}