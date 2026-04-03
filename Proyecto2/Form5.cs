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
    public partial class FormDetalleSistema : Form
    {
        private SistemaDrones sistema;

        public FormDetalleSistema(SistemaDrones sistema)
        {
            this.sistema = sistema;
            InitializeComponent();
            MostrarDetalle();
        }

        private void MostrarDetalle()
        {
            lblNombre.Text = "Sistema: " + sistema.Nombre;
            lblAlturaMax.Text = "Altura Máxima: " + sistema.AlturaMaxima + " metros";
            lblCantidad.Text = "Cantidad de Drones: " + sistema.CantidadDrones;

            // Construir matriz en DataGridView
            // Columnas: Dron1, Dron2, ...
            // Filas: Altura N, ..., Altura 1

            dgvMatriz.Columns.Clear();
            dgvMatriz.Rows.Clear();

            // Columna de alturas
            dgvMatriz.Columns.Add("Altura", "Altura");

            // Columnas para cada dron
            for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
            {
                DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                dgvMatriz.Columns.Add(dc.NombreDron, dc.NombreDron);
            }

            // Filas de mayor altura a menor
            for (int altura = sistema.AlturaMaxima; altura >= 1; altura--)
            {
                object[] rowData = new object[sistema.DronesConfiguracion.Count + 1];
                rowData[0] = altura;

                for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
                {
                    DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                    rowData[i + 1] = ObtenerLetra(dc, altura);
                }

                dgvMatriz.Rows.Add(rowData);
            }

            // Destacar el espacio en blanco (Dron01 a 8 metros si existe)
            ResaltarEspacioBlanco();
        }

        private string ObtenerLetra(DronConfiguracion dc, int altura)
        {
            for (int i = 0; i < dc.Alturas.Count; i++)
            {
                Altura a = (Altura)dc.Alturas.Obtener(i);
                if (a.Valor == altura)
                {
                    return string.IsNullOrWhiteSpace(a.Letra) ? "[ESP]" : a.Letra;
                }
            }
            return "-";
        }

        private void ResaltarEspacioBlanco()
        {
            // Según el documento: Dron01 a 8 metros representa espacio en blanco
            // Buscamos si existe esa configuración
            if (sistema.AlturaMaxima >= 8 && sistema.DronesConfiguracion.Count > 0)
            {
                // Asumimos que Dron01 es el primero (columna 1)
                // Fila 0 corresponde a altura 8 (si AlturaMaxima=8)
                // Si AlturaMaxima>8, calculamos la fila correspondiente

                int filaEspacio = sistema.AlturaMaxima - 8; // 8 es la altura del espacio
                if (filaEspacio >= 0 && filaEspacio < dgvMatriz.Rows.Count)
                {
                    dgvMatriz.Rows[filaEspacio].Cells[1].Style.BackColor = System.Drawing.Color.Yellow;
                    dgvMatriz.Rows[filaEspacio].Cells[1].ToolTipText = "Espacio en blanco";
                }
            }
        }

        private void btnGenerarGraphviz_Click(object sender, EventArgs e)
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
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
