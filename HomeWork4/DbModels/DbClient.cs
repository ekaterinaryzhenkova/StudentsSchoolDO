using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbModels
{
    public class DbClient
    {
        public const string TableName = "Clients";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<DbSession> Sessions { get; set; }
        public ICollection<DbReview> Reviews { get; set; }

        public DbClient()
        {
            Sessions = new HashSet<DbSession>();
            Reviews = new HashSet<DbReview>();
        }
    }

    public class DbChanelConfiguration : IEntityTypeConfiguration<DbClient>
    {
        public void Configure(EntityTypeBuilder<DbClient> builder)
        {
            builder.
              ToTable(DbClient.TableName);

            builder.
              HasKey(p => p.Id);

            builder
              .HasMany(p => p.Sessions)
              .WithOne(n => n.Client)
              .HasForeignKey(s => s.ClientId);

            /* builder
              .HasMany(p => p.Reviews)
              .WithMany(n => n.Clients); */
        }
    }
}
