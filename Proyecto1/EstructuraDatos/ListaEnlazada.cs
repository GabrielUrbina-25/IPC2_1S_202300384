using Proyecto1.EstructurasDatos;
using System;

namespace Proyecto1.EstructurasDatos
{
    public class ListaEnlazada<T>
    {
        private Nodo<T> cabeza;
        private int contador;

        public ListaEnlazada()
        {
            this.cabeza = null;
            this.contador = 0;
        }

        // Agregar al final - O(n)
        public void Agregar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo<T> actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
            contador++;
        }

        // Obtener por índice - O(n)
        public T Obtener(int indice)
        {
            if (indice < 0 || indice >= contador)
                throw new IndexOutOfRangeException("Índice fuera de rango");

            Nodo<T> actual = cabeza;
            for (int i = 0; i < indice; i++)
            {
                actual = actual.Siguiente;
            }
            return actual.Dato;
        }

        // Verificar si contiene elemento
        public bool Contiene(T dato)
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Equals(dato))
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        // Eliminar por índice
        public bool Eliminar(int indice)
        {
            if (indice < 0 || indice >= contador)
                return false;

            if (indice == 0)
            {
                cabeza = cabeza.Siguiente;
            }
            else
            {
                Nodo<T> actual = cabeza;
                for (int i = 0; i < indice - 1; i++)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
            contador--;
            return true;
        }

        // Limpiar lista
        public void Limpiar()
        {
            cabeza = null;
            contador = 0;
        }

        // Getters
        public int Count => contador;
        public bool EstaVacia => cabeza == null;
        public Nodo<T> Cabeza => cabeza;

        // Para iteración
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                yield return actual.Dato;
                actual = actual.Siguiente;
            }
        }
    }
}