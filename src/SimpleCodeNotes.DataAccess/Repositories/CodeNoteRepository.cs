using LiteDB;
using SimpleCodeNotes.DataAccess.Entities;

namespace SimpleCodeNotes.DataAccess.Repositories;

internal class CodeNoteRepository : ICodeNoteRepository
{
    private const string NotesConnectionName = "notes";
    private readonly string _connectionString;

    public CodeNoteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Note> GetNotes()
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var collection = db.GetCollection<Note>(NotesConnectionName);
            collection.EnsureIndex(x => x.Name);

            var result = collection
                .Query()
                .OrderBy(x => x.Name)
                .ToList();

            return result;
        }
    }
}