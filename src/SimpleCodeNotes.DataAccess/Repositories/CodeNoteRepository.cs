using SimpleCodeNotes.DataAccess.Entities;

namespace SimpleCodeNotes.DataAccess.Repositories;

internal class CodeNoteRepository : ICodeNoteRepository
{
    private readonly string _connectionString;

    public CodeNoteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Note> GetNotesList()
    {
        throw new NotImplementedException();
    }
}