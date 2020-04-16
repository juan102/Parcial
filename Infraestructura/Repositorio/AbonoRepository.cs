using Dominio.Entities;
using Dominio.Repositorio;
using Infraestructura.Base;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositorio
{
     public class AbonoRepository : GenericRepository<Abono>, IAbonoRepository
    {
        public AbonoRepository(IDbContext context)
              : base(context)
        {

        }
    }
}
