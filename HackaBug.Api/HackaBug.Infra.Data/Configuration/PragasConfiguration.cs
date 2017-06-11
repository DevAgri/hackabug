using System.Data.Entity.ModelConfiguration;
using HackaBug.Domain.Entities;

namespace HackaBug.Infra.Data.Configuration
{
    public class PragasConfiguration: EntityTypeConfiguration<Pragas>
    {
        public PragasConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(80);

        }
    }
}