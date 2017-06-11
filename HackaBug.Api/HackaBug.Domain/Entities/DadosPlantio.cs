using System;

namespace HackaBug.Domain.Entities
{
    public class DadosPlantio
    {
        public int Id { get; set; }
        public string Tecnologia { get; set; }
        public DateTime DataPlantio { get; set; }
        public Cultura Cultura { get; set; }
        public int CulturaId { get; set; }

    }
}