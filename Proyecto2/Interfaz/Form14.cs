using Proyecto2.Controladores;
using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using Proyecto2.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto2.Interfaz
{
    public partial class FormGenerarSalida : Form
    {
        // Campo para almacenar mensajes seleccionados
        private ListaSimple mensajesSeleccionados;

        public FormGenerarSalida()
        {
            InitializeComponent();
            mensajesSeleccionados = new ListaSimple();
            CargarMensajes();
        }

        private void CargarMensajes()
        {
            dgvMensajes.Rows.Clear();
            ListaSimple mensajes = GestorMensajes.Instancia.ObtenerMensajes();

            for (int i = 0; i < mensajes.Count; i++)
            {
                Mensaje m = (Mensaje)mensajes.Obtener(i);

                // Calcular tiempo y decodificación para mostrar
                SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(m.NombreSistemaDrones);
                string tiempo = "N/A";
                string decodificado = "N/A";

                if (sistema != null)
                {
                    ResultadoOptimizacion opt = OptimizadorTiempo.CalcularTiempoOptimo(m, sistema);
                    tiempo = opt.TiempoTotal.ToString() + "s";
                    decodificado = OptimizadorTiempo.DecodificarMensaje(m, sistema);
                }

                dgvMensajes.Rows.Add(false, m.Nombre, m.NombreSistemaDrones, tiempo, decodificado);
            }
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMensajes.Rows.Count; i++)
            {
                dgvMensajes.Rows[i].Cells[0].Value = true;
            }
        }

        private void btnDeseleccionarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMensajes.Rows.Count; i++)
            {
                dgvMensajes.Rows[i].Cells[0].Value = false;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // Recolectar mensajes seleccionados
            mensajesSeleccionados = new ListaSimple();

            for (int i = 0; i < dgvMensajes.Rows.Count; i++)
            {
                DataGridViewRow row = dgvMensajes.Rows[i];
                bool seleccionado = Convert.ToBoolean(row.Cells[0].Value);

                if (seleccionado)
                {
                    string nombreMensaje = row.Cells[1].Value.ToString();
                    Mensaje m = GestorMensajes.Instancia.BuscarMensaje(nombreMensaje);
                    if (m != null)
                    {
                        mensajesSeleccionados.Agregar(m);
                    }
                }
            }

            if (mensajesSeleccionados.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un mensaje para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pedir ruta de guardado
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos XML|*.xml";
            saveFileDialog.FileName = "salida.xml";
            saveFileDialog.Title = "Guardar archivo de salida";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GeneradorXML.GenerarXMLSalida(saveFileDialog.FileName, mensajesSeleccionados);
                    MessageBox.Show("Archivo XML generado exitosamente.\n\nRuta: " + saveFileDialog.FileName,
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar XML: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}