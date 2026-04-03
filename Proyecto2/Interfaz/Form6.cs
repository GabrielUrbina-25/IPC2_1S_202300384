using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Proyecto2
{
    public partial class FormVisualizadorGraphviz : Form
    {
        private string rutaImagen;
        private string titulo;
        public FormVisualizadorGraphviz(string rutaImagen, string titulo)
        {
            this.rutaImagen = rutaImagen;
            this.titulo = titulo;
            InitializeComponent();
            CargarImagen();
        }
        private void CargarImagen()
        {
            try
            {
                if (File.Exists(rutaImagen))
                {
                    // Cargar imagen en PictureBox
                    Image img = Image.FromFile(rutaImagen);
                    pictureBox.Image = img;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    this.Text = "Visualización: " + titulo;
                    lblInfo.Text = "Archivo: " + Path.GetFileName(rutaImagen);
                }
                else
                {
                    MessageBox.Show("No se encontró la imagen generada.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Imagen PNG|*.png";
            saveFileDialog.FileName = titulo + ".png";
            saveFileDialog.Title = "Guardar gráfica";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(rutaImagen, saveFileDialog.FileName, true);
                    MessageBox.Show("Imagen guardada exitosamente.", "Éxito",
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