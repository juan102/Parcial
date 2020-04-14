using NUnit.Framework;
using Dominio.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Test
{
    public class Tests
    {
        Credito credito;
        [SetUp]
        public void Setup()
        {
            credito = new Credito() {
                Cedula = "213211233",
                Nombre = "jOSE Dario",
                Salario = 5000000
            };
        }

        [Test]
        public void GuardarinCorrecto()
        {
            var valor = 60.000000;
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => credito.Guardar(valor, credito.Salario, 4));

            Assert.Pass(ex.Message, "El valor del crédito es incorrecto");
        }

        [Test]
        public void GuardarPlazoinCorrecto()
        {
            var valor = 6.000000;
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => credito.Guardar(valor, credito.Salario, 12));

            Assert.Pass(ex.Message, "incorrecto");
        }

        [Test]
        public void GuardarCorrecto()
        {
            var valor = 6000000;
            credito.Guardar(valor, credito.Salario, 4);

            Assert.AreEqual(valor, credito.ValorCredito);
        }
    

        [Test]
        public void AbonarCorrecto()
        {
            var valor = 6000000;
            credito.Guardar(valor, credito.Salario, 4);
            var saldo = credito.ValorPagar - 5000000;
            credito.Abonar(5000000);

            //credito.Abonar(5000000);
            //var Cuota = credito.Cuotas.LastOrDefault();
            Assert.AreEqual(13000000, credito.ValorPagar);
        }

        [Test]
        public void AbonarIncorrecto()
        {
            var valor = 6000000;
            credito.Guardar(valor, credito.Salario, 4);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => credito.Abonar(0));

            Assert.Pass(ex.Message, "incorrecto");
           
        }

        [Test]
        public void AbonarCuotaIncorrecta()
        {
            var valor = 6000000;
            credito.Guardar(valor, credito.Salario, 4);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => credito.Abonar(3000000));

            Assert.Pass(ex.Message, "incorrecto");

        }

        [Test]
        public void ConsultarCuota()
        {
            var valor = 6000000;
            credito.Guardar(valor, credito.Salario, 4);
            var saldo = credito.ValorPagar - 5000000;
            credito.Abonar(5000000);
            credito.Abonar(5000000);
            Assert.AreEqual(8000000, credito.ValorPagar);
            
            foreach (var items in credito.Cuotas)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Numero de cuota"+" "+items.NumeroCuota);
                Console.WriteLine("Saldo Pendiente" + " " + credito.ValorPagar);
                Console.WriteLine("Valor Cuota" + " " + items.ValorCuota);

            }

        }

        [Test]
        public void ConsultarAbono()
        {
            var valor = 6000000;
            credito.Guardar(valor, credito.Salario, 4);
            var saldo = credito.ValorPagar - 5000000;
            credito.Abonar(5000000);
            //Assert.AreEqual(13000000, credito.ValorPagar);
            
            foreach (var items in credito.Abonos)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Valor abono" + " " + items.ValorAbono);
                Console.WriteLine("Fecha" + " " + items.FechaAbono);

            }

        }


    }
}