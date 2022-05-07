﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIAWF1._1.Models
{
    public class EstadisticaBateoModel
    {
        [DisplayName("Nombre del bateador")]
        public string NombreBateador { get; set; }
        [DisplayName("Veces al bat")]
        public int VecesAlBat { get; set; }
        public int Hits { get; set; }
        public int Dobletes { get; set; }
        public int Tripletes { get; set; }
        public int HR { get; set; }
        [DisplayName("Bases por bola")]
        public int BasesPorBola { get; set; }
        [DisplayName("Bases por golpe")]
        public int BasesPorGolpe { get; set; }
        public int Sacrificios { get; set; }
        public double AVG { get; set; }
        [DisplayName("AVG")]
        public string AVGStr
        {
            get { return string.Format("{0:0.000}", AVG); }
        }
        public double OBP { get; set; }
        [DisplayName("OBP")]
        public string OBPStr
        {
            get { return string.Format("{0:0.000}", OBP); }
        }
        public double SLUG { get; set; }
        [DisplayName("SLUG")]
        public string SLUGStr
        {
            get { return string.Format("{0:0.000}", SLUG); }
        }
        public double OPS { get; set; }
        [DisplayName("OPS")]
        public string OPSStr
        {
            get { return string.Format("{0:0.000}", OPS); }
        }

    }
}
