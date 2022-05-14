using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Computadora : Producto
    {
        public string DescripcionDelProcesador { get; set; }
        public string NombreDelFabricante { get; set; }
        public Enumeradores.CantidadDeRam Cantidad { get; set; }

        public Computadora() { }
        public Computadora(string modelo, string marca, int numeroDeSerie, string descripcion, string nombreDelFabricante, int cantidadDeRam) 
        {
            Modelo = modelo;
            Marca = marca;
            NroDeSerie = numeroDeSerie;

            DescripcionDelProcesador = descripcion;
            NombreDelFabricante= nombreDelFabricante;
            Cantidad = (Enumeradores.CantidadDeRam)cantidadDeRam;
        }

        public override string MensajeParaListar()
        {
            return $"PC {Modelo} - {Marca} - {DescripcionDelProcesador} - {Cantidad.ToString()} - {NombreDelFabricante}";
        }
    }
}
