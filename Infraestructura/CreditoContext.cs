using Dominio.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura
{
    public class CreditoContext : DbContextBase
    {
        public CreditoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Credito> creditos { get; set; }
        public DbSet<Cuota> cuotas { get; set; }
        public DbSet<Abono> abonos { get; set; }



    }
}
