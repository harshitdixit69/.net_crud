using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Authorize] // This makes all endpoints require authentication
[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesService _notesService;

    public NotesController(INotesService notesService)
    {
        _notesService = notesService;
    }

    private int GetUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            throw new Exception("User ID not found in token");
        
        return int.Parse(userIdClaim.Value);
    }

    [HttpPost]
    public async Task<ActionResult<NoteResponse>> CreateNote(CreateNoteRequest request)
    {
        try
        {
            var userId = GetUserId();
            var note = await _notesService.CreateNote(userId, request);
            return Ok(note);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<NoteResponse>>> GetUserNotes()
    {
        try
        {
            var userId = GetUserId();
            var notes = await _notesService.GetUserNotes(userId);
            return Ok(notes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteResponse>> GetNote(int id)
    {
        try
        {
            var userId = GetUserId();
            var note = await _notesService.GetNote(userId, id);
            return Ok(note);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<NoteResponse>> UpdateNote(int id, UpdateNoteRequest request)
    {
        try
        {
            var userId = GetUserId();
            var note = await _notesService.UpdateNote(userId, id, request);
            return Ok(note);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteNote(int id)
    {
        try
        {
            var userId = GetUserId();
            await _notesService.DeleteNote(userId, id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
} 