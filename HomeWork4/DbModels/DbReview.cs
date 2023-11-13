using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbModels
{
    public class DbReview
    {
        public const string TableName = "Reviews";

        public Guid Id { get; set; }
        public Guid MasseurId { get; set; }
        public Guid ClientId { get; set; }
        public int Mark { get; set; }
        public string Comment { get; set; }

        public ICollection<DbMasseur> Masseurs { get; set; }
        public ICollection<DbClient> Clients { get; set; }

        public DbReview()
        {
            Masseurs = new HashSet<DbMasseur>();
            Clients = new HashSet<DbClient>();
        }
    }

    public class DbReviewConfiguration : IEntityTypeConfiguration<DbReview>
    {
        public void Configure(EntityTypeBuilder<DbReview> builder)
        {
            builder.
                ToTable(DbReview.TableName);

            builder.
                HasKey(r => r.Id);
        }
    }
}
