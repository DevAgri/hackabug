using System.Data.Entity.ModelConfiguration;
using HackaBug.Domain.Entities;

namespace HackaBug.Infra.Data.Configuration
{
    public class EstacaoConfiguration:EntityTypeConfiguration<Estacoes>
    {
        public EstacaoConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}