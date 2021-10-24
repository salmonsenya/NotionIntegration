using NotionIntegration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotionIntegration.Repositories
{
    public interface INotesRepository
    {
        Task AddNoteAsync(Note note);

        Task AddNoteAsync(string text);

        Task<List<Note>> GetNotesAsync();
    }
}
