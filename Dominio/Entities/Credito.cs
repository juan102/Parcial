using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entities
{
    public class Credito
    {
        public Credito()
        {
            Cuotas = new List<Cuota>();
            Abonos = new List<Abono>();
        }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public double ValorCredito { get; set; }
        public int Salario { get; set; }
        public double ValorPagar { get; set; }
        public DateTime Fecha { get; set; }
        public List<Cuota> Cuotas { get; set; }
        public int plazo { get; set; }
        public double ValorCuota { get; set; }

        public List<Abono> Abonos { get; set; }

        public void Guardar(double ValorCredito,int salario,int plazo)
        {
            if(ValorCredito>=5000000 && ValorCredito <= 10000000)
            {
                if(plazo<10 || plazo>0){

                    var Saldo = ValorCredito * (1 + 0.5 * plazo);
                    var cuota = Saldo / plazo;
                    if(cuota < this.Salario)
                    {


                        guardarCuota(cuota,Saldo,plazo);
                        this.ValorPagar = Saldo;
                        this.ValorCredito = ValorCredito;
                        this.plazo = plazo;
                        this.ValorCuota = cuota;
                        this.Fecha= DateTime.Now;
                        
                    }
                    else
                    {
                        throw new InvalidOperationException("incorrecto");
                    }


                }
                else
                {
                    throw new InvalidOperationException("incorrecto");
                }


            }
            else
            {
                throw new InvalidOperationException("El valor del crédito es incorrecto");
            }

        }

        public void guardarCuota(double cuota, double Saldo,int plazo)
        {
           
            for (var i=0; i < plazo; i++)
            {
                Cuota Cuota = new Cuota();
                Cuota.Cedula = this.Cedula;
                Cuota.NumeroCuota =i;
                Cuota.ValorCuota = cuota;
                Cuota.SaldoPendiente = Saldo;
                Cuotas.Add(Cuota);
            }

           

        }

        

        public void Abonar(double valor)
        {
            //Cuota Cuota = new Cuota();
           
            if (valor>0 &&  valor < this.ValorPagar)
            {
                if (valor>= this.ValorCuota )
                {
                    var Valor2 = valor;
                    for (var i=0;i<this.plazo-1;i++)
                    {
                        var Cuota1 = Cuotas.ElementAt(i);
                        
                        if (valor >= Cuota1.ValorCuota)
                        {
                            
                            //var Cuota2 = Cuotas.ElementAt(i+1);
                            valor = valor-Cuota1.ValorCuota;
                            Cuota1.ValorCuota = 0;
                            var Valor3 = Valor2 - valor;
                            Cuota1.SaldoPendiente = Cuota1.SaldoPendiente-Valor3;

                        }
                        else
                        {
                            Abono Abono = new Abono();
                            Abono.FechaAbono = DateTime.Now;
                            
                            Abono.ValorAbono = Valor2;
                            Abonos.Add(Abono);
                            var saldo = this.ValorPagar - Valor2;
                            Cuota1.ValorCuota = Cuota1.ValorCuota - valor;
                            Cuota1.SaldoPendiente = Cuota1.SaldoPendiente-Valor2;
                            this.ValorPagar = saldo;
                            i = this.plazo + 1;

                        }
                    }
                    

                }
                else
                {
                    throw new InvalidOperationException("incorrecto");
                }


            } 
            else
            {
                throw new InvalidOperationException("incorrecto");
            }

        }

        public List<Cuota> ConsultarCuotaPorCedula(string Numero)
        {
            List<Cuota> Cuotas = new List<Cuota>();
            foreach (var item in Cuotas)
            {
                if (item.Cedula==Numero)
                {
                    Cuotas.Add(item);
                }
            }
            return Cuotas;
        }



    }
}
