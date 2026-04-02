using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Estructuras
{
    public class ListaSimple
    {
        private Nodo cabeza;
        private int contador;

        public ListaSimple()
        {
            cabeza = null;
            contador = 0;
        }

        public int Count => contador;
        public bool IsEmpty => cabeza == null;
        public Nodo Cabeza => cabeza;

        // Agregar al final
        public void Agregar(object dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
            contador++;
        }

        // Agregar ordenado alfabéticamente (solo para Dron)
        public void AgregarOrdenado(object dato)
        {
            if (!(dato is Dron))
                throw new ArgumentException("Solo se permiten objetos Dron");

            Dron nuevoDron = (Dron)dato;
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                // Comparar con la cabeza
                Dron cabezaDron = (Dron)cabeza.Dato;
                if (string.Compare(nuevoDron.Nombre, cabezaDron.Nombre, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    nuevo.Siguiente = cabeza;
                    cabeza = nuevo;
                }
                else
                {
                    Nodo actual = cabeza;
                    while (actual.Siguiente != null)
                    {
                        Dron actualDron = (Dron)actual.Siguiente.Dato;
                        if (string.Compare(nuevoDron.Nombre, actualDron.Nombre, StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            break;
                        }
                        actual = actual.Siguiente;
                    }
                    nuevo.Siguiente = actual.Siguiente;
                    actual.Siguiente = nuevo;
                }
            }
            contador++;
        }

        // Agregar ordenado para Mensaje (por nombre)
        public void AgregarOrdenadoMensaje(object dato)
        {
            if (!(dato is Mensaje))
                throw new ArgumentException("Solo se permiten objetos Mensaje");

            Mensaje nuevoMensaje = (Mensaje)dato;
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Mensaje cabezaMensaje = (Mensaje)cabeza.Dato;
                if (string.Compare(nuevoMensaje.Nombre, cabezaMensaje.Nombre, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    nuevo.Siguiente = cabeza;
                    cabeza = nuevo;
                }
                else
                {
                    Nodo actual = cabeza;
                    while (actual.Siguiente != null)
                    {
                        Mensaje actualMensaje = (Mensaje)actual.Siguiente.Dato;
                        if (string.Compare(nuevoMensaje.Nombre, actualMensaje.Nombre, StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            break;
                        }
                        actual = actual.Siguiente;
                    }
                    nuevo.Siguiente = actual.Siguiente;
                    actual.Siguiente = nuevo;
                }
            }
            contador++;
        }

        // Buscar por condición usando delegado
        public object Buscar(Predicate<object> condicion)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (condicion(actual.Dato))
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        // Verificar si existe
        public bool Existe(Predicate<object> condicion)
        {
            return Buscar(condicion) != null;
        }

        // Obtener por índice
        public object Obtener(int indice)
        {
            if (indice < 0 || indice >= contador)
                throw new IndexOutOfRangeException();

            Nodo actual = cabeza;
            for (int i = 0; i < indice; i++)
            {
                actual = actual.Siguiente;
            }
            return actual.Dato;
        }

        // Recorrer con acción
        public void Recorrer(Action<object> accion)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                accion(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        // Convertir a array para DataGridView
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

        // Eliminar por condición
        public bool Eliminar(Predicate<object> condicion)
        {
            if (cabeza == null) return false;

            if (condicion(cabeza.Dato))
            {
                cabeza = cabeza.Siguiente;
                contador--;
                return true;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (condicion(actual.Siguiente.Dato))
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    contador--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
    }
}
