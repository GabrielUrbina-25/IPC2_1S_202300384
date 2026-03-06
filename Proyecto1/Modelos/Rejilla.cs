using Proyecto1.EstructurasDatos;

namespace Proyecto1.Modelos
{
    public class Rejilla
    {
        public int Tamaño { get; set; } // M x M
        public ListaEnlazada<ListaEnlazada<Celda>> Celdas { get; set; }
        public int PeriodoActual { get; set; }

        public Rejilla(int tamaño)
        {
            this.Tamaño = tamaño;
            this.Celdas = new ListaEnlazada<ListaEnlazada<Celda>>();
            this.PeriodoActual = 0;
            InicializarCeldas();
        }

        private void InicializarCeldas()
        {
            for (int i = 0; i < Tamaño; i++)
            {
                ListaEnlazada<Celda> fila = new ListaEnlazada<Celda>();
                for (int j = 0; j < Tamaño; j++)
                {
                    fila.Agregar(new Celda(i, j, false)); // Inicialmente sanas
                }
                Celdas.Agregar(fila);
            }
        }

        // Obtener celda específica
        public Celda ObtenerCelda(int fila, int columna)
        {
            if (fila < 0 || fila >= Tamaño || columna < 0 || columna >= Tamaño)
                return null;

            ListaEnlazada<Celda> filaLista = Celdas.Obtener(fila);
            return filaLista.Obtener(columna);
        }

        // Establecer estado de celda
        public void EstablecerCelda(int fila, int columna, bool contagiada)
        {
            Celda celda = ObtenerCelda(fila, columna);
            if (celda != null)
                celda.EstaContagiada = contagiada;
        }

        // Contar celdas contagiadas
        public int ContarContagiadas()
        {
            int contador = 0;
            for (int i = 0; i < Tamaño; i++)
            {
                var fila = Celdas.Obtener(i);
                for (int j = 0; j < Tamaño; j++)
                {
                    if (fila.Obtener(j).EstaContagiada)
                        contador++;
                }
            }
            return contador;
        }

        // Contar celdas sanas
        public int ContarSanas()
        {
            return (Tamaño * Tamaño) - ContarContagiadas();
        }

        // Convertir a string para comparación de patrones
        public string ObtenerPatron()
        {
            string patron = "";
            for (int i = 0; i < Tamaño; i++)
            {
                var fila = Celdas.Obtener(i);
                for (int j = 0; j < Tamaño; j++)
                {
                    patron += fila.Obtener(j).EstaContagiada ? "1" : "0";
                }
            }
            return patron;
        }
        public Rejilla Clonar()
        {
            Rejilla clon = new Rejilla(this.Tamaño);
            clon.PeriodoActual = this.PeriodoActual;

            for (int i = 0; i < Tamaño; i++)
            {
                for (int j = 0; j < Tamaño; j++)
                {
                    clon.EstablecerCelda(i, j, this.ObtenerCelda(i, j).EstaContagiada);
                }
            }

            return clon;
        }
    }

}