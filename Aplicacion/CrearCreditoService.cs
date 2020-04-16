using Dominio.Contratos;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion
{
    public class CrearCreditoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearCreditoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearCreditoResponse Ejecutar(CrearCreditoRequest request)
        {
            Credito credito = _unitOfWork.CreditoRepository.FindFirstOrDefault(t => t.Cedula == request.Cedula);
            if (credito==null)
            {
                Credito NuevoCredito = new Credito();
                NuevoCredito.Cedula = request.Cedula;
                NuevoCredito.Nombre = request.Nombre;
                NuevoCredito.Salario = request.Salario;
                NuevoCredito.Guardar(request.ValorCredito, request.Salario, request.plazo);
                _unitOfWork.CreditoRepository.Add(NuevoCredito);
                _unitOfWork.Commit();
                return new CrearCreditoResponse() { Mensaje = $"Se creó con éxito la cuenta {NuevoCredito.Cedula}."};
            }
            else
            {
                return new CrearCreditoResponse() { Mensaje = $"El número de cedula ya exite" };
            }

        }
    }

    public class CrearCreditoRequest
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public double ValorCredito { get; set; }
        public int Salario { get; set; }

        public int plazo { get; set; }
    }


    public class CrearCreditoResponse
    {
        public string Mensaje { get; set; }
        
    }
}
