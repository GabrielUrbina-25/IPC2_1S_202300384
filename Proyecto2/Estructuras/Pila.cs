using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Estructuras
{
    public class Pila
    {
        private Nodo tope;
        private int contador;

        public Pila()
        {
            tope = null;
            contador = 0;
        }

        public int Count => contador;
        public bool IsEmpty => tope == null;

        public void Push(object dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = tope;
            tope = nuevo;
            contador++;
        }

        public object Pop()
        {
            if (tope == null)
                throw new InvalidOperationException("Pila vacía");

            object dato = tope.Dato;
            tope = tope.Siguiente;
            contador--;
            return dato;
        }

        public object Peek()
        {
            if (tope == null)
                throw new InvalidOperationException("Pila vacía");
            return tope.Dato;
        }

        public void Recorrer(Action<object> accion)
        {
            Nodo actual = tope;
            while (actual != null)
            {
                accion(actual.Dato);
                actual = actual.Siguiente;
            }
        }
    }
}
