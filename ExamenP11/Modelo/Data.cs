using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP11.Modelo
{
    public class Data
    {
        private List<ObjetoOperaciones> Datos { get; set; }
        public decimal OperacionesAritmeticas()
        {
            Datos = new List<ObjetoOperaciones>();
            for (int i = 0; i < 2; i++)
            {
                ObjetoOperaciones Obj = new ObjetoOperaciones();
                Obj.Orden = i;
                if (i > 0)
                {
                    Console.WriteLine("\nOperaciones disponibles:");
                    Console.WriteLine("+ para Suma");
                    Console.WriteLine("- para Resta");
                    Console.WriteLine("* para Multiplicación");
                    Console.WriteLine("/ para División");
                    Console.Write("Selecciona la operación:");
                    Obj.Operador = Console.ReadLine();
                }
                Console.Write($"\nNúmero {i + 1}: ");
                Obj.Valor = decimal.Parse(Console.ReadLine());

                Datos.Add(Obj);
            }
            decimal Resultado = 0;
            Resultado = HacerOperacionAritmetica(Datos, Resultado);
            string cadena = string.Empty;
            foreach (var item in Datos.OrderBy(o => o.Orden).ToList())
            {
                if (item.Orden == 0)
                    cadena += $"{item.Valor} ";
                else
                    cadena += $"{item.Operador} {item.Valor} ";
            }
            Console.WriteLine($"\nOperación: {cadena}");
            return Resultado;
        }
        private decimal HacerOperacionAritmetica(List<ObjetoOperaciones> Fuente, decimal ResultadoActual)
        {
            foreach (var item in Fuente)
            {
                if (item.Orden == 0)
                {
                    ResultadoActual = item.Valor.Value;
                }
                else
                {
                    switch (item.Operador)
                    {
                        case "*":
                            ResultadoActual = ResultadoActual * item.Valor.Value;
                            break;
                        case "/":
                            ResultadoActual = ResultadoActual / item.Valor.Value;
                            break;
                        case "+":
                            ResultadoActual = ResultadoActual + item.Valor.Value;
                            break;
                        case "-":
                            ResultadoActual = ResultadoActual - item.Valor.Value;
                            break;
                    }
                }
            }
            return ResultadoActual;
        }
        private decimal HacerOperacionAritmetica(ObjetoOperaciones Fuente, decimal ResultadoActual)
        {
            switch (Fuente.Operador)
            {
                case "*":
                    ResultadoActual = ResultadoActual * Fuente.Valor.Value;
                    break;
                case "/":
                    ResultadoActual = ResultadoActual / Fuente.Valor.Value;
                    break;
                case "+":
                    ResultadoActual = ResultadoActual + Fuente.Valor.Value;
                    break;
                case "-":
                    ResultadoActual = ResultadoActual - Fuente.Valor.Value;
                    break;
            }
            return ResultadoActual;
        }
        public void CalculoDivisas()
        {
            Console.Write("Cuantos divisas capturarás? ");
            var CantidadStr = Console.ReadLine();
            int Cantidad = 0;
            if (!string.IsNullOrEmpty(CantidadStr))
                Cantidad = int.Parse(CantidadStr);
            else
                throw new Exception("No seleccionó cantidad de datos.");
            Datos = new List<ObjetoOperaciones>();

            ObjetoOperaciones Obj = new ObjetoOperaciones();
            Console.Write($"\nValor a convertir (MXN): $");
            Obj.Valor = decimal.Parse(Console.ReadLine());
            Datos.Add(Obj);

            for (int i = 1; i <= Cantidad; i++)
            {
                Obj = new ObjetoOperaciones();
                Obj.Orden = i;

                Console.WriteLine($"\nTipo de conversión {i}: (Ejemplo: Dolares)");
                Console.Write("Escriba operación:");
                Obj.Descripcion = Console.ReadLine();
                Console.Write($"\n1 {Obj.Descripcion} es igual a cuantos MXN? ");
                Obj.Valor = decimal.Parse(Console.ReadLine());
                Obj.Operador = "/";

                Datos.Add(Obj);
            }

            foreach (var item in Datos.Where(w => w.Orden > 0).OrderBy(o => o.Orden).ToList())
            {
                decimal vi = Datos.Where(w => w.Orden == 0).FirstOrDefault()?.Valor.Value ?? 0;
                decimal Resultado = vi;
                Resultado = HacerOperacionAritmetica(item, Resultado);
                string cadena = $"{vi} MXN {item.Operador} {item.Valor} {item.Descripcion} ";
                Console.WriteLine($"\n {cadena}");
                Console.WriteLine($"El resultado es: {Math.Round(Resultado, 2)} {item.Descripcion}");
            }
        }
        public void ComprarTienda()
        {
            try
            {
                List<Producto> LstProductosExistentes = new List<Producto>
                {
                    new Producto { Codigo = 101, Descripcion = "Agua", PrecioUnitario = Convert.ToDecimal(10.00) },
                    new Producto { Codigo = 102, Descripcion = "Huevo", PrecioUnitario = Convert.ToDecimal(30.00) },
                    new Producto { Codigo = 103, Descripcion = "Manzana", PrecioUnitario = Convert.ToDecimal(8.00) },
                    new Producto { Codigo = 104, Descripcion = "Pan", PrecioUnitario = Convert.ToDecimal(3.00) }
                };

                List<Producto> LstProductosPorComprar = new List<Producto>();
                bool Parar = false;
                while (!Parar)
                {
                    foreach (var Prod in LstProductosExistentes)
                    {
                        Console.WriteLine($"{Prod.Codigo}. {Prod.Descripcion} ${Prod.PrecioUnitario}");
                    }
                    Console.WriteLine("Escriba los productos que desea ingresar");

                    string Productos = Console.ReadLine();
                    int P = Convert.ToInt32(Productos.Trim());

                    Producto Existe = LstProductosExistentes.Where(w => w.Codigo == P).FirstOrDefault();
                    if (Existe != null)
                    {
                        Producto PorAgregar = new Producto();
                        PorAgregar = LstProductosExistentes.Where(w => w.Codigo == P).FirstOrDefault();

                        Console.WriteLine("¿Cuantas unidades desea agregar? ");

                        string Cantidad = Console.ReadLine();
                        int C = Convert.ToInt32(Cantidad);
                        PorAgregar.Cantidad = C;
                        PorAgregar.Precio = PorAgregar.PrecioUnitario * PorAgregar.Cantidad;

                        LstProductosPorComprar.Add(PorAgregar);

                        Console.WriteLine("¿Deseas Continuar? S/N");
                        Parar = Console.ReadLine().ToLower() == "n" ? true : false;

                    }
                    else
                    {
                        Console.WriteLine("El producto no existe");
                        Console.WriteLine("Escriba los productos que desea ingresar correctamente");
                    }
                }

                Console.WriteLine("TICKET DE COMPRA");
                foreach (var Productos in LstProductosPorComprar)
                {
                    Console.WriteLine($"Código: {Productos.Codigo} Descripción: {Productos.Descripcion} Precio Unitario: ${Productos.PrecioUnitario} Cantidad: {Productos.Cantidad} Precio: {Productos.Precio}");
                }
                Console.WriteLine($"Total a pagar: {LstProductosPorComprar.Select(s => s.Precio).Sum()}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("El archivo se ha guardado con éxito");
            }
        }
        public void TablaDeNumero()
        {
            ObjetoOperaciones Obj = new ObjetoOperaciones();
            Console.Write($"\nValor a multiplicar: ");
            Obj.Valor = decimal.Parse(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{Obj.Valor} x {i} = {Obj.Valor * i}");
            }
        }
    }
}
