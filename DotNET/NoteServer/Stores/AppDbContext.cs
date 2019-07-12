using Microsoft.EntityFrameworkCore;
using NoteCore.Entitys;
using System;

namespace NoteServer.Stores
{
    public class AppDbContext : DbContext
    {

        public AppDbContext():base(){}
        public AppDbContext(DbContextOptions options):base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteUserRelation> NoteUserRelations { get; set; }

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

        public static string GetPropertyName(Func<User, object> selector)
        {
            selector(new User());
            //selector.Method.GetGenericArguments()[0].GetFields().
            return "NickName";
        }
    }
}
