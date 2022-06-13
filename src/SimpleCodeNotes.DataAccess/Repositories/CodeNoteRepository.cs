using LiteDB;
using SimpleCodeNotes.DataAccess.Dto;
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

    public List<MetadataDto> GetMetadata(int limit = 50)
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var collection = db.GetCollection<Note>(NotesConnectionName);
            collection.EnsureIndex(x => x.Name);

            var result = collection
                .Query()
                .OrderBy(x => x.Name)
                .Select(x => new MetadataDto
                {
                    Name = x.Name,
                    Id = x.Id,
                    Created = x.Created,
                    Description = x.Description,
                    Syntax = x.Syntax,
                    Tags = x.Tags,
                    Updated = x.Updated,
                    Workspace = x.Workspace
                })
                .Limit(limit)
                .ToList();

            return result;
        }
    }

    public ContentDto? GetContent(ObjectId id)
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var collection = db.GetCollection<Note>(NotesConnectionName);
            collection.EnsureIndex(x => x.Id);

            var result = collection
                .Query()
                .Where(x => x.Id == id)
                .Select(x => new ContentDto
                {
                    Id = x.Id,
                    Text = x.Content,
                    Created = x.Created,
                    Updated = x.Updated
                })
                .FirstOrDefault();

            return result;
        }
    }

    public void Init(Note note)
    {
        using (var db = new LiteDatabase(_connectionString))
        {
            var collection = db.GetCollection<Note>(NotesConnectionName);
            collection.Insert(note);
        }
    }
}
