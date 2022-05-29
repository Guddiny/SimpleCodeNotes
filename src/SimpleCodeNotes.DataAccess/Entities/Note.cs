namespace SimpleCodeNotes.DataAccess.Entities;

public class Note : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Workspace { get; set; } = string.Empty;

    public string Syntax { get; set; } = string.Empty;

    public List<string> Tags { get; set; } = new();

    public string Content { get; set; } = string.Empty;
}