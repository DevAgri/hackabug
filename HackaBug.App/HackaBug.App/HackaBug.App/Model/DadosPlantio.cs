using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackaBug.App.Model
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
