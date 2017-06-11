using HackaBug.Domain.Entities;

namespace HackaBug.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HackaBug.Infra.Data.Context.HackabugContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // REMOVER QUANDO FOR PARA PRODUÇÃO 
            SetSqlGenerator("Mysql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(HackaBug.Infra.Data.Context.HackabugContext context)
        {
            CadastraCulturas(context);
        }

        private void CadastraCulturas(Context.HackabugContext context)
        {

            context.Culturas.Add(new Cultura() { Id = 1, Nome = "Soja", Status = true });
            context.Culturas.Add(new Cultura() { Id = 1, Nome = "Algodão", Status = true });

            context.SaveChanges();

            context.Estacoes.Add(new Estacoes() { Id = 1, Nome = "Talhão norte", Altura = "9", Latitude = "9999,222", Endereco = "http://192.168.0.10", Longetude = "2225,220" });
            context.Estacoes.Add(new Estacoes() { Id = 2, Nome = "Talhão Sul", Altura = "9", Latitude = "9999,222", Endereco = "http://192.168.0.10", Longetude = "2225,220" });
            context.SaveChanges();
        }
    }
}
