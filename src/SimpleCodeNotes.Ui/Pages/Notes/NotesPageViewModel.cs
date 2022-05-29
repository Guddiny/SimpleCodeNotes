using ReactiveUI;
using SimpleCodeNotes.DataAccess.Entities;
using SimpleCodeNotes.DataAccess.Repositories;
using SimpleCodeNotes.Ui.Common;
using System.Reactive;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class NotesPageViewModel : BaseViewModel
{
    private readonly ICodeNoteRepository _repository;

    public NotesPageViewModel(ICodeNoteRepository repository)
    {
        _repository = repository;

        Save = ReactiveCommand.Create(Print);

        var notes = _repository.GetNotes();

        Notes.Collection.AddRange(_repository.GetNotes());
    }

    public ReactiveCommand<Unit, Unit> Save { get; set; }

    public PageItemsViewModel<Note> Notes { get; set; } = new();

    public Note? SelectedNote { get; set; }

    private void Print()
    {
    }
}