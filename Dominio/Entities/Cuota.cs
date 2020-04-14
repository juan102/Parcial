using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Cuota
    {
        public double ValorCuota { get; set; }
        public int NumeroCuota { get; set; }
        public string Cedula { get; set; }
        //public DateTime fechaCuota { get; set; }
        public double SaldoPendiente { get; set; }
    }
}
