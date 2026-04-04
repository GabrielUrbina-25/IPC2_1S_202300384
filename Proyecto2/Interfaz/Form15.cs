using Proyecto2.Controladores;
using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto2.Interfaz
{
    public partial class FormReporteCompleto : Form
    {
        public FormReporteCompleto()
        {
            InitializeComponent();
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            txtReporte.Clear();

            // Estadísticas generales
            ListaSimple drones = GestorDrones.Instancia.ObtenerDrones();
            ListaSimple sistemas = GestorSistemas.Instancia.ObtenerSistemas();
            ListaSimple mensajes = GestorMensajes.Instancia.ObtenerMensajes();

            txtReporte.AppendText("=== REPORTE CONSOLIDADO DEL SISTEMA ===\r\n\r\n");
            txtReporte.AppendText("Fecha de generación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n\r\n");

            // Sección 1: Resumen General
            txtReporte.AppendText("--- RESUMEN GENERAL ---\r\n");
            txtReporte.AppendText("Total de Drones registrados: " + drones.Count + "\r\n");
            txtReporte.AppendText("Total de Sistemas de Drones: " + sistemas.Count + "\r\n");
            txtReporte.AppendText("Total de Mensajes procesados: " + mensajes.Count + "\r\n\r\n");

            // Sección 2: Detalle de Drones
            txtReporte.AppendText("--- DETALLE DE DRONES ---\r\n");
            if (drones.Count == 0)
            {
                txtReporte.AppendText("No hay drones registrados.\r\n");
            }
            else
            {
                for (int i = 0; i < drones.Count; i++)
                {
                    Dron d = (Dron)drones.Obtener(i);
                    txtReporte.AppendText((i + 1) + ". " + d.Nombre + "\r\n");
                }
            }
            txtReporte.AppendText("\r\n");

            // Sección 3: Detalle de Sistemas
            txtReporte.AppendText("--- DETALLE DE SISTEMAS DE DRONES ---\r\n");
            if (sistemas.Count == 0)
            {
                txtReporte.AppendText("No hay sistemas registrados.\r\n");
            }
            else
            {
                for (int i = 0; i < sistemas.Count; i++)
                {
                    SistemaDrones s = (SistemaDrones)sistemas.Obtener(i);
                    txtReporte.AppendText((i + 1) + ". " + s.Nombre + "\r\n");
                    txtReporte.AppendText("   - Altura Máxima: " + s.AlturaMaxima + " metros\r\n");
                    txtReporte.AppendText("   - Cantidad de Drones: " + s.CantidadDrones + "\r\n");

                    // Listar drones en el sistema
                    txtReporte.AppendText("   - Drones configurados: ");
                    for (int j = 0; j < s.DronesConfiguracion.Count; j++)
                    {
                        DronConfiguracion dc = (DronConfiguracion)s.DronesConfiguracion.Obtener(j);
                        txtReporte.AppendText(dc.NombreDron);
                        if (j < s.DronesConfiguracion.Count - 1)
                            txtReporte.AppendText(", ");
                    }
                    txtReporte.AppendText("\r\n");
                }
            }
            txtReporte.AppendText("\r\n");

            // Sección 4: Detalle de Mensajes
            txtReporte.AppendText("--- DETALLE DE MENSAJES ---\r\n");
            if (mensajes.Count == 0)
            {
                txtReporte.AppendText("No hay mensajes registrados.\r\n");
            }
            else
            {
                int tiempoTotalGlobal = 0;
                Mensaje mensajeMasLargo = null;
                int maxInstrucciones = 0;

                for (int i = 0; i < mensajes.Count; i++)
                {
                    Mensaje m = (Mensaje)mensajes.Obtener(i);
                    SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(m.NombreSistemaDrones);

                    txtReporte.AppendText((i + 1) + ". " + m.Nombre + "\r\n");
                    txtReporte.AppendText("   - Sistema utilizado: " + m.NombreSistemaDrones + "\r\n");
                    txtReporte.AppendText("   - Instrucciones: " + m.Instrucciones.Count + "\r\n");

                    if (sistema != null)
                    {
                        ResultadoOptimizacion opt = OptimizadorTiempo.CalcularTiempoOptimo(m, sistema);
                        string decodificado = OptimizadorTiempo.DecodificarMensaje(m, sistema);

                        txtReporte.AppendText("   - Tiempo óptimo: " + opt.TiempoTotal + " segundos\r\n");
                        txtReporte.AppendText("   - Mensaje decodificado: \"" + decodificado + "\"\r\n");

                        tiempoTotalGlobal += opt.TiempoTotal;

                        if (m.Instrucciones.Count > maxInstrucciones)
                        {
                            maxInstrucciones = m.Instrucciones.Count;
                            mensajeMasLargo = m;
                        }
                    }
                    else
                    {
                        txtReporte.AppendText("   - [Sistema no encontrado]\r\n");
                    }
                    txtReporte.AppendText("\r\n");
                }

                // Estadísticas adicionales
                txtReporte.AppendText("--- ESTADÍSTICAS ---\r\n");
                txtReporte.AppendText("Tiempo total acumulado (todos los mensajes): " + tiempoTotalGlobal + " segundos\r\n");
                txtReporte.AppendText("Tiempo promedio por mensaje: " +
                    (mensajes.Count > 0 ? (tiempoTotalGlobal / mensajes.Count).ToString() : "0") + " segundos\r\n");

                if (mensajeMasLargo != null)
                {
                    txtReporte.AppendText("Mensaje más largo: \"" + mensajeMasLargo.Nombre + "\" con " +
                        maxInstrucciones + " instrucciones\r\n");
                }
            }

            txtReporte.AppendText("\r\n=== FIN DEL REPORTE ===\r\n");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de texto|*.txt";
            saveFileDialog.FileName = "Reporte_Sistema_Drones_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, txtReporte.Text);
                    MessageBox.Show("Reporte guardado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}