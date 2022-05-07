using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIAWF1._1.Models
{
    public class EstadisticaBateoModel
    {
        public string NombreBateador { get; set; }
        public int VecesAlBat{ get; set; }
        public int Hits { get; set; }
        public int Dobletes { get; set; }
        public int Tripletes { get; set; }
        public int HR { get; set; }
        public int BasesPorBola { get; set; }
        public int BasesPorGolpe { get; set; }
        public int Sacrificios { get; set; }
        public double AVG { get; set; }
        public double OBP { get; set; }
        public double SLUG { get; set; }
        public double OPS { get; set; }

    }
}
