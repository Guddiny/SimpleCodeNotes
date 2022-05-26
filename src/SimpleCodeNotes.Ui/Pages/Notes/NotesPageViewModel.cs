using Avalonia.Collections;
using ReactiveUI;
using SimpleCodeNotes.DataAccess.Entities;
using SimpleCodeNotes.Ui.Common;
using System.Reactive;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class NotesPageViewModel : ViewModelBase
{
    public NotesPageViewModel()
    {
        Save = ReactiveCommand.Create(Print);
    }

    public ReactiveCommand<Unit, Unit> Save { get; set; }

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

    private void Print()
    {
    }
}