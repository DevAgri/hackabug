using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackaBug.App.Model
{
    public class Sensores
    {
        public int Id { get; set; }
        public double Temperatura { get; set; }
        public double UmidadeRelativa { get; set; }
        public double Luminosidade { get; set; }
        public double Pressao { get; set; }
        public double NivelVento { get; set; }
        public double Medidas { get; set; }
    }
}
