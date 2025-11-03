namespace Cafetera.Domain
{
    public class Vaso
    {
        private int cantidadVasos;
        private int contenido;

        public Vaso(int cantidadVasos, int contenido)
        {
            this.cantidadVasos = cantidadVasos;
            this.contenido = contenido;
        }

        public bool HasVasos(int cantidad)
        {
            return cantidadVasos >= cantidad;
        }

        public void GiveVasos(int cantidad)
        {
            cantidadVasos -= cantidad;
        }

        public int GetCantidadVasos()
        {
            return cantidadVasos;
        }

        public int GetContenido()
        {
            return contenido;
        }

        public void SetCantidadVasos(int cantidadVasos)
        {
            this.cantidadVasos = cantidadVasos;
        }

        public void SetContenido(int contenido)
        {
            this.contenido = contenido;
        }
    }
}
