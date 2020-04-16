using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Abono : Entity<int>
    {
        public double ValorAbono { get; set; }
        public DateTime FechaAbono { get; set; }
        
    }
}
