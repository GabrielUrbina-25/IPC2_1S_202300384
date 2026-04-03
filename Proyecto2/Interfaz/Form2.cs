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
    public partial class FormCargaXML : Form
    {
        public FormCargaXML()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos XML|*.xml";
            openFileDialog.Title = "Seleccionar archivo de entrada";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog.FileName;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuta.Text))
            {
                MessageBox.Show("Seleccione un archivo primero.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ParserXML.CargarDesdeXML(txtRuta.Text);
                MessageBox.Show("Archivo cargado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
