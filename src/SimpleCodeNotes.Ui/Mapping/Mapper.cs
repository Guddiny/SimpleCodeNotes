using Avalonia.Collections;
using SimpleCodeNotes.DataAccess.Entities;
using SimpleCodeNotes.Ui.Pages.Notes;
using System.Collections.Generic;

namespace SimpleCodeNotes.Ui.Mapping;

public static class Mapper
{
    public static NoteViewModel ToViewModel(this Note note)
    {
        return new()
        {
            Id = note.Id,
            Description = note.Description,
            Content = note.Content,
            Syntax = note.Syntax,
            Created = note.Created,
            Updated = note.Updated,
            Name = note.Name,
            Workspace = note.Workspace,
            Tags = new AvaloniaList<string>(note.Tags)
        };
    }

    public static AvaloniaList<NoteViewModel> ToViewModel(this List<Note> notes)
    {
        var list = new AvaloniaList<NoteViewModel>();

        foreach (var note in notes)
        {
            list.Add(ToViewModel(note));
        }

        return list;
    }
}