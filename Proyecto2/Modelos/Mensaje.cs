using Proyecto2.Estructuras;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Modelos
{
    public class Mensaje
    {
        public string Nombre { get; set; }
        public string NombreSistemaDrones { get; set; }
        public ListaSimple Instrucciones { get; set; }

        public Mensaje()
        {
            Instrucciones = new ListaSimple();
        }
    }
}
