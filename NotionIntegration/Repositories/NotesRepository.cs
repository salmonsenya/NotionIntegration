using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NotionIntegration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotionIntegration.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly DbContextOptions<NotesContext> _options;
        private const string CONNECTION_STRING = "mssql";

        public NotesRepository(IConfiguration configuration)
        {
            var _optionsBuilder = new DbContextOptionsBuilder<NotesContext>()
                .UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING));
            _options = _optionsBuilder.Options;
        }

        public async Task AddNoteAsync(Note note)
        {
            using var _notesContext = new NotesContext(_options);
            await _notesContext.Notes.AddAsync(note);
            await _notesContext.SaveChangesAsync();
        }

        public async Task AddNoteAsync(string text)
        {
            var note = new Note { Text = text };
            using var _notesContext = new NotesContext(_options);
            await _notesContext.Notes.AddAsync(note);
            await _notesContext.SaveChangesAsync();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            using var _notesContext = new NotesContext(_options);
            return await _notesContext.Notes.ToListAsync();
        }
    }
}
