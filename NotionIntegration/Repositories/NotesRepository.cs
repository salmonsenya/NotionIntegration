using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NotionIntegration.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotionIntegration.Repositories
{
    public class NotesRepository : INotesRepository
    {
        public readonly IOptions<NotesOptions> _notesOptions;
        public NotesRepository(IOptions<NotesOptions> options)
        {
            _notesOptions = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task AddNoteAsync(Note note)
        {
            using var _notesContext = new NotesContext(_notesOptions);
            await _notesContext.Notes.AddAsync(note);
            await _notesContext.SaveChangesAsync();
        }

        public async Task AddNoteAsync(string text)
        {
            var note = new Note { Text = text };
            using var _notesContext = new NotesContext(_notesOptions);
            await _notesContext.Notes.AddAsync(note);
            await _notesContext.SaveChangesAsync();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            using var _notesContext = new NotesContext(_notesOptions);
            return await _notesContext.Notes.ToListAsync();
        }
    }
}
