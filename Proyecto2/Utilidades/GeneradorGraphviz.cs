using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Proyecto2.Utilidades
{
    public static class GeneradorGraphviz
    {
        private static string rutaGraphviz = "dot"; // Asume que dot está en PATH

        // Generar gráfica de un Sistema de Drones (la matriz)
        public static string GenerarGraficaSistema(SistemaDrones sistema, string rutaSalida)
        {
            StringBuilder dot = new StringBuilder();
            dot.AppendLine("digraph SistemaDrones {");
            dot.AppendLine("    node [shape=none, margin=0];");
            dot.AppendLine("    rankdir=TB;");
            dot.AppendLine("    label=\"" + sistema.Nombre + "\";");
            dot.AppendLine("    labelloc=t;");
            dot.AppendLine("    fontsize=20;");
            dot.AppendLine("    fontcolor=blue;");
            dot.AppendLine("");

            // Crear tabla HTML
            dot.AppendLine("    tabla [label=<");
            dot.AppendLine("        <TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"5\">");

            // Header
            dot.AppendLine("            <TR>");
            dot.AppendLine("                <TD BGCOLOR=\"lightblue\">Altura\\Dron</TD>");

            // Nombres de drones en header
            for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
            {
                DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                dot.AppendLine("                <TD BGCOLOR=\"lightblue\">" + dc.NombreDron + "</TD>");
            }
            dot.AppendLine("            </TR>");

            // Filas por altura (de mayor a menor)
            for (int altura = sistema.AlturaMaxima; altura >= 1; altura--)
            {
                dot.AppendLine("            <TR>");
                dot.AppendLine("                <TD BGCOLOR=\"lightyellow\">" + altura + "</TD>");

                for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
                {
                    DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                    string letra = ObtenerLetraEnAltura(dc, altura);

                    // Si es espacio en blanco, mostrarlo diferente
                    if (string.IsNullOrWhiteSpace(letra))
                        letra = "ESP";

                    dot.AppendLine("                <TD>" + letra + "</TD>");
                }
                dot.AppendLine("            </TR>");
            }

            dot.AppendLine("        </TABLE>");
            dot.AppendLine("    >];");
            dot.AppendLine("}");

            // Guardar archivo .dot
            string rutaDot = Path.Combine(rutaSalida, sistema.Nombre + ".dot");
            File.WriteAllText(rutaDot, dot.ToString());

            // Generar PNG
            string rutaPng = Path.Combine(rutaSalida, sistema.Nombre + ".png");
            EjecutarGraphviz(rutaDot, rutaPng);

            return rutaPng;
        }

        // Generar gráfica de instrucciones de mensaje (timeline)
        public static string GenerarGraficaInstrucciones(Mensaje mensaje, ListaSimple instruccionesOptimizadas,
            string sistemaNombre, string rutaSalida)
        {
            StringBuilder dot = new StringBuilder();
            dot.AppendLine("digraph Instrucciones {");
            dot.AppendLine("    rankdir=LR;");
            dot.AppendLine("    node [shape=box, style=filled];");
            dot.AppendLine("    label=\"Instrucciones: " + mensaje.Nombre + "\";");
            dot.AppendLine("");

            // Aquí iría la lógica para mostrar el timeline de instrucciones
            // Por ahora, mostramos lista simple
            int tiempo = 1;

            dot.AppendLine("    // Instrucciones");
            for (int i = 0; i < instruccionesOptimizadas.Count; i++)
            {
                Instruccion inst = (Instruccion)instruccionesOptimizadas.Obtener(i);
                dot.AppendLine("    t" + tiempo + " [label=\"T" + tiempo + "\\n" +
                    inst.NombreDron + "\\nAlt: " + inst.Altura + "\", fillcolor=lightgreen];");

                if (tiempo > 1)
                {
                    dot.AppendLine("    t" + (tiempo - 1) + " -> t" + tiempo + ";");
                }
                tiempo++;
            }

            dot.AppendLine("}");

            string rutaDot = Path.Combine(rutaSalida, "instrucciones_" + mensaje.Nombre + ".dot");
            File.WriteAllText(rutaDot, dot.ToString());

            string rutaPng = Path.Combine(rutaSalida, "instrucciones_" + mensaje.Nombre + ".png");
            EjecutarGraphviz(rutaDot, rutaPng);

            return rutaPng;
        }

        private static string ObtenerLetraEnAltura(DronConfiguracion dc, int altura)
        {
            for (int i = 0; i < dc.Alturas.Count; i++)
            {
                Altura a = (Altura)dc.Alturas.Obtener(i);
                if (a.Valor == altura)
                    return a.Letra;
            }
            return "-";
        }

        private static void EjecutarGraphviz(string rutaDot, string rutaPng)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = rutaGraphviz;
                psi.Arguments = string.Format("-Tpng \"{0}\" -o \"{1}\"", rutaDot, rutaPng);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.CreateNoWindow = true;

                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        string error = process.StandardError.ReadToEnd();
                        throw new Exception("Error al ejecutar Graphviz: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo generar la imagen. Verifique que Graphviz esté instalado y en el PATH del sistema. Error: " + ex.Message);
            }
        }

        public static void ConfigurarRutaGraphviz(string ruta)
        {
            rutaGraphviz = ruta;
        }
    }
}
