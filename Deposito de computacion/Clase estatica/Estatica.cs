namespace ClaseEstatica
{
    public static class Estatica
    {
        public static bool ValidarValorBienCargado(this int cantidadDeRam)
        {
            return cantidadDeRam == 2 || cantidadDeRam == 4 || cantidadDeRam == 8 || cantidadDeRam == 16;
        }
    }
}