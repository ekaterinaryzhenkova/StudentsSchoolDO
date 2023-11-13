using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    public class HomeWork4DbContext : DbContext
    {
        private const string ConnectionString =
          @"Server=localhost\sqlexpress;Database=HomeWork4DB;Trusted_Connection=True;Encrypt=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<DbClient> Clients { get; set; }
        public DbSet<DbMasseur> Masseurs { get; set; }
        public DbSet<DbReview> Reviews { get; set; }
        public DbSet<DbSession> Sessions { get; set; }
    }
}
