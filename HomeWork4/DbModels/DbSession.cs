using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DbModels
{
    public class DbSession
    {
        public const string TableName = "Sessions";

        public Guid Id { get; set; }
        public Guid MasseurId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime DateTime { get; set; }
        public string TypeOfMassage { get; set; }

        public DbClient Client { get; set; }
        public DbMasseur Masseur { get; set; }

        public DbSession()
        {
            Client = new DbClient();
            Masseur = new DbMasseur();
        }
    }

    public class DbSessionConfiguration : IEntityTypeConfiguration<DbSession>
    {
        public void Configure(EntityTypeBuilder<DbSession> builder)
        {
            builder.
                ToTable(DbMasseur.TableName);

            builder.
              HasKey(p => p.Id);
        }
    }
}
