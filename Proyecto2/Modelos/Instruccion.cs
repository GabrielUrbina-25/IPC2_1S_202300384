using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Modelos
{
    public class Instruccion
    {
        public string NombreDron { get; set; }
        public int Altura { get; set; }

        public Instruccion(string dron, int altura)
        {
            NombreDron = dron;
            Altura = altura;
        }
    }
}
