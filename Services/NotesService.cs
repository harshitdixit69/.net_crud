using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services;

public interface INotesService
{
    Task<NoteResponse> CreateNote(int userId, CreateNoteRequest request);
    Task<NoteResponse> GetNote(int userId, int noteId);
    Task<List<NoteResponse>> GetUserNotes(int userId);
    Task<NoteResponse> UpdateNote(int userId, int noteId, UpdateNoteRequest request);
    Task DeleteNote(int userId, int noteId);
}

public class NotesService : INotesService
{
    private readonly DataContext _context;

    public NotesService(DataContext context)
    {
        _context = context;
    }

    public async Task<NoteResponse> CreateNote(int userId, CreateNoteRequest request)
    {
        var note = new Note
        {
            Title = request.Title,
            Content = request.Content,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return ToNoteResponse(note);
    }

    public async Task<NoteResponse> GetNote(int userId, int noteId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null)
            throw new Exception("Note not found");

        return ToNoteResponse(note);
    }

    public async Task<List<NoteResponse>> GetUserNotes(int userId)
    {
        var notes = await _context.Notes
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();

        return notes.Select(ToNoteResponse).ToList();
    }

    public async Task<NoteResponse> UpdateNote(int userId, int noteId, UpdateNoteRequest request)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null)
            throw new Exception("Note not found");

        note.Title = request.Title;
        note.Content = request.Content;
        note.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return ToNoteResponse(note);
    }

    public async Task DeleteNote(int userId, int noteId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null)
            throw new Exception("Note not found");

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
    }

    private static NoteResponse ToNoteResponse(Note note)
    {
        return new NoteResponse
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt,
            UpdatedAt = note.UpdatedAt,
            UserId = note.UserId
        };
    }
} 