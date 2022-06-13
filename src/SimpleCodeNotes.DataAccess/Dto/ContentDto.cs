using SimpleCodeNotes.DataAccess.DTO;

namespace SimpleCodeNotes.DataAccess.Dto
{
    public class ContentDto : BaseDto
    {
        public string Text { get; set; } = string.Empty;
    }
}
