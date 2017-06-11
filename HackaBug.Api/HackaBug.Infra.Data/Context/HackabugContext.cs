using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using HackaBug.Domain.Entities;
using HackaBug.Infra.Data.Configuration;

namespace HackaBug.Infra.Data.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class HackabugContext: DbContext
    {
        public HackabugContext()
            :base("hackabugdata")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
        }
        public DbSet<Sensores> Sensores { get; set; }
        public DbSet<ParametroAnalitico> ParametrosAnaliticos { get; set; }
        public DbSet<Cultura> Culturas { get; set; }
        public DbSet<DadosPlantio> DadosPlantios { get; set; }
        public DbSet<Pragas> Pragas { get; set; }
        public DbSet<Estacoes> Estacoes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();



            modelBuilder.Configurations.Add(new PragasConfiguration());
            modelBuilder.Configurations.Add(new CulturaConfiguration());
            modelBuilder.Configurations.Add(new DadoConfiguration());
            modelBuilder.Configurations.Add(new EstacaoConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}