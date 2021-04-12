using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_02_ver4
{
    class Program
    {
        static void Main(string[] args)
        {
            string codProducto;
            string ingreso;
            int stockInicial; //lo que voy a validar, si es numerico y si es > 0
            bool flag = false;
            /* bool ingresoCorrecto;
             int salida; //output de la validacion de ingresos

             string cantidadPedido; //restan al stock del producto +
             string cantidadEntrega, //suman al stock del producto -
             */
            Dictionary<string, int> productos = new Dictionary<string, int>();

            do
            {
                Console.WriteLine("Ingrese codigo de producto: || >>Escriba FIN para finalizar la carga del catalogo.<<"); //1er solicitud al usuario
                codProducto = Console.ReadLine();

                if (codProducto.Contains("FIN") == true)
                {
                    //cuando contiene fin
                    flag = true;
                }
                else
                {
                    bool ok = false;
                    do //2da solicitud al usuario + validacion de stock
                    {
                        
                        Console.WriteLine("Ingrese stock inicial del producto:");
                        ingreso = Console.ReadLine();
                        if (!int.TryParse(ingreso, out stockInicial)) //validacion
                        {
                            Console.WriteLine("Debe ingresar un dato numerico"); // <---- Valido que sea un dato numerico
                        }
                        else if (stockInicial < 0)
                        {
                            Console.WriteLine("Debe ingresar una cantidad mayor a cero"); // <---- Valido que sea un numero entero positivo
                        }
                        else
                        {
                            ok = true;
                        }
                    } while (ok == false);
                    productos.Add(codProducto, stockInicial);
                }  

            } while (flag == false);
  
            Console.WriteLine("\nCARGA INICIAL FINALIZADA!");
            Console.WriteLine($"\nCantidad de productos: {productos.Count}");

            Console.WriteLine();
            foreach (KeyValuePair<string, int> elemento in productos)
            {
                Console.WriteLine($"El codigo de producto es: {elemento.Key}, y el stock incial que le corresponde es:{elemento.Value}");
            }

            //------------------------HACER CODIGO DONDE SUMA Y RESTA CANTIDADES DEL STOCK INICIAL -------------------------------------

            //--------------------------MOSTRAR COMO QUEDO EL STOCK LUEGO DE LAS MODIFICACIONES ----------------------------------------

            Console.ReadKey();
        }
    }
}
