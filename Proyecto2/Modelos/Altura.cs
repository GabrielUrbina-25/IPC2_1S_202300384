using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Modelos
{
    public class Altura
    {
        public int Valor { get; set; }
        public string Letra { get; set; }

        public Altura(int valor, string letra)
        {
            Valor = valor;
            Letra = letra;
        }
    }
}
