using Proyecto1.EstructurasDatos;

namespace Proyecto1.EstructurasDatos
{
    public class Cola<T>
    {
        private Nodo<T> frente;
        private Nodo<T> final;
        private int contador;

        public Cola()
        {
            this.frente = null;
            this.final = null;
            this.contador = 0;
        }

        // Encolar - O(1)
        public void Encolar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (final == null)
            {
                frente = final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
            contador++;
        }

        // Desencolar - O(1)
        public T Desencolar()
        {
            if (frente == null)
                throw new System.InvalidOperationException("Cola vacía");

            T dato = frente.Dato;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            contador--;
            return dato;
        }

        // Ver frente sin remover
        public T Peek()
        {
            if (frente == null)
                throw new System.InvalidOperationException("Cola vacía");
            return frente.Dato;
        }

        public bool EstaVacia => frente == null;
        public int Count => contador;
    }
}