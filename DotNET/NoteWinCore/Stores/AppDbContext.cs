using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;

namespace NoteWinCore.Stores
{
    /// <summary>
    /// 使用SQLite
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base() { }
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<NoteUserRelation> NoteUserRelations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=note.db");
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(a =>
            {
                a.HasKey(k => k.Id);
            });
            modelBuilder.Entity<Note>(a =>
            {
                a.HasKey(k => k.Id);
            });
            modelBuilder.Entity<NoteUserRelation>(a =>
            {
                a.HasKey(k => new { k.NoteId, k.UserId });
            });
        }
    }
}
