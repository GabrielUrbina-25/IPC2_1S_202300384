using System;
using System.IO;
using System.Xml;
using Proyecto1.Modelos;
using Proyecto1.EstructurasDatos;

namespace Proyecto1.Servicios
{
    public class XmlParser
    {
        // Cargar pacientes desde archivo XML
        public ListaEnlazada<Paciente> CargarPacientes(string rutaArchivo)
        {
            ListaEnlazada<Paciente> pacientes = new ListaEnlazada<Paciente>();

            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException($"No se encontró el archivo: {rutaArchivo}");

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaArchivo);

                XmlNodeList nodosPacientes = doc.GetElementsByTagName("paciente");

                foreach (XmlNode nodoPaciente in nodosPacientes)
                {
                    Paciente paciente = ProcesarNodoPaciente(nodoPaciente);
                    if (paciente != null)
                    {
                        pacientes.Agregar(paciente);
                        Console.WriteLine($"✓ Paciente cargado: {paciente.Nombre}");
                    }
                }

                Console.WriteLine($"\nTotal de pacientes cargados: {pacientes.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al parsear XML: {ex.Message}");
                throw;
            }

            return pacientes;
        }

        private Paciente ProcesarNodoPaciente(XmlNode nodoPaciente)
        {
            try
            {
                // Datos personales
                XmlNode datosPersonales = nodoPaciente.SelectSingleNode("datospersonales");
                string nombre = datosPersonales?.SelectSingleNode("nombre")?.InnerText ?? "SinNombre";
                int edad = int.Parse(datosPersonales?.SelectSingleNode("edad")?.InnerText ?? "0");

                // Periodos y tamaño
                int periodos = int.Parse(nodoPaciente.SelectSingleNode("periodos")?.InnerText ?? "0");
                int tamaño = int.Parse(nodoPaciente.SelectSingleNode("m")?.InnerText ?? "10");

                // Validar que M sea múltiplo de 10
                if (tamaño % 10 != 0 || tamaño < 10)
                {
                    Console.WriteLine($"Advertencia: Tamaño {tamaño} no válido. Debe ser múltiplo de 10 >= 10");
                    return null;
                }

                Paciente paciente = new Paciente(nombre, edad, periodos, tamaño);

                // Cargar rejilla inicial
                XmlNode rejillaNode = nodoPaciente.SelectSingleNode("rejilla");
                if (rejillaNode != null)
                {
                    CargarRejilla(paciente.RejillaInicial, rejillaNode);
                }

                return paciente;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error procesando paciente: {ex.Message}");
                return null;
            }
        }

        private void CargarRejilla(Rejilla rejilla, XmlNode rejillaNode)
        {
            // La rejilla viene como texto con 0s y 1s separados por saltos de línea
            string contenido = rejillaNode.InnerText.Trim();
            string[] lineas = contenido.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int fila = 0;
            foreach (string linea in lineas)
            {
                string lineaLimpia = linea.Trim();
                if (string.IsNullOrEmpty(lineaLimpia)) continue;

                for (int col = 0; col < lineaLimpia.Length && col < rejilla.Tamaño; col++)
                {
                    char c = lineaLimpia[col];
                    if (c == '1')
                    {
                        rejilla.EstablecerCelda(fila, col, true);
                    }
                }
                fila++;
                if (fila >= rejilla.Tamaño) break;
            }
        }

        // Método para mostrar rejilla en consola (debug)
        public void MostrarRejilla(Rejilla rejilla)
        {
            Console.WriteLine($"\n--- Rejilla {rejilla.Tamaño}x{rejilla.Tamaño} ---");
            for (int i = 0; i < rejilla.Tamaño; i++)
            {
                var fila = rejilla.Celdas.Obtener(i);
                for (int j = 0; j < rejilla.Tamaño; j++)
                {
                    Console.Write(fila.Obtener(j).EstaContagiada ? "■ " : "□ ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Celdas contagiadas: {rejilla.ContarContagiadas()}");
            Console.WriteLine($"Celdas sanas: {rejilla.ContarSanas()}");
        }
    }
}