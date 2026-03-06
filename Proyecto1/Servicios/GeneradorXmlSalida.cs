using Proyecto1.EstructurasDatos;
using Proyecto1.Modelos;
using Proyecto1.EstructurasDatos;
using Proyecto1.Modelos;
using System;
using System.IO;
using System.Xml;

namespace Proyecto1.Servicios
{
    public class GeneradorXmlSalida
    {
        public void GenerarXml(ListaEnlazada<Paciente> pacientes, string rutaSalida)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = System.Text.Encoding.UTF8
            };

            using (XmlWriter writer = XmlWriter.Create(rutaSalida, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("pacientes");

                foreach (var paciente in pacientes)
                {
                    EscribirPaciente(writer, paciente);
                }

                writer.WriteEndElement(); // pacientes
                writer.WriteEndDocument();
            }
        }

        private void EscribirPaciente(XmlWriter writer, Paciente paciente)
        {
            writer.WriteStartElement("paciente");

            // Datos personales
            writer.WriteStartElement("datospersonales");
            writer.WriteElementString("nombre", paciente.Nombre);
            writer.WriteElementString("edad", paciente.Edad.ToString());
            writer.WriteEndElement(); // datospersonales

            // Configuración de simulación
            writer.WriteElementString("periodos", paciente.PeriodosEvaluar.ToString());
            writer.WriteElementString("m", paciente.TamañoRejilla.ToString());

            // Resultado del análisis
            writer.WriteElementString("resultado", paciente.Resultado ?? "pendiente");

            // Información adicional según el resultado
            if (paciente.N.HasValue)
            {
                writer.WriteElementString("n", paciente.N.Value.ToString());
            }

            if (paciente.N1.HasValue)
            {
                writer.WriteElementString("n1", paciente.N1.Value.ToString());
            }

            writer.WriteEndElement(); // paciente
        }

        // Generar reporte de texto plano también
        public void GenerarReporteTexto(ListaEnlazada<Paciente> pacientes, string rutaSalida)
        {
            using (StreamWriter writer = new StreamWriter(rutaSalida))
            {
                writer.WriteLine("========================================");
                writer.WriteLine("  REPORTE DE ANÁLISIS EPIDEMIOLÓGICO");
                writer.WriteLine("========================================");
                writer.WriteLine();

                int index = 1;
                foreach (var paciente in pacientes)
                {
                    writer.WriteLine($"PACIENTE #{index}");
                    writer.WriteLine($"  Nombre: {paciente.Nombre}");
                    writer.WriteLine($"  Edad: {paciente.Edad}");
                    writer.WriteLine($"  Tamaño de rejilla: {paciente.TamañoRejilla}x{paciente.TamañoRejilla}");
                    writer.WriteLine($"  Períodos evaluados: {paciente.PeriodosEvaluar}");
                    writer.WriteLine($"  RESULTADO: {paciente.Resultado?.ToUpper() ?? "PENDIENTE"}");

                    if (paciente.N.HasValue)
                    {
                        writer.WriteLine($"  N (Período de repetición): {paciente.N}");
                    }
                    if (paciente.N1.HasValue)
                    {
                        writer.WriteLine($"  N1 (Período secundario): {paciente.N1}");
                    }

                    writer.WriteLine(new string('-', 40));
                    index++;
                }

                writer.WriteLine();
                writer.WriteLine("Fin del reporte");
            }
        }
    }
}