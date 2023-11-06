using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    public class UsersDB : DbContext
    {
        public DbSet<DbUser> Users { get; set; }

        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=LessonDB;Trusted_Connection=True;Encrypt=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
              .HasKey(u => u.Id);
        }
    }
}
