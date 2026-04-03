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

namespace Proyecto2
{
    public partial class FormSistemas : Form
    {
        public FormSistemas()
        {
            InitializeComponent();
            CargarSistemas();
        }

        private void CargarSistemas()
        {
            dgvSistemas.Rows.Clear();
            ListaSimple sistemas = GestorSistemas.Instancia.ObtenerSistemas();

            for (int i = 0; i < sistemas.Count; i++)
            {
                SistemaDrones sistema = (SistemaDrones)sistemas.Obtener(i);
                dgvSistemas.Rows.Add(
                    sistema.Nombre,
                    sistema.AlturaMaxima,
                    sistema.CantidadDrones,
                    "Ver Detalle",
                    "Ver Gráfica"
                );
            }

            if (sistemas.Count == 0)
            {
                MessageBox.Show("No hay sistemas de drones cargados.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSistemas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreSistema = dgvSistemas.Rows[e.RowIndex].Cells[0].Value.ToString();
            SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(nombreSistema);

            if (sistema == null) return;

            // Columna 3 = Ver Detalle
            if (e.ColumnIndex == 3)
            {
                FormDetalleSistema form = new FormDetalleSistema(sistema);
                form.ShowDialog();
            }
            // Columna 4 = Ver Gráfica
            else if (e.ColumnIndex == 4)
            {
                try
                {
                    string rutaTemp = System.IO.Path.GetTempPath();
                    string rutaImagen = GeneradorGraphviz.GenerarGraficaSistema(sistema, rutaTemp);

                    FormVisualizadorGraphviz form = new FormVisualizadorGraphviz(rutaImagen, sistema.Nombre);
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar gráfica: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevoSistema form = new FormNuevoSistema();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarSistemas();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
