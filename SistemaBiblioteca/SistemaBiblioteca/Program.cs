using System;
using System.Collections.Generic;
using SistemaBiblioteca.Clases;

namespace SistemaBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.AnimacionCarga();

            List<MaterialBiblioteca> materiales = new List<MaterialBiblioteca>();
            bool continuar = true;

            while (continuar)
            {
                Menu.MostrarMenu();
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                continuar = Menu.Ejecutar(opcion, materiales);
            }
        }
    }
}