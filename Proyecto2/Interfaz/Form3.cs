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
    public partial class FormDrones : Form
    {
        public FormDrones()
        {
            InitializeComponent();
            CargarDrones();
        }
        private void CargarDrones()
        {
            dgvDrones.Rows.Clear();
            ListaSimple drones = GestorDrones.Instancia.ObtenerDrones();

            drones.Recorrer(obj =>
            {
                Dron dron = (Dron)obj;
                dgvDrones.Rows.Add(dron.Nombre);
            });
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreDron.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese un nombre válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GestorDrones.Instancia.AgregarDron(nombre))
            {
                MessageBox.Show("Dron agregado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreDron.Clear();
                CargarDrones();
            }
            else
            {
                MessageBox.Show("El dron ya existe o el nombre es inválido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
