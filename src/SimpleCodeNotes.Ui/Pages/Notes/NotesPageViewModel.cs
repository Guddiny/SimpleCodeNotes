using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Collections;
using ReactiveUI;
using SimpleCodeNotes.DataAccess.Repositories;
using SimpleCodeNotes.Ui.Common;
using SimpleCodeNotes.Ui.Mapping;
using TextMateSharp.Grammars;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class NotesPageViewModel : BaseViewModel
{
    private readonly ICodeNoteRepository _repository;
    private readonly RegistryOptions _registryOptions;
    private bool _isSaveIndicatorVisible;
    private ContentViewModel _content = new();

    public NotesPageViewModel(ICodeNoteRepository repository)
    {
        _repository = repository;

        SaveCmd = ReactiveCommand.Create(Save);
        AddNewNoteCmd = ReactiveCommand.Create(AddNewNote);

        _registryOptions = new RegistryOptions(ThemeName.DarkPlus);
        SupportedSyntaxes.AddRange(_registryOptions.GetAvailableLanguages().Select(l => l.Id));

        Notes.Collection.AddRange(_repository.GetMetadata().ToViewModel());

        this.WhenAnyValue(x => x.Notes.SelectedItem)
            .WhereNotNull()
            .Subscribe(i =>
            {
                Content.Document.Text = _repository.GetContent(i.Id)?.Text ?? string.Empty;
            });
    }

    public ReactiveCommand<Unit, Task> SaveCmd { get; set; }

    public ReactiveCommand<Unit, Unit> AddNewNoteCmd { get; set; }

    public PageItemsViewModel<NoteViewModel> Notes { get; set; } = new();

    public AvaloniaList<string> SupportedSyntaxes { get; set; } = new();

    public bool IsSaveIndicatorVisible
    {
        get => _isSaveIndicatorVisible;
        set => this.RaiseAndSetIfChanged(ref _isSaveIndicatorVisible, value);
    }

    public ContentViewModel Content
    {
        get => _content;
        set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    private async Task Save()
    {
        // Save data into database
        IsSaveIndicatorVisible = true;
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        IsSaveIndicatorVisible = false;
    }

    private void AddNewNote()
    {
        var note = new NoteViewModel
        {
            Name = "New note",
            Syntax = "markdown"
        };

        Notes.Collection.Add(note);
        Notes.SelectedItem = note;
    }
}
