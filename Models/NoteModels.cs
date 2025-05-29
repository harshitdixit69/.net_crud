namespace WebApi.Models;

public class CreateNoteRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
}

public class UpdateNoteRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
}

public class NoteResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int UserId { get; set; }
} 