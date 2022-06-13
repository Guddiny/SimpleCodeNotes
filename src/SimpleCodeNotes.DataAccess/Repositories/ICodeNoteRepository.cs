using LiteDB;
using SimpleCodeNotes.DataAccess.Dto;
using SimpleCodeNotes.DataAccess.Entities;

namespace SimpleCodeNotes.DataAccess.Repositories;

public interface ICodeNoteRepository
{
    void Init(Note note);

    List<Note> GetNotes();

    List<MetadataDto> GetMetadata(int limit = 50);

    ContentDto? GetContent(ObjectId id);
}
