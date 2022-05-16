using Entidades;

namespace Logica
{
    public class LogicaPrincipal
    {
        //Singleton
        private static LogicaPrincipal _instance = null;
        private LogicaPrincipal() { }
        public static LogicaPrincipal Instance { get { if (_instance == null) _instance = new LogicaPrincipal(); return _instance; } }

        //EventHandler
        public EventHandler<Eventos.Evento> OperacionRealizada;

        //Listas
        List<Pantalla> Monitores = new List<Pantalla>();
        List<Computadora> Computadoras = new List<Computadora>();
        List<Producto> Productos = new List<Producto>();
        List<string> DescripcionesDeLosProductos = new List<string>();

        public void AgregarProducto(string modelo, string marca, int numeroDeSerie, int añoDeFabricacion, int pulgadas) //Monitores
        {
            Monitores.Add(new Pantalla(modelo, marca, numeroDeSerie, añoDeFabricacion, pulgadas));
            LanzadorDeEvento("", ListaOrdenadaPorTipoDeProducto(""), Computadoras.Count, Monitores.Count); 
        }
        public void AgregarProducto(string modelo, string marca, int numeroDeSerie, string descripcion, string nombreDelFabricante, int cantidadDeRam) //Computadoras
        {
            Computadoras.Add(new Computadora(modelo, marca, numeroDeSerie, descripcion, nombreDelFabricante, cantidadDeRam));
            LanzadorDeEvento("",ListaOrdenadaPorTipoDeProducto(""), Computadoras.Count, Monitores.Count);
        }

        public void EliminarProducto(string modelo, string marca, int numeroDeSerie)
        {
            Producto productoBuscado = BuscarProducto(modelo, marca, numeroDeSerie);
            if (productoBuscado != null)
            {
                Productos.Remove(productoBuscado);
                if(Computadoras.Find(x=>x.Identificador == productoBuscado.Identificador) != null)
                {
                    Computadoras.Remove(Computadoras.Find(x => x.Identificador == productoBuscado.Identificador));
                }
                else
                {
                    Monitores.Remove(Monitores.Find(x => x.Identificador == productoBuscado.Identificador));
                }
                LanzadorDeEvento($"Se eleminó el {productoBuscado.MensajeParaListar()}", null, Computadoras.Count, Monitores.Count);
            }
            else
            {
                LanzadorDeEvento("No se encontró el elemento a borrar", null, Computadoras.Count, Monitores.Count);
            }
        }

        public List<string> ListaOrdenadaPorTipoDeProducto(string mensaje)
        {
            List<string> lista = new List<string>();    
            foreach(Producto producto in PolimorfismoProductos())
            {
                lista.Add(producto.MensajeParaListar());
            }
            return lista;
        }

        private Producto BuscarProducto(string modelo, string marca, int numeroDeSerie)
        {
            return PolimorfismoProductos().Find(x=>x.Identificador == $"{modelo}-{marca}-{numeroDeSerie.ToString()}") ;
        }

        private List<Producto> PolimorfismoProductos()
        {
            Productos.Clear();

            Productos.AddRange(Monitores);
            Productos.AddRange(Computadoras);

            return Productos;
        }

        private void LanzadorDeEvento(string mensaje, List<string> listado, int cantidadDeComputadoras, int cantidadDeMonitores) //Para evitar repetir codigo
        {
            if (OperacionRealizada != null)
            {
                OperacionRealizada(this, new Eventos.Evento() { Listado = listado, Mensaje=mensaje , CantidadDeComputadoras= cantidadDeComputadoras, CantidadDeMonitores=cantidadDeMonitores }) ;
            }
        }


    }
}