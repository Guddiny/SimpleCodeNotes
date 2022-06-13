using LiteDB;

namespace SimpleCodeNotes.DataAccess.DTO
{
    public class BaseDto
    {
        public ObjectId Id { get; set; } = new ObjectId();

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
