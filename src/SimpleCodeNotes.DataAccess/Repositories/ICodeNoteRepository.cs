using SimpleCodeNotes.DataAccess.Entities;

namespace SimpleCodeNotes.DataAccess.Repositories;

public interface ICodeNoteRepository
{
    void Init(Note note);

    List<Note> GetNotes();
}