using System.Collections;
using System.Collections.Generic;
using HackaBug.Domain.Entities;

namespace HackaBug.Domain.Interfaces
{
    public interface IDadosPlantioRepository: IRepositoriesBase<DadosPlantio>
    {
        IEnumerable<DadosPlantio> listaAll();
    }
}