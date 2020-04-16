using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contratos
{
     public interface IUnitOfWork : IDisposable
    {
        ICreditoRepository CreditoRepository { get; }
        IAbonoRepository AbonoRepository { get; }
       ICuotaRepository CuotaRepository { get; }
        int Commit();
    }
}
