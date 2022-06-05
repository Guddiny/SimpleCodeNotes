using System;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Collections;
using ReactiveUI;
using SimpleCodeNotes.DataAccess.Repositories;
using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Mapping;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class NotesPageViewModel : BaseViewModel
{
    private readonly ICodeNoteRepository _repository;
    private bool _isSaveIndicatorVisible;

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

    public ReactiveCommand<Unit, Task> Save { get; set; }

    public PageItemsViewModel<NoteViewModel> Notes { get; set; } = new();

    public bool IsSaveIndicatorVisible
    {
        get => _isSaveIndicatorVisible;
        set => this.RaiseAndSetIfChanged(ref _isSaveIndicatorVisible, value);
    }

    public async Task Print()
    {
        // Save data into database
        IsSaveIndicatorVisible = true;
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        IsSaveIndicatorVisible = false;
    }
}
