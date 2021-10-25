using Microsoft.EntityFrameworkCore;

namespace NotionIntegration.Models
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }
    }
}
