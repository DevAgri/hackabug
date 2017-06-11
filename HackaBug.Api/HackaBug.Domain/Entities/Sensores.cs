using System;

namespace HackaBug.Domain.Entities
{
    public class Sensores
    {
        public int Id { get; set; }
        public double TempMinima { get; set; }
        public double TempMaxima { get; set; }
        public double MaxUmidadeDoAr { get; set; }
        public double MinUmidadeDoAr { get; set; }
        public double Temperatura { get; set; }
        public double MinTemp { get; set; }
        public double MaxAirHumidity { get; set; }
        public double minAirHumidity { get; set; }
        public double maxSoilTemp { get; set; }
        public bool isRaining { get; set; }
        public double tempAvrg { get; set; }
        public DateTime DataLeitura { get; set; }

    }
}