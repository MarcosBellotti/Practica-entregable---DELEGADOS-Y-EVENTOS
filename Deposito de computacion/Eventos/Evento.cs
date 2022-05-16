namespace Eventos
{
    public class Evento : EventArgs
    {
        public List<string> Listado { get; set; }
        public string Mensaje { get; set; }
        public int CantidadDeComputadoras { get; set; }
        public int CantidadDeMonitores { get; set; }

    }
}