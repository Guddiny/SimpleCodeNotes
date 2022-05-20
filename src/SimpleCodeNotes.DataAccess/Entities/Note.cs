namespace SimpleCodeNotes.DataAccess.Entities;

public class Note
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Workspace { get; set; } = string.Empty;

    public string Syntax { get; set; } = string.Empty;

    public List<string> Tags { get; set; } = new();

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}