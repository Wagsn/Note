using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;

namespace NoteServer.Stores
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
