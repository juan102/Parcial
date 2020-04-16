﻿using Dominio.Entities;
using Dominio.Repositorio;
using Infraestructura.Base;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Repositorio
{
    public class CreditoRepository : GenericRepository<Credito>, ICreditoRepository
    {
        public CreditoRepository(IDbContext context)
              : base(context)
        {

        }
    }
}
