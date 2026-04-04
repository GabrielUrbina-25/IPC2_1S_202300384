using Proyecto2.Controladores;
using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Utilidades
{
    public static class GeneradorXML
    {
        public static void GenerarXMLSalida(string rutaArchivo, ListaSimple mensajesAGenerar)
        {
            StringBuilder xml = new StringBuilder();
            xml.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.AppendLine("<respuesta>");
            xml.AppendLine("  <listaMensajes>");

            for (int i = 0; i < mensajesAGenerar.Count; i++)
            {
                Mensaje mensaje = (Mensaje)mensajesAGenerar.Obtener(i);
                SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(mensaje.NombreSistemaDrones);

                if (sistema == null) continue;

                ResultadoOptimizacion optimizacion = OptimizadorTiempo.CalcularTiempoOptimo(mensaje, sistema);
                string mensajeDecodificado = OptimizadorTiempo.DecodificarMensaje(mensaje, sistema);

                xml.AppendLine("    <mensaje nombre=\"" + EscapeXml(mensaje.Nombre) + "\">");
                xml.AppendLine("      <sistemaDrones>" + EscapeXml(mensaje.NombreSistemaDrones) + "</sistemaDrones>");
                xml.AppendLine("      <tiempoOptimo>" + optimizacion.TiempoTotal + "</tiempoOptimo>");
                xml.AppendLine("      <mensajeRecibido>" + EscapeXml(mensajeDecodificado) + "</mensajeRecibido>");
                xml.AppendLine("      <instrucciones>");

                // Generar instrucciones por tiempo
                for (int j = 0; j < optimizacion.Acciones.Count; j++)
                {
                    AccionTiempo accion = (AccionTiempo)optimizacion.Acciones.Obtener(j);

                    xml.AppendLine("        <tiempo valor=\"" + accion.Inicio + "\">");
                    xml.AppendLine("          <acciones>");

                    // Determinar la acción del dron
                    string accionDron;
                    if (accion.AlturaInicial < accion.AlturaObjetivo)
                        accionDron = "Subir a " + accion.AlturaObjetivo + " metros";
                    else if (accion.AlturaInicial > accion.AlturaObjetivo)
                        accionDron = "Bajar a " + accion.AlturaObjetivo + " metros";
                    else
                        accionDron = "Mantenerse en " + accion.AlturaObjetivo + " metros";

                    // Emitir luz si está en el tiempo de emisión (último segundo de la acción)
                    if (accion.Inicio + accion.TiempoMovimiento < accion.Fin)
                    {
                        accionDron += ", Emitir luz";
                    }

                    xml.AppendLine("            <dron nombre=\"" + EscapeXml(accion.Dron) + "\">" +
                        EscapeXml(accionDron) + "</dron>");
                    xml.AppendLine("          </acciones>");
                    xml.AppendLine("        </tiempo>");

                    // Si hay tiempo de emisión separado, agregar otro nodo
                    if (accion.TiempoMovimiento > 0 && accion.Inicio + accion.TiempoMovimiento < accion.Fin)
                    {
                        xml.AppendLine("        <tiempo valor=\"" + (accion.Inicio + accion.TiempoMovimiento) + "\">");
                        xml.AppendLine("          <acciones>");
                        xml.AppendLine("            <dron nombre=\"" + EscapeXml(accion.Dron) + "\">Emitir luz</dron>");
                        xml.AppendLine("          </acciones>");
                        xml.AppendLine("        </tiempo>");
                    }
                }

                xml.AppendLine("      </instrucciones>");
                xml.AppendLine("    </mensaje>");
            }

            xml.AppendLine("  </listaMensajes>");
            xml.AppendLine("</respuesta>");

            File.WriteAllText(rutaArchivo, xml.ToString(), Encoding.UTF8);
        }

        private static string EscapeXml(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            return input
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&apos;");
        }
    }
}
