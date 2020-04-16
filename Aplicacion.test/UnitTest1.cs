using Infraestructura;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Aplicacion.test
{
    public class Tests
    {
        CreditoContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<CreditoContext>().UseInMemoryDatabase("Credito").Options;

            _context = new CreditoContext(optionsInMemory);
        }

        [Test]
        public void CrearCreditoTest()
        {
            var request = new CrearCreditoRequest { Cedula="1063564636",Nombre="Juan",ValorCredito= 6000000 , Salario= 5000000 ,plazo=4};
            CrearCreditoService _service = new CrearCreditoService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Se creó con éxito la cuenta 1063564636.", response.Mensaje);
           
        }

        [Test]
        public void Abonar()
        {
            var request = new CrearCreditoRequest { Cedula = "1063564636", Nombre = "Juan", ValorCredito = 6000000, Salario = 5000000, plazo = 4 };
            var request2 = new AbonarRequest { Cedula = "1063564636", Valor = 5000000 };
            CrearCreditoService _service = new CrearCreditoService(new UnitOfWork(_context));
            AbonarService _service1 = new AbonarService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            var response1 = _service1.Abonar(request2);
            Assert.AreEqual("Su Nuevo saldo es 13000000.", response1.Mensaje);

        }
    }
}