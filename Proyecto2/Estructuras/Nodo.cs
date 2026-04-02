using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Estructuras
{
    public class Nodo
    {
        public object Dato { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }

        public Nodo(object dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
    }
}
