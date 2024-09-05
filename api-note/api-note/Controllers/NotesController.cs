using api_note.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_note.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NotesController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public NotesController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetNotes()
		{
			var notes = await _context.Notes
				.Select(note => new
				{
					note.Id,
					note.Title,
					note.Content
				})
				.ToListAsync();

			return Ok(notes);
		}

		[HttpPost]
		public async Task<IActionResult> CreateNote([FromBody] Note note)
		{
			if (note == null)
			{
				return BadRequest("Note is null.");
			}

			_context.Notes.Add(note);
			await _context.SaveChangesAsync();

			var createdNote = new
			{
				note.Id,
				note.Title,
				note.Content
			};

			return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, createdNote);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetNoteById(int id)
		{
			var note = await _context.Notes
				.Where(n => n.Id == id)
				.Select(n => new
				{
					n.Id,
					n.Title,
					n.Content
				})
				.FirstOrDefaultAsync();

			if (note == null)
			{
				return NotFound();
			}

			return Ok(note);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateNote(int id, [FromBody] Note note)
		{
			if (id != note.Id)
			{
				return BadRequest("Note ID mismatch.");
			}

			var existingNote = await _context.Notes.FindAsync(id);
			if (existingNote == null)
			{
				return NotFound();
			}

			existingNote.Title = note.Title;
			existingNote.Content = note.Content;

			_context.Notes.Update(existingNote);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNote(int id)
		{
			var note = await _context.Notes.FindAsync(id);
			if (note == null)
			{
				return NotFound();
			}

			_context.Notes.Remove(note);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
