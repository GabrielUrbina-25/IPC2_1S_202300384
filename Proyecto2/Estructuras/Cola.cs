using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Estructuras
{
    public class Cola
    {
        private Nodo frente;
        private Nodo final;
        private int contador;

        public Cola()
        {
            frente = null;
            final = null;
            contador = 0;
        }

        public int Count => contador;
        public bool IsEmpty => frente == null;

        public void Encolar(object dato)
        {
            Nodo nuevo = new Nodo(dato);

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

        public object Desencolar()
        {
            if (frente == null)
                throw new InvalidOperationException("Cola vacía");

            object dato = frente.Dato;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            contador--;
            return dato;
        }

        public object Peek()
        {
            if (frente == null)
                throw new InvalidOperationException("Cola vacía");
            return frente.Dato;
        }

        public void Recorrer(Action<object> accion)
        {
            Nodo actual = frente;
            while (actual != null)
            {
                accion(actual.Dato);
                actual = actual.Siguiente;
            }
        }
    }
}
