using ExamenP11.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Parar = false;
            while (!Parar)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("Seleccione la accion que desee realizar: ");
                Console.WriteLine("1. Operaciones Aritmeticas Básicas");
                Console.WriteLine("2. Calculo de Divisas");
                Console.WriteLine("3. Comprar Articulos");
                Console.WriteLine("4. Tabla de Multiplar de numero a desear");
                Console.WriteLine("5.SALIR");

                string opcion = Console.ReadLine();
                int o = Convert.ToInt32(opcion);

                Data _Datos = new Data();
                switch (o)
                {
                    case 1:
                        bool DetenerSuma = false;
                        while (!DetenerSuma)
                        {
                            Console.WriteLine("MENU DE CALCULADORA ARITMETICA BÁSICA");
                            Console.WriteLine($"El resultado es: {_Datos.OperacionesAritmeticas()}");
                            Console.WriteLine("¿Deseas Continuar en la Calculadora? S/N");
                            DetenerSuma = Console.ReadLine().ToLower() == "n" ? true : false;
                        }
                        break;
                    case 2:
                        bool DetenerDivisa = false;
                        while (!DetenerDivisa)
                        {
                            Console.WriteLine("CALCULO DE DIVISAS");
                            _Datos.CalculoDivisas();
                            Console.WriteLine("¿Deseas Continuar en el Calculo de Divisas? S/N");
                            DetenerDivisa = Console.ReadLine().ToLower() == "n" ? true : false;
                        }
                        break;
                    case 3:
                        bool DetenerCompra = false;
                        while (!DetenerCompra)
                        {
                            Console.WriteLine("Comprar Tienda");
                            _Datos.ComprarTienda();
                            Console.WriteLine("¿Deseas Continuar comprando? S/N");
                            DetenerCompra = Console.ReadLine().ToLower() == "n" ? true : false;
                        }
                        break;
                    case 4:
                        bool DetenerTabla = false;
                        while (!DetenerTabla)
                        {
                            Console.WriteLine("TABLA MULTIPLICAR");
                            _Datos.TablaDeNumero();
                            Console.WriteLine("¿Deseas Continuar en la tabla de multiplicar ? S/N");
                            DetenerTabla = Console.ReadLine().ToLower() == "n" ? true : false;
                        }
                        break;
                    case 5:
                        Parar = true;
                        break;
                }
            }
        }


    }
}
