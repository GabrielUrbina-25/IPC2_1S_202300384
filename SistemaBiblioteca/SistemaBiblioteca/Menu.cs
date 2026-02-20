using System;
using System.Collections.Generic;
using System.Threading;
using SistemaBiblioteca.Clases;

namespace SistemaBiblioteca
{
    public class Menu
    {
        public static void AnimacionCarga()
        {
            Console.WriteLine("Iniciando Sistema de Biblioteca...\n");
            Console.Write("Cargando\n");

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Console.WriteLine("Carga completa!");
            Thread.Sleep(1000);
        }

        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("              SISTEMA DE BIBLIOTECA");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Registrar Libro Físico");
            Console.WriteLine("2. Registrar Libro Digital");
            Console.WriteLine("3. Prestar Material");
            Console.WriteLine("4. Devolver Material");
            Console.WriteLine("5. Mostrar Materiales");
            Console.WriteLine("6. Salir");
        }

        public static bool Ejecutar(string opcion, List<MaterialBiblioteca> materiales)
        {
            switch (opcion)
            {
                case "1":
                    RegistrarFisico(materiales);
                    break;
                case "2":
                    RegistrarDigital(materiales);
                    break;
                case "3":
                    Prestar(materiales);
                    break;
                case "4":
                    Devolver(materiales);
                    break;
                case "5":
                    Mostrar(materiales);
                    break;
                case "6":
                    return false;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
            return true;
        }

        private static void RegistrarFisico(List<MaterialBiblioteca> materiales)
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Número de Ejemplar: ");
            string ejemplar = Console.ReadLine();

            materiales.Add(new LibroFisico(titulo, autor, ejemplar));
            Console.WriteLine("Libro físico registrado.");
        }

        private static void RegistrarDigital(List<MaterialBiblioteca> materiales)
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Tamaño (MB): ");
            string tamano = Console.ReadLine();

            materiales.Add(new LibroDigital(titulo, autor, tamano));
            Console.WriteLine("Libro digital registrado.");
        }

        private static void Prestar(List<MaterialBiblioteca> materiales)
        {
            Console.Write("Código: ");
            string codigo = Console.ReadLine();

            var material = materiales.Find(m => m.GetCodigo() == codigo);

            if (material != null)
            {
                material.Prestar();
                Console.WriteLine("Material prestado.");
            }
            else
            {
                Console.WriteLine("Material no encontrado.");
            }
        }

        private static void Devolver(List<MaterialBiblioteca> materiales)
        {
            Console.Write("Código: ");
            string codigo = Console.ReadLine();

            var material = materiales.Find(m => m.GetCodigo() == codigo);

            if (material != null)
            {
                material.Devolver();
                Console.WriteLine("Material devuelto.");
            }
            else
            {
                Console.WriteLine("Material no encontrado.");
            }
        }

        private static void Mostrar(List<MaterialBiblioteca> materiales)
        {
            foreach (var material in materiales)
            {
                material.MostrarInfo();
                Console.WriteLine("------------------------------------");
            }
        }
    }
}