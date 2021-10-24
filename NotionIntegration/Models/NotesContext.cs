using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace NotionIntegration.Models
{
    public class NotesContext : DbContext
    {
        private readonly string connectionString;

        public DbSet<Note> Notes { get; set; }

        public NotesContext(IOptions<NotesOptions> options)
        {          
            connectionString = options.Value.mssql ?? throw new ArgumentNullException("no connection string");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer(connectionString);
    }
}
