using SimpleCodeNotes.DataAccess.Entities;

namespace SimpleCodeNotes.DataAccess.Repositories;

public interface ICodeNoteRepository
{
    List<Note> GetNotes();
}