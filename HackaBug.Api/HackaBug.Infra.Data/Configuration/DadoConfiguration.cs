using System.Data.Entity.ModelConfiguration;
using HackaBug.Domain.Entities;

namespace HackaBug.Infra.Data.Configuration
{
    public class DadoConfiguration: EntityTypeConfiguration<DadosPlantio>
    {
        public DadoConfiguration()
        {
            HasKey(x => x.Id);
            HasRequired(x => x.Cultura);
        }
    }
}