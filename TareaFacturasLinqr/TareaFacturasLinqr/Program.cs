using System;
using TareaFacturasLinqr.Clases;
using System.Collections.Generic;
using System.Linq;

namespace TareaFacturasLinqr
{
    class Program
    {
        static void Main(string[] args)
        {
            //INSERTAR 10 INSTANCIAS POR CADA UNA DE LAS CLASES EXPUESTAS

            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(){Id = 1, Nombre="Pablo"},
                new Cliente(){Id = 2, Nombre = "Josselyn"},
                new Cliente(){Id = 3, Nombre = "Bryan"},
                new Cliente(){Id = 4, Nombre = "Carlos"},
                new Cliente(){Id = 5, Nombre = "Luis"},
                new Cliente(){Id = 6, Nombre = "Leonardo"},
                new Cliente(){Id = 7, Nombre = "Andres"},
                new Cliente(){Id = 8, Nombre = "Antonio"},
                new Cliente(){Id = 9, Nombre = "Ariel"},
                new Cliente(){Id = 10, Nombre = "Maryangel"},
            };
            List<Factura> facturas = new List<Factura>()
            {

                new Factura (){Observacion= "Jarra", Idcliente= 1311582045, Fecha= "2 de Diciembre 2019", Total= 80.90f},
                new Factura (){Observacion= "Jarra", Idcliente= 1324950505, Fecha= "15 de Diciembre 2019", Total= 23.10f},
                new Factura (){Observacion= "Jarra", Idcliente= 1312592198, Fecha= "5 de Enero 2020", Total= 45.81f},
                new Factura (){Observacion= "Jarra", Idcliente= 1334567890, Fecha= "8 de Enero 2020", Total= 24.70f},
                new Factura (){Observacion= "Jarra", Idcliente= 1313537545, Fecha= "10 de Enero 2020", Total= 10.10f},
                new Factura (){Observacion= "Jarra", Idcliente= 1324099296, Fecha= "13 de Enero 2020", Total= 8.24f},
                new Factura (){Observacion= "Jarra", Idcliente= 1309872717, Fecha= "14 de Enero 2020", Total= 28.15f},
                new Factura (){Observacion= "Jarra", Idcliente= 1308674245, Fecha= "16 de Enero 2020", Total= 76.90f},
                new Factura (){Observacion= "Jarra", Idcliente= 1373785377, Fecha= "18 de Enero 2020", Total= 21.14f},
                new Factura (){Observacion= "Jarra", Idcliente= 1357463512, Fecha= "21 de Enero 2020", Total= 67.80f}
                
            };
            //1.- Los 3 clientes con mayor monto de ventas.

            Console.WriteLine("Los 3 clientes con mayor monto de ventas. \n");
            var Consulta1 = from Datosdelcliente in clientes
                                  join FACTURA in facturas.Where(x => x.Total > 60.00f)
                              on Datosdelcliente.Id equals FACTURA.Idcliente
                                  select new { Nombrecliente = Datosdelcliente.Nombre, Totaldefactura = FACTURA.Total };

            Consulta1.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Nombrecliente + " = " + x.Totaldefactura + "$");
            });
            Console.WriteLine("");

            //2.- Los 3 clientes con menor monto en ventas. 

            Console.WriteLine("\n Los 3 clientes con menor monto en ventas.  \n");

            var Consulta2 = from Datosdelcliente in clientes
                                  join FACTURA in facturas.Where(x => x.Total <= 28.550f)
                                  on Datosdelcliente.Id equals FACTURA.Idcliente
                                  select new { Nombrecliente = Datosdelcliente.Nombre, Totaldefactura = FACTURA.Total };

            Consulta2.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Nombrecliente + " = " + x.Totaldefactura + "$");
            });

            //3.- El cliente con más ventas realizadas.

            Console.WriteLine("\n El cliente con más ventas realizadas. \n");
            var Consulta3 = from Datosdelcliente in clientes
                                  where Datosdelcliente.Nombre.ToUpper() == "A".ToUpper()
                                  join FACTURAS in facturas on Datosdelcliente.Id equals FACTURAS.Idcliente
                                  group Datosdelcliente by FACTURAS.Total into resumen
                                  select new
                                  {
                                      Ventas = resumen.Key,
                                      Nombrecliente = (from RESUMEN in resumen
                                                          select RESUMEN.Nombre.ToString()).Min(),
                                  };
            Consulta3.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Nombrecliente + " = " + x.Ventas + "$");
            });

            //4.- Cada cliente y su cantidad de ventas realizadas.

            Console.WriteLine("\n Cada cliente y su cantidad de ventas realizadas. \n");

            var Consulta4 = from Datosdelcliente in clientes
                                 join FACTURA in facturas on Datosdelcliente.Id equals FACTURA.Idcliente
                                 select new
                                 {
                                     Nombrecliente = Datosdelcliente.Nombre,
                                     CantidadDeVentas = FACTURA.Total,
                                     detalles = FACTURA.Observacion
                                 };
            Consulta4.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Nombrecliente + "= " + x.CantidadDeVentas + "$ EN " + x.detalles);
            });
            Console.WriteLine("");

            //5.- Las ventas realizadas en el año 2019.

            Console.WriteLine("\n Las ventas realizadas en el año 2019. \n");

            var Consulta5 = from Datosdelcliente in clientes
                                 join FACTURAS in facturas on Datosdelcliente.Id equals FACTURAS.Idcliente
                                 where FACTURAS.Anio == 2019
                                 select new
                                 {
                                     Fechas = FACTURAS.Fecha,
                                     Nombrecliente = Datosdelcliente.Nombre,
                                     Totalventas = FACTURAS.Total,
                                     Detalles = FACTURAS.Observacion
                                 };
            Consulta5.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Nombrecliente + " = " + x.Totalventas + " $ EN " + x.Detalles + " FECHA = " + DateTime.Now.ToString(x.Fechas));
                Console.WriteLine();
            });

            //6.- La venta más antigua.

            Console.WriteLine("\n La venta más antigua.\n");

            var Consulta6 = from Datosdelcliente in clientes
                                join FACTURAS in facturas on Datosdelcliente.Id equals FACTURAS.Idcliente
                                where FACTURAS.Fecha == "1 de Enero 2020"
                                select new
                                {
                                    Fechas = FACTURAS.Fecha,
                                    Nombrecliente = Datosdelcliente.Nombre,
                                    Totalventas = FACTURAS.Total,
                                    Detalles = FACTURAS.Observacion
                                };
            Consulta6.ToList().ForEach(x =>
            {

                Console.WriteLine(x.Nombrecliente + " = " + x.Totalventas + " $ EN " + x.Detalles + " FECHA = " + DateTime.Now.ToString(x.Fechas));
                Console.WriteLine();
            });

            //7.- Los clientes que tengan una venta cuya observación comience con "Plato".

            Console.WriteLine("\n Los clientes que tengan una venta cuya observación comience con PLATO. \n");

            var Consulta7 = from Datosdelcliente in clientes
                                  join FACTURA in facturas on Datosdelcliente.Id equals FACTURA.Idcliente
                                  where FACTURA.Observacion.ToUpper() == "PLATOS".ToUpper() || FACTURA.Observacion.ToUpper() == "PLATOS".ToUpper()
                                  select new
                                  {
                                      Fechas = FACTURA.Fecha,
                                      Nombrecliente = Datosdelcliente.Nombre,
                                      Totalventas = FACTURA.Total,
                                      Detalles = FACTURA.Observacion
                                  };
            Consulta7.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Nombrecliente + " = " + x.Totalventas + " $ en " + x.Detalles + " Fecha = " + DateTime.Now.ToString(x.Fechas));
            });


        }
    }
}
