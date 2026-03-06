using Proyecto1.Modelos;
using Proyecto1.Modelos;
using Proyecto1.Servicios;
using System;
using System.Diagnostics;
using System.IO;

namespace Proyecto1.Servicios
{
    public class GraphvizGenerator
    {
        private string directorioSalida;

        public GraphvizGenerator(string directorio = "Reportes")
        {
            this.directorioSalida = directorio;
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        // Generar visualización de una rejilla específica
        public string GenerarVisualizacionRejilla(Rejilla rejilla, string nombrePaciente, int periodo)
        {
            string nombreArchivo = $"{SanitizarNombre(nombrePaciente)}_Periodo_{periodo}";
            string rutaDot = Path.Combine(directorioSalida, nombreArchivo + ".dot");
            string rutaImagen = Path.Combine(directorioSalida, nombreArchivo + ".png");

            // Generar archivo DOT
            string contenidoDot = GenerarCodigoDot(rejilla, nombrePaciente, periodo);
            File.WriteAllText(rutaDot, contenidoDot);

            // Compilar a imagen (si Graphviz está instalado)
            try
            {
                CompilarDot(rutaDot, rutaImagen);
                return rutaImagen;
            }
            catch
            {
                return rutaDot; // Retornar ruta del DOT si no se puede compilar
            }
        }

        // Generar grafo del historial de patrones
        public string GenerarGrafoHistorial(Paciente paciente, DetectorPatrones detector)
        {
            string nombreArchivo = $"{SanitizarNombre(paciente.Nombre)}_Historial";
            string rutaDot = Path.Combine(directorioSalida, nombreArchivo + ".dot");

            var historial = detector.ObtenerHistorial();
            string contenidoDot = "digraph Historial {\n";
            contenidoDot += "    rankdir=TB;\n";
            contenidoDot += "    node [shape=box, style=filled, fillcolor=lightblue];\n";
            contenidoDot += $"    label=\"Historial de Patrones - {paciente.Nombre}\";\n\n";

            // Crear nodos para cada período
            for (int i = 0; i < historial.Count; i++)
            {
                var registro = historial.Obtener(i);
                string color = i == 0 ? "green" : "lightblue";
                contenidoDot += $"    P{i} [label=\"Período {registro.Periodo}\\nContagiadas: {registro.Rejilla.ContarContagiadas()}\", fillcolor={color}];\n";
            }

            // Crear conexiones
            for (int i = 0; i < historial.Count - 1; i++)
            {
                contenidoDot += $"    P{i} -> P{i + 1};\n";
            }

            // Marcar si hay ciclo detectado
            if (paciente.Resultado != "pendiente" && paciente.Resultado != "leve")
            {
                contenidoDot += $"\n    // Ciclo detectado: N={paciente.N}, N1={paciente.N1}\n";
            }

            contenidoDot += "}";

            File.WriteAllText(rutaDot, contenidoDot);
            return rutaDot;
        }

        private string GenerarCodigoDot(Rejilla rejilla, string nombrePaciente, int periodo)
        {
            string dot = "graph Rejilla {\n";
            dot += "    layout=dot;\n";
            dot += "    rankdir=TB;\n";
            dot += "    node [shape=box, width=0.3, height=0.3, fixedsize=true];\n";
            dot += $"    label=\"{nombrePaciente} - Período {periodo}\\nSanas: {rejilla.ContarSanas()}, Contagiadas: {rejilla.ContarContagiadas()}\";\n";
            dot += "    labelloc=t;\n\n";

            int tamaño = rejilla.Tamaño;

            // Crear nodos para cada celda
            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < tamaño; j++)
                {
                    string nombreNodo = $"C{i}_{j}";
                    bool contagiada = rejilla.ObtenerCelda(i, j).EstaContagiada;
                    string color = contagiada ? "red" : "white";
                    string fillcolor = contagiada ? "\"#FF4444\"" : "\"#FFFFFF\"";

                    dot += $"    {nombreNodo} [fillcolor={fillcolor}, style=filled];\n";
                }
            }

            dot += "\n    // Conexiones horizontales\n";
            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < tamaño - 1; j++)
                {
                    dot += $"    C{i}_{j} -- C{i}_{j + 1} [style=invis];\n";
                }
            }

            dot += "\n    // Conexiones verticales (invisibles para alineación)\n";
            for (int i = 0; i < tamaño - 1; i++)
            {
                for (int j = 0; j < tamaño; j++)
                {
                    dot += $"    C{i}_{j} -- C{i + 1}_{j} [style=invis];\n";
                }
            }

            // Agrupar por filas usando rank
            for (int i = 0; i < tamaño; i++)
            {
                dot += $"\n    {{ rank=same; ";
                for (int j = 0; j < tamaño; j++)
                {
                    dot += $"C{i}_{j}; ";
                }
                dot += "}";
            }

            dot += "\n}";
            return dot;
        }

        private void CompilarDot(string rutaDot, string rutaSalida)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "dot",
                Arguments = $"-Tpng \"{rutaDot}\" -o \"{rutaSalida}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    string error = process.StandardError.ReadToEnd();
                    throw new Exception($"Error de Graphviz: {error}");
                }
            }
        }

        private string SanitizarNombre(string nombre)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                nombre = nombre.Replace(c, '_');
            }
            return nombre.Replace(" ", "_");
        }

        public string ObtenerDirectorio()
        {
            return Path.GetFullPath(directorioSalida);
        }
    }
}