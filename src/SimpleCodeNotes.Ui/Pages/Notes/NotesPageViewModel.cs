using Avalonia.Collections;
using ReactiveUI;
using SimpleCodeNotes.DataAccess.Entities;
using SimpleCodeNotes.Ui.Common;
using System.Linq;
using System.Reactive;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class NotesPageViewModel : ViewModelBase
{
    public NotesPageViewModel()
    {
        Save = ReactiveCommand.Create(Print);
    }

    public ReactiveCommand<Unit, Unit> Save { get; set; }

    public AvaloniaList<Note> Notes { get; set; } = new(Enumerable
        .Range(1, 4)
        .Select(i => new Note
        {
            Name = "Namea sd+as a+sd+a s+d+ a+sd+ " + i,
        })
        .ToList());

    private void Print()
    {
    }
}