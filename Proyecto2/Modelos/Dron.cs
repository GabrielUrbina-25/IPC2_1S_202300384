using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Modelos
{
    public class Dron
    {
        public string Nombre { get; set; }

        public Dron(string nombre)
        {
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
