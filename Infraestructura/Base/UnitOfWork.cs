using Dominio.Contratos;
using Dominio.Repositorio;
using Infraestructura.Repositorio;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private ICreditoRepository _creditoRepository;
        private IAbonoRepository _abonoRepository;
        private ICuotaRepository _cuotaRepository;

        public ICreditoRepository CreditoRepository
        {
            get
            {

                if (_creditoRepository == null)
                {
                    _creditoRepository = new CreditoRepository(_dbContext);
                }
                return _creditoRepository;
            }
        }
        public ICuotaRepository CuotaRepository
        {
            get
            {

                if (_cuotaRepository == null)
                {
                    _cuotaRepository = new CuotaRepository(_dbContext);
                }
                return _cuotaRepository;
            }
        }
        public IAbonoRepository AbonoRepository
        {
            get
            {

                if (_abonoRepository == null)
                {
                    _abonoRepository = new AbonoRepository(_dbContext);
                }
                return _abonoRepository;
            }
        }

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
