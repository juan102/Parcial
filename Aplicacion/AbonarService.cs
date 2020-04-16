using Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion
{
   public class AbonarService
    {
        readonly IUnitOfWork _unitOfWork;

        public AbonarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AbonarResponse Abonar(AbonarRequest request)
        {
            var cuenta = _unitOfWork.CreditoRepository.FindFirstOrDefault(t => t.Cedula == request.Cedula);
            if (cuenta != null)
            {
                cuenta.Abonar(request.Valor);
                _unitOfWork.Commit();
                return new AbonarResponse() { Mensaje = $"Su Nuevo saldo es {cuenta.ValorPagar}." };
            }
            else
            {
                return new AbonarResponse() { Mensaje = $"Número de Cuenta No Válido." };
            }
        }
    }

    public class AbonarRequest
    {
        public string Cedula { get; set; }
        public double Valor { get; set; }
    }
    public class AbonarResponse
    {
        public string Mensaje { get; set; }
    }


}


