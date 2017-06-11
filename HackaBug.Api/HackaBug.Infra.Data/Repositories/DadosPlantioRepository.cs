using System.Collections.Generic;
using HackaBug.Domain.Entities;
using HackaBug.Domain.Interfaces;

namespace HackaBug.Infra.Data.Repositories
{
    public class DadosPlantioRepository: RepositoryBase<DadosPlantio>, IDadosPlantioRepository
    {
        public IEnumerable<DadosPlantio> listaAll()
        {
            return Db.DadosPlantios.Include("Cultura");
        }
    }
}