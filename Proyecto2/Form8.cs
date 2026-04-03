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
    public partial class FormConfigurarDron : Form
    {
        private string nombreDron;
        private int alturaMaxima;
        public ListaSimple AlturasConfiguradas { get; private set; }

        public FormConfigurarDron(string nombreDron, int alturaMaxima)
        {
            this.nombreDron = nombreDron;
            this.alturaMaxima = alturaMaxima;
            this.AlturasConfiguradas = new ListaSimple();
            InitializeComponent();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            lblTitulo.Text = "Configurar " + nombreDron;

            // Crear filas para cada altura (de 1 a alturaMaxima)
            dgvAlturas.Rows.Clear();

            for (int altura = 1; altura <= alturaMaxima; altura++)
            {
                string letraDefault = "";

                // Valores por defecto según el ejemplo del proyecto
                if (altura == 8 && nombreDron == "Dron01")
                    letraDefault = " "; // Espacio en blanco
                else
                    letraDefault = ObtenerLetraDefault(altura);

                dgvAlturas.Rows.Add(altura, letraDefault);
            }
        }

        private string ObtenerLetraDefault(int altura)
        {
            // Valores de ejemplo según la tabla del documento
            // Puedes modificar esto o dejarlo vacío
            return "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AlturasConfiguradas = new ListaSimple();

            for (int i = 0; i < dgvAlturas.Rows.Count; i++)
            {
                DataGridViewRow row = dgvAlturas.Rows[i];
                int altura = Convert.ToInt32(row.Cells[0].Value);
                string letra = row.Cells[1].Value?.ToString() ?? "";

                AlturasConfiguradas.Agregar(new Altura(altura, letra));
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
