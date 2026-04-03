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

namespace Proyecto2
{
    public partial class FormMensajes : Form
    {
        public FormMensajes()
        {
            InitializeComponent();
            CargarMensajes();
        }

        private void CargarMensajes()
        {
            dgvMensajes.Rows.Clear();
            ListaSimple mensajes = GestorMensajes.Instancia.ObtenerMensajes();

            for (int i = 0; i < mensajes.Count; i++)
            {
                Mensaje mensaje = (Mensaje)mensajes.Obtener(i);
                dgvMensajes.Rows.Add(
                    mensaje.Nombre,
                    mensaje.NombreSistemaDrones,
                    mensaje.Instrucciones.Count,
                    "Ver Detalle"
                );
            }

            if (mensajes.Count == 0)
            {
                MessageBox.Show("No hay mensajes cargados.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvMensajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreMensaje = dgvMensajes.Rows[e.RowIndex].Cells[0].Value.ToString();
            Mensaje mensaje = GestorMensajes.Instancia.BuscarMensaje(nombreMensaje);

            if (mensaje == null) return;

            // Columna 3 = Ver Detalle
            if (e.ColumnIndex == 3)
            {
                FormDetalleMensaje form = new FormDetalleMensaje(mensaje);
                form.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevoMensaje form = new FormNuevoMensaje();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarMensajes();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}