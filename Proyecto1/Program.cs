using System;
using Proyecto1.EstructurasDatos;
using Proyecto1.Modelos;
using Proyecto1.Servicios;

namespace Proyecto1
{
    class Program
    {
        static ListaEnlazada<Paciente> pacientesCargados = new ListaEnlazada<Paciente>();
        static XmlParser parser = new XmlParser();

        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     SISTEMA DE ANÁLISIS EPIDEMIOLÓGICO - FASE 1          ║");
            Console.WriteLine("║     Laboratorio de Investigación - Guatemala             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CargarArchivoXML();
                        break;
                    case "2":
                        VerPacientesCargados();
                        break;
                    case "3":
                        VerDetallePaciente();
                        break;
                    case "4":
                        LimpiarMemoria();
                        break;
                    case "5":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n========== MENÚ PRINCIPAL - FASE 1 ==========");
            Console.WriteLine("1. Cargar archivo XML de pacientes");
            Console.WriteLine("2. Ver pacientes cargados");
            Console.WriteLine("3. Ver detalle de paciente (rejilla)");
            Console.WriteLine("4. Limpiar memoria");
            Console.WriteLine("5. Salir");
            Console.WriteLine("=============================================");
            Console.Write("Seleccione una opción: ");
        }

        static void CargarArchivoXML()
        {
            Console.Write("\nIngrese la ruta del archivo XML: ");
            string ruta = Console.ReadLine();

            try
            {
                // Limpiar antes de cargar nuevos
                pacientesCargados.Limpiar();

                pacientesCargados = parser.CargarPacientes(ruta);
                Console.WriteLine("\n✓ Archivo cargado exitosamente!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void VerPacientesCargados()
        {
            if (pacientesCargados.EstaVacia)
            {
                Console.WriteLine("\nNo hay pacientes cargados.");
            }
            else
            {
                Console.WriteLine("\n--- PACIENTES CARGADOS ---");
                int index = 1;
                foreach (var paciente in pacientesCargados)
                {
                    Console.WriteLine($"{index}. {paciente}");
                    index++;
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void VerDetallePaciente()
        {
            if (pacientesCargados.EstaVacia)
            {
                Console.WriteLine("\nNo hay pacientes cargados.");
                Console.ReadKey();
                return;
            }

            Console.Write("\nIngrese el número del paciente: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= pacientesCargados.Count)
            {
                Paciente p = pacientesCargados.Obtener(num - 1);
                Console.WriteLine($"\n=== DETALLE DE: {p.Nombre} ===");
                Console.WriteLine($"Edad: {p.Edad}");
                Console.WriteLine($"Periodos a evaluar: {p.PeriodosEvaluar}");
                Console.WriteLine($"Tamaño de rejilla: {p.TamañoRejilla}x{p.TamañoRejilla}");

                parser.MostrarRejilla(p.RejillaInicial);
            }
            else
            {
                Console.WriteLine("Número de paciente inválido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void LimpiarMemoria()
        {
            pacientesCargados.Limpiar();
            Console.WriteLine("\n✓ Memoria limpiada. Todos los pacientes han sido eliminados.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}