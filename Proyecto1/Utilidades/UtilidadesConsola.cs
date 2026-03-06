using Proyecto1.Modelos;
using Proyecto1.Modelos;
using System;

namespace Proyecto1.Utilidades
{
    public static class UtilidadesConsola
    {
        public static void MostrarRejillaColoreada(Rejilla rejilla, string titulo = null)
        {
            if (!string.IsNullOrEmpty(titulo))
            {
                Console.WriteLine($"\n═══ {titulo} ═══");
            }

            Console.WriteLine($"Período: {rejilla.PeriodoActual} | Sanas: {rejilla.ContarSanas()} | Contagiadas: {rejilla.ContarContagiadas()}");
            Console.WriteLine(new string('═', rejilla.Tamaño * 2 + 3));

            // Encabezados de columnas
            Console.Write("   ");
            for (int j = 0; j < rejilla.Tamaño && j < 10; j++)
            {
                Console.Write($"{j} ");
            }
            if (rejilla.Tamaño > 10) Console.Write("...");
            Console.WriteLine();

            for (int i = 0; i < rejilla.Tamaño; i++)
            {
                if (i < 10) Console.Write($" {i} ");
                else if (i == 10) Console.Write("... ");
                else continue;

                for (int j = 0; j < rejilla.Tamaño && j < 10; j++)
                {
                    bool contagiada = rejilla.ObtenerCelda(i, j).EstaContagiada;

                    if (contagiada)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("██");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("░░");
                    }
                    Console.ResetColor();
                    Console.Write(" ");
                }
                if (rejilla.Tamaño > 10) Console.Write("...");
                Console.WriteLine();
            }

            if (rejilla.Tamaño > 10)
            {
                Console.WriteLine("... (rejilla truncada para visualización)");
            }

            Console.ResetColor();
        }

        public static void MostrarMensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ {mensaje}");
            Console.ResetColor();
        }

        public static void MostrarMensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ {mensaje}");
            Console.ResetColor();
        }

        public static void MostrarMensajeAdvertencia(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"⚠ {mensaje}");
            Console.ResetColor();
        }

        public static void MostrarMensajeInfo(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ℹ {mensaje}");
            Console.ResetColor();
        }

        public static void EsperarTecla(string mensaje = "Presione cualquier tecla para continuar...")
        {
            Console.WriteLine($"\n{mensaje}");
            Console.ReadKey(true);
        }

        public static void LimpiarPantalla()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     SISTEMA DE ANÁLISIS EPIDEMIOLÓGICO - FASES 2-3       ║");
            Console.WriteLine("║     Laboratorio de Investigación - Guatemala             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
        }

        public static int LeerEntero(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int valor) && valor >= min && valor <= max)
                {
                    return valor;
                }

                MostrarMensajeError($"Por favor ingrese un número entero entre {min} y {max}");
            }
        }

        public static string LeerTexto(string prompt, bool requerido = true)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (!requerido || !string.IsNullOrEmpty(input))
                {
                    return input;
                }

                MostrarMensajeError("Este campo es obligatorio");
            }
        }
    }
}