using System;
using Avalonia.Collections;
using LiteDB;
using ReactiveUI;
using SimpleCodeNotes.Ui.Common;

namespace SimpleCodeNotes.Ui.Pages.Notes;

public class NoteViewModel : BaseViewModel
{
    private ObjectId _id = ObjectId.Empty;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private string _workspace = string.Empty;
    private string _syntax = string.Empty;
    private string _content = string.Empty;
    private DateTime _created;
    private DateTime _updated;

    public ObjectId Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public string Workspace
    {
        get => _workspace;
        set => this.RaiseAndSetIfChanged(ref _workspace, value);
    }

    public string Syntax
    {
        get => _syntax;
        set => this.RaiseAndSetIfChanged(ref _syntax, value);
    }

    public string Content
    {
        get => _content;
        set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public DateTime Created
    {
        get => _created;
        set => this.RaiseAndSetIfChanged(ref _created, value);
    }

    public DateTime Updated
    {
        get => _updated;
        set => this.RaiseAndSetIfChanged(ref _updated, value);
    }

    public AvaloniaList<string> Tags { get; set; } = new();

    public void Test()
    {
    }
}
