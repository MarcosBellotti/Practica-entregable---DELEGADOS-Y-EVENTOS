using Logica;
using ClaseEstatica;

LogicaPrincipal instanciaLogica = LogicaPrincipal.Instance;
instanciaLogica.OperacionRealizada += HandlerProductoAgregadoOEliminado;

bool continuarWhile = true;

do
{
    Console.WriteLine("¿Que desea realizar con su producto? \n 1 = Cargar \n 2 = Eliminar");
    int actividad = Convert.ToInt32(Console.ReadLine());

    Console.Clear();

    Console.WriteLine("Marca");
    string marca = Console.ReadLine();
    Console.WriteLine("Modelo");
    string modelo = Console.ReadLine();
    Console.WriteLine("Numero de serie");
    int nroDeSerie = Convert.ToInt32(Console.ReadLine());

    switch (actividad)
    {
        case 1:

            Console.Clear();

            Console.WriteLine("¿Que tipo es? \n 1 = Monitor \n 2 = Computadora");
            actividad = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (actividad)
            {
                case 1:

                    Console.Clear();

                    Console.WriteLine("Año de fabricacion");
                    int añoDeFabricacion = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Pulgadas (ingrese 0 si no lo sabe)");
                    int pulgadas = Convert.ToInt32(Console.ReadLine());

                    instanciaLogica.AgregarProducto(modelo, marca, nroDeSerie, añoDeFabricacion, pulgadas);
                    break;
                case 2:

                    Console.Clear();

                    Console.WriteLine("Descripción del procesador");
                    string descripcionDelProcesador = Console.ReadLine();
                    Console.WriteLine("Nombre del fabricante");
                    string nombreDelFabricante = Console.ReadLine();
                    Console.WriteLine("Cantidad de ram (ingrese solo el numero): \n 2 GB \n 4 GB \n 8 GB \n 16 GB");
                    int cantidadDeRam = Convert.ToInt32(Console.ReadLine());

                    if(cantidadDeRam.ValidarValorBienCargado())
                    {
                        instanciaLogica.AgregarProducto(modelo, marca, nroDeSerie, descripcionDelProcesador, nombreDelFabricante, cantidadDeRam);
                    }
                    else
                    {
                        Console.WriteLine("Se cargó mal la cantidad de ram");
                    }
                    break;
            }
            break;
        case 2:
            instanciaLogica.EliminarProducto(modelo, marca, nroDeSerie);
            break;
    }

    Console.WriteLine("¿Desea continuar operando? S/N");
    continuarWhile = Console.ReadLine().ToLower()=="s";

} while (continuarWhile);

void HandlerProductoAgregadoOEliminado(object? sender, Eventos.Evento e)
{
    Console.Clear();

    if(e.Mensaje=="")
    {
        foreach(string valor in e.Listado)
        {
            if(valor== e.Listado.Last())
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{valor}. Total de monitores: {e.CantidadDeMonitores}.\n Total de computadoras: {e.CantidadDeComputadoras}.\n Monitores: {(e.CantidadDeMonitores * 100) / e.Listado.Count}.\n Computadoras: {(e.CantidadDeComputadoras * 100) / e.Listado.Count}");
                Console.ForegroundColor = ConsoleColor.Black;

            }
            else
            {
                Console.WriteLine(valor);
            }
            
        }
    }
    else
    {
        Console.WriteLine(e.Mensaje);
    }

    Thread.Sleep(2000);
}
