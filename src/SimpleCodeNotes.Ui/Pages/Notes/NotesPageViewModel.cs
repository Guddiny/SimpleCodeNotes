using Avalonia.Collections;
using ReactiveUI;
using SimpleCodeNotes.DataAccess.Repositories;
using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Mapping;
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
        Notes.Collection.AddRange(_repository.GetNotes().ToViewModel());

        // _repository.Init(new Note
        // {
        //    Name = "Test tote",
        //    Content = "{\"Name\" : \"Alex\"}",
        //    Syntax = "json",
        //    Workspace = "My workspace",
        //    Tags = new() { "JSON", "Text" }
        // });
    }

    public ReactiveCommand<Unit, Unit> Save { get; set; }

    public PageItemsViewModel<NoteViewModel> Notes { get; set; } = new();

    public AvaloniaList<string> SupportedTypes { get; set; } = new() { "json", "cs" };

    public NoteViewModel? SelectedNote { get; set; }

    private void Print()
    {
    }
}