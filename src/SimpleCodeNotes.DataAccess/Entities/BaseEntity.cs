using LiteDB;

namespace SimpleCodeNotes.DataAccess.Entities;

public class BaseEntity
{
    public ObjectId Id { get; set; } = new ObjectId();

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}