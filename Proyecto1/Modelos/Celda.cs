namespace Proyecto1.Modelos
{
    public class Celda
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public bool EstaContagiada { get; set; }

        public Celda(int fila, int columna, bool contagiada)
        {
            this.Fila = fila;
            this.Columna = columna;
            this.EstaContagiada = contagiada;
        }

        public override string ToString()
        {
            return EstaContagiada ? "1" : "0";
        }

        // Para comparación de patrones
        public override bool Equals(object obj)
        {
            if (obj is Celda otra)
            {
                return Fila == otra.Fila &&
                       Columna == otra.Columna &&
                       EstaContagiada == otra.EstaContagiada;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Fila, Columna, EstaContagiada).GetHashCode();
        }
    }
}