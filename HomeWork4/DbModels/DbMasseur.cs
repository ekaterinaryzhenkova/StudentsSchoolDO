using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbModels
{
    public class DbMasseur
    {
        public const string TableName = "Masseurs";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public ICollection<DbSession> Sessions { get; set; }
        public ICollection<DbReview> Reviews { get; set; }

        public DbMasseur()
        {
            Sessions = new HashSet<DbSession>();
            Reviews = new HashSet<DbReview>();
        }
    }

    public class DbMasseurConfiguration : IEntityTypeConfiguration<DbMasseur>
    {
        public void Configure(EntityTypeBuilder<DbMasseur> builder)
        {
            builder.
              ToTable(DbMasseur.TableName);

            builder.
              HasKey(p => p.Id);

            builder
              .HasMany(p => p.Sessions)
              .WithOne(n => n.Masseur)
              .HasForeignKey(s => s.MasseurId);

            /* builder
              .HasMany(p => p.Reviews)
              .WithMany(n => n.Masseurs); */
        }
    }
}
