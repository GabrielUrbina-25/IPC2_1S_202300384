using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Estructuras
{
    public class ListaDoble
    {
        private Nodo cabeza;
        private Nodo cola;
        private int contador;

        public ListaDoble()
        {
            cabeza = null;
            cola = null;
            contador = 0;
        }

        public int Count => contador;
        public Nodo Cabeza => cabeza;
        public Nodo Cola => cola;

        public void AgregarAlFinal(object dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = cola = nuevo;
            }
            else
            {
                nuevo.Anterior = cola;
                cola.Siguiente = nuevo;
                cola = nuevo;
            }
            contador++;
        }

        public void AgregarAlInicio(object dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = cola = nuevo;
            }
            else
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            contador++;
        }

        public void Recorrer(Action<object> accion)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                accion(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        public object[] ToArray()
        {
            object[] array = new object[contador];
            Nodo actual = cabeza;
            int i = 0;
            while (actual != null)
            {
                array[i++] = actual.Dato;
                actual = actual.Siguiente;
            }
            return array;
        }
    }
}
