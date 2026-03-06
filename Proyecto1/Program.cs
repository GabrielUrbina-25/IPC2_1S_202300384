using System;
using System.IO;
using Proyecto1.EstructurasDatos;
using Proyecto1.Modelos;
using Proyecto1.Servicios;
using Proyecto1.Utilidades;

namespace Proyecto1
{
    class Program
    {
        static ListaEnlazada<Paciente> pacientesCargados = new ListaEnlazada<Paciente>();
        static XmlParser parser = new XmlParser();
        static SimuladorEpidemico simulador = new SimuladorEpidemico();
        static DetectorPatrones detector = new DetectorPatrones();
        static GraphvizGenerator graphviz = new GraphvizGenerator();
        static GeneradorXmlSalida generadorSalida = new GeneradorXmlSalida();

        static void Main(string[] args)
        {
            UtilidadesConsola.LimpiarPantalla();

            bool salir = false;
            while (!salir)
            {
                MostrarMenuPrincipal();
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
                        SimularPeriodoPorPeriodo();
                        break;
                    case "4":
                        EjecutarSimulacionCompleta();
                        break;
                    case "5":
                        GenerarReportes();
                        break;
                    case "6":
                        LimpiarMemoria();
                        break;
                    case "7":
                        salir = true;
                        Console.WriteLine("\nGracias por usar el Sistema de Análisis Epidemiológico");
                        break;
                    default:
                        UtilidadesConsola.MostrarMensajeError("Opción no válida");
                        UtilidadesConsola.EsperarTecla();
                        break;
                }
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("\n╔═══════════ MENÚ PRINCIPAL ═══════════╗");
            Console.WriteLine("║ 1. Cargar archivo XML de pacientes   ║");
            Console.WriteLine("║ 2. Ver pacientes cargados            ║");
            Console.WriteLine("║ 3. Simular período por período       ║");
            Console.WriteLine("║ 4. Ejecutar simulación completa      ║");
            Console.WriteLine("║ 5. Generar reportes (XML/Graphviz)   ║");
            Console.WriteLine("║ 6. Limpiar memoria                   ║");
            Console.WriteLine("║ 7. Salir                             ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("Seleccione una opción: ");
        }

        static void CargarArchivoXML()
        {
            Console.Write("\nIngrese la ruta del archivo XML: ");
            string ruta = Console.ReadLine();

            if (!File.Exists(ruta))
            {
                UtilidadesConsola.MostrarMensajeError("El archivo no existe");
                UtilidadesConsola.EsperarTecla();
                return;
            }

            try
            {
                pacientesCargados.Limpiar();
                pacientesCargados = parser.CargarPacientes(ruta);
                UtilidadesConsola.MostrarMensajeExito($"Se cargaron {pacientesCargados.Count} pacientes");
            }
            catch (Exception ex)
            {
                UtilidadesConsola.MostrarMensajeError($"Error al cargar: {ex.Message}");
            }

            UtilidadesConsola.EsperarTecla();
        }

        static void VerPacientesCargados()
        {
            if (pacientesCargados.EstaVacia)
            {
                UtilidadesConsola.MostrarMensajeAdvertencia("No hay pacientes cargados");
                UtilidadesConsola.EsperarTecla();
                return;
            }

            Console.WriteLine("\n--- PACIENTES CARGADOS ---");
            int index = 1;
            foreach (var paciente in pacientesCargados)
            {
                string estado = paciente.Resultado != "pendiente" ? $"[{paciente.Resultado.ToUpper()}]" : "[PENDIENTE]";
                Console.WriteLine($"{index}. {paciente.Nombre} {estado}");
                index++;
            }

            UtilidadesConsola.EsperarTecla();
        }

        static void SimularPeriodoPorPeriodo()
        {
            if (pacientesCargados.EstaVacia)
            {
                UtilidadesConsola.MostrarMensajeAdvertencia("No hay pacientes cargados");
                UtilidadesConsola.EsperarTecla();
                return;
            }

            Paciente paciente = SeleccionarPaciente();
            if (paciente == null) return;

            // Reiniciar simulación
            paciente.RejillaActual = null;
            detector.Inicializar(paciente.RejillaInicial);

            bool simulando = true;
            while (simulando)
            {
                UtilidadesConsola.LimpiarPantalla();
                Console.WriteLine($"Paciente: {paciente.Nombre}");
                Console.WriteLine($"Períodos máximos a evaluar: {paciente.PeriodosEvaluar}");
                Console.WriteLine();

                // Avanzar un período
                Rejilla nuevaRejilla = simulador.AvanzarPeriodo(paciente);

                // Mostrar estado actual
                UtilidadesConsola.MostrarRejillaColoreada(nuevaRejilla, $"REJILLA ACTUAL");

                // Verificar si hay patrón repetido
                var resultado = detector.AnalizarPeriodo(nuevaRejilla, nuevaRejilla.PeriodoActual);

                if (resultado != null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = resultado.Tipo == "mortal" ? ConsoleColor.Red : ConsoleColor.Yellow;
                    Console.WriteLine($"╔════════════════════════════════════╗");
                    Console.WriteLine($"║  {resultado.Mensaje,-34} ║");
                    Console.WriteLine($"╚════════════════════════════════════╝");
                    Console.ResetColor();

                    // Guardar resultado en paciente
                    paciente.Resultado = resultado.Tipo;
                    paciente.N = resultado.N;
                    paciente.N1 = resultado.N1;

                    UtilidadesConsola.EsperarTecla();
                    break;
                }

                // Verificar límite de períodos
                if (nuevaRejilla.PeriodoActual >= paciente.PeriodosEvaluar)
                {
                    Console.WriteLine();
                    var resultadoLeve = detector.ClasificarSinRepeticion(nuevaRejilla.PeriodoActual);
                    paciente.Resultado = resultadoLeve.Tipo;

                    UtilidadesConsola.MostrarMensajeInfo(resultadoLeve.Mensaje);
                    UtilidadesConsola.EsperarTecla();
                    break;
                }

                // Preguntar si continuar
                Console.WriteLine("\n1. Siguiente período");
                Console.WriteLine("2. Generar visualización actual");
                Console.WriteLine("3. Terminar simulación manual");
                Console.Write("Opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "2":
                        string ruta = graphviz.GenerarVisualizacionRejilla(nuevaRejilla, paciente.Nombre, nuevaRejilla.PeriodoActual);
                        UtilidadesConsola.MostrarMensajeExito($"Visualización guardada en: {ruta}");
                        UtilidadesConsola.EsperarTecla();
                        break;
                    case "3":
                        simulando = false;
                        break;
                }
            }
        }

        static void EjecutarSimulacionCompleta()
        {
            if (pacientesCargados.EstaVacia)
            {
                UtilidadesConsola.MostrarMensajeAdvertencia("No hay pacientes cargados");
                UtilidadesConsola.EsperarTecla();
                return;
            }

            Paciente paciente = SeleccionarPaciente();
            if (paciente == null) return;

            Console.WriteLine($"\nEjecutando simulación completa para {paciente.Nombre}...");
            Console.WriteLine($"Límite de períodos: {paciente.PeriodosEvaluar}");

            // Reiniciar
            paciente.RejillaActual = null;
            detector.Inicializar(paciente.RejillaInicial);

            bool finalizado = false;
            int ultimoPeriodo = 0;

            while (!finalizado)
            {
                Rejilla nuevaRejilla = simulador.AvanzarPeriodo(paciente);
                ultimoPeriodo = nuevaRejilla.PeriodoActual;

                // Mostrar progreso cada 10 períodos
                if (ultimoPeriodo % 10 == 0)
                {
                    Console.Write($"\rPeríodo: {ultimoPeriodo} - Contagiadas: {nuevaRejilla.ContarContagiadas()}    ");
                }

                // Verificar repetición
                var resultado = detector.AnalizarPeriodo(nuevaRejilla, ultimoPeriodo);
                if (resultado != null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = resultado.Tipo == "mortal" ? ConsoleColor.Red : ConsoleColor.Yellow;
                    Console.WriteLine($"\n>>> {resultado.Mensaje}");
                    Console.ResetColor();

                    paciente.Resultado = resultado.Tipo;
                    paciente.N = resultado.N;
                    paciente.N1 = resultado.N1;
                    finalizado = true;
                }
                else if (ultimoPeriodo >= paciente.PeriodosEvaluar)
                {
                    Console.WriteLine();
                    var resultadoLeve = detector.ClasificarSinRepeticion(ultimoPeriodo);
                    paciente.Resultado = resultadoLeve.Tipo;

                    UtilidadesConsola.MostrarMensajeInfo(resultadoLeve.Mensaje);
                    finalizado = true;
                }
            }

            // Generar visualizaciones automáticas
            Console.WriteLine("\nGenerando visualizaciones...");
            string rutaRejilla = graphviz.GenerarVisualizacionRejilla(paciente.RejillaActual, paciente.Nombre, ultimoPeriodo);
            string rutaHistorial = graphviz.GenerarGrafoHistorial(paciente, detector);

            UtilidadesConsola.MostrarMensajeExito($"Rejilla final: {rutaRejilla}");
            UtilidadesConsola.MostrarMensajeExito($"Historial: {rutaHistorial}");

            UtilidadesConsola.EsperarTecla();
        }

        static void GenerarReportes()
        {
            if (pacientesCargados.EstaVacia)
            {
                UtilidadesConsola.MostrarMensajeAdvertencia("No hay pacientes cargados");
                UtilidadesConsola.EsperarTecla();
                return;
            }

            Console.WriteLine("\n--- GENERACIÓN DE REPORTES ---");
            Console.WriteLine("1. Generar XML de salida");
            Console.WriteLine("2. Generar reporte de texto");
            Console.WriteLine("3. Generar todas las visualizaciones Graphviz");
            Console.WriteLine("4. Ver directorio de reportes");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        string rutaXml = Path.Combine(graphviz.ObtenerDirectorio(), "resultados.xml");
                        generadorSalida.GenerarXml(pacientesCargados, rutaXml);
                        UtilidadesConsola.MostrarMensajeExito($"XML generado: {rutaXml}");
                        break;

                    case "2":
                        string rutaTxt = Path.Combine(graphviz.ObtenerDirectorio(), "reporte.txt");
                        generadorSalida.GenerarReporteTexto(pacientesCargados, rutaTxt);
                        UtilidadesConsola.MostrarMensajeExito($"Reporte generado: {rutaTxt}");
                        break;

                    case "3":
                        int count = 0;
                        foreach (var paciente in pacientesCargados)
                        {
                            if (paciente.RejillaActual != null)
                            {
                                graphviz.GenerarVisualizacionRejilla(paciente.RejillaActual, paciente.Nombre, paciente.RejillaActual.PeriodoActual);
                                count++;
                            }
                        }
                        UtilidadesConsola.MostrarMensajeExito($"Se generaron {count} visualizaciones en: {graphviz.ObtenerDirectorio()}");
                        break;

                    case "4":
                        System.Diagnostics.Process.Start("explorer.exe", graphviz.ObtenerDirectorio());
                        break;

                    default:
                        UtilidadesConsola.MostrarMensajeError("Opción inválida");
                        return;
                }
            }
            catch (Exception ex)
            {
                UtilidadesConsola.MostrarMensajeError($"Error: {ex.Message}");
            }

            UtilidadesConsola.EsperarTecla();
        }

        static Paciente SeleccionarPaciente()
        {
            Console.WriteLine("\n--- SELECCIONAR PACIENTE ---");
            int index = 1;
            foreach (var paciente in pacientesCargados)
            {
                Console.WriteLine($"{index}. {paciente.Nombre}");
                index++;
            }

            int seleccion = UtilidadesConsola.LeerEntero("Número de paciente: ", 1, pacientesCargados.Count);
            return pacientesCargados.Obtener(seleccion - 1);
        }

        static void LimpiarMemoria()
        {
            pacientesCargados.Limpiar();
            UtilidadesConsola.MostrarMensajeExito("Memoria limpiada correctamente");
            UtilidadesConsola.EsperarTecla();
        }
    }
}