using System;
using System.Reactive;
using System.Threading.Tasks;
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

        SaveCmd = ReactiveCommand.Create(Save);
        AddNewNoteCmd = ReactiveCommand.Create(AddNewNote);

        var notes = _repository.GetNotes();
        Notes.Collection.AddRange(_repository.GetNotes().ToViewModel());
    }

    public ReactiveCommand<Unit, Task> SaveCmd { get; set; }

    public ReactiveCommand<Unit, Unit> AddNewNoteCmd { get; set; }

    public PageItemsViewModel<NoteViewModel> Notes { get; set; } = new();

    public bool IsSaveIndicatorVisible
    {
        get => _isSaveIndicatorVisible;
        set => this.RaiseAndSetIfChanged(ref _isSaveIndicatorVisible, value);
    }

    public async Task Save()
    {
        // Save data into database
        IsSaveIndicatorVisible = true;
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        IsSaveIndicatorVisible = false;
    }

    public void AddNewNote()
    {
        var note = new NoteViewModel
        {
            Name = "New note",
            Syntax = "Markdown (markdown)"
        };

        Notes.Collection.Add(note);
        Notes.SelectedItem = note;
    }
}
