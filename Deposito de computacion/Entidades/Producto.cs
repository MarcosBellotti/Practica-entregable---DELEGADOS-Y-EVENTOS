namespace Entidades
{
    public abstract class Producto
    {
        public string Identificador { get { return $"{Modelo}-{Marca}-{NroDeSerie.ToString()}"; } }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int NroDeSerie { get; set; }

        public abstract string MensajeParaListar();

    }
}