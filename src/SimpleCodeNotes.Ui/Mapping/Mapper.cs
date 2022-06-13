using System.Collections.Generic;
using Avalonia.Collections;
using Microsoft.CodeAnalysis;
using SimpleCodeNotes.DataAccess.Dto;
using SimpleCodeNotes.DataAccess.Entities;
using SimpleCodeNotes.Ui.Pages.Notes;

namespace SimpleCodeNotes.Ui.Mapping;

public static class Mapper
{
    public static NoteViewModel ToViewModel(this MetadataDto metadata)
    {
        return new()
        {
            Id = metadata.Id,
            Description = metadata.Description,
            Syntax = metadata.Syntax,
            Created = metadata.Created,
            Updated = metadata.Updated,
            Name = metadata.Name,
            Workspace = metadata.Workspace,
            Tags = new AvaloniaList<string>(metadata.Tags)
        };
    }

    public static AvaloniaList<NoteViewModel> ToViewModel(this List<MetadataDto> metadata)
    {
        var list = new AvaloniaList<NoteViewModel>();

        foreach (var note in metadata)
        {
            list.Add(ToViewModel(note));
        }

        return list;
    }
}
