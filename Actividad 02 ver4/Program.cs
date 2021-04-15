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

            //A. INGRESO DE CATALOGO DE PRODUCTOS Y STOCK PARA C/U

            Dictionary<string, int> productos = new Dictionary<string, int>();

            do
            {
                Console.WriteLine("Ingrese código de producto: || >>Escriba FIN para finalizar la carga del catálogo.<<"); //1er solicitud al usuario
                codProducto = Console.ReadLine();

                if ((codProducto == "FIN") || (codProducto == "fin"))
                {
                    flag = true;  //cuando contiene fin
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
                            Console.WriteLine("ERROR. Debe ingresar un dato numérico"); // <---- Valido que sea un dato numerico
                        }
                        else if (stockInicial < 0)
                        {
                            Console.WriteLine("ERROR. Debe ingresar una cantidad mayor a cero"); // <---- Valido que sea un numero entero positivo
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
                Console.WriteLine($"Código de producto: {elemento.Key} - Stock incial:{elemento.Value}.");
            }

            //B. INGRESO DE PEDIDOS (RESTAN) Y ENTREGAS (SUMAN) DE PRODUCTOS

            int cantIngresada; 
            string codABuscar;
            string aux;
            int nuevoStock;
            bool flag2 = false; 

            Console.WriteLine("\nIngresos y Egresos de pedidos. ");
            do
            {
                Console.WriteLine("\nIngrese el codigo de producto a buscar: || >>Ingrese 'salir' para finalizar.<<"); //Cantidad ingresada suma al stock
                codABuscar = Console.ReadLine();

                if (codABuscar.Contains("salir") == true)
                {
                    flag2 = true; //cuando ingresa 'salir'
                }
                else
                {
                    bool ok2 = false;
                    do
                    {
                        if (productos.ContainsKey(codABuscar))
                        {
                            Console.WriteLine("\nStock actual: " + productos[codABuscar]);

                            Console.WriteLine("Ingrese cantidad de ENTREGAS(nro +) o PEDIDOS (nro -) de productos: || >>Ingrese 'X' para salir.<<");
                            aux = Console.ReadLine();

                            if((aux=="X") || (aux=="x"))
                            {
                                ok2 = true;
                            }
                            else
                            {
                                if (!int.TryParse(aux, out cantIngresada)) // Validacion
                                {
                                    Console.WriteLine("ERROR. Debe ingresar un dato numérico");
                                }
                                else
                                {
                                    //Console.WriteLine("cantidad de entrega:" + cantIngresada);

                                    //es el stockInicial   valor positivo o negativo (siempre suma)
                                    nuevoStock = productos[codABuscar] + cantIngresada;

                                    if (nuevoStock < 0)
                                    {
                                        Console.WriteLine("ERROR. El rdo final no puede ser menor a 0.");
                                    }
                                    else
                                    {
                                        //Console.WriteLine($"Stock nuevo:{nuevoStock}"); //deuelve el resultado, redundante. 
                                        productos[codABuscar] = nuevoStock;
                                    }
                                }
                            }
                           
                        }
                        else
                        {
                            Console.WriteLine("ERROR. El producto no se encontro en el catálogo.");
                            ok2 = true;
                        }
                    } while (ok2 == false);
                }

            } while (flag2 == false);
    
            //C. MOSTRAR COMO QUEDO EL STOCK LUEGO DE LAS MODIFICACIONES

            Console.WriteLine($"\nReporte con stock final de productos.");

            Console.WriteLine();
            foreach (KeyValuePair<string, int> elemento in productos)
            {
                Console.WriteLine($"Codigo de producto: {elemento.Key} - Stock final:{elemento.Value}.");
            }

            Console.ReadKey();
        }
    }
}       