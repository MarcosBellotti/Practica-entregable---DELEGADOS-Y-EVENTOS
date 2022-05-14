using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalla : Producto
    {
        public int AñoDeFabricacion { get; set; }
        public bool EsNuevo { get; private set; }
        public int? Pulgadas { get; set; }

        public Pantalla() { }
        public Pantalla(string modelo, string marca, int numeroDeSerie, int añoDeFabricacion, int pulgadas)
        {
            Modelo = modelo;
            Marca = marca;
            NroDeSerie = numeroDeSerie;

            AñoDeFabricacion = añoDeFabricacion;
            EsNuevo = AñoDeFabricacion == DateTime.Now.Year;
            Pulgadas = pulgadas==0? null: pulgadas;
        }

        public override string MensajeParaListar()
        {
            return Pulgadas.HasValue == true? $"MONITOR {Marca} - {Modelo} - {Pulgadas.Value}": $"MONITOR {Marca} - {Modelo}";
        }
    }   
}
