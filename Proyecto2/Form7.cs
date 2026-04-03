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
    public partial class FormNuevoSistema : Form
    {
        private ListaSimple dronesDisponibles;
        private ListaSimple configuraciones;

        public FormNuevoSistema()
        {
            InitializeComponent();
            CargarDronesDisponibles();
            configuraciones = new ListaSimple();
        }

        private void CargarDronesDisponibles()
        {
            cmbDrones.Items.Clear();
            dronesDisponibles = GestorDrones.Instancia.ObtenerDrones();

            for (int i = 0; i < dronesDisponibles.Count; i++)
            {
                Dron dron = (Dron)dronesDisponibles.Obtener(i);
                cmbDrones.Items.Add(dron.Nombre);
            }

            if (cmbDrones.Items.Count > 0)
                cmbDrones.SelectedIndex = 0;
        }

        private void btnAgregarDron_Click(object sender, EventArgs e)
        {
            if (cmbDrones.SelectedItem == null) return;

            string nombreDron = cmbDrones.SelectedItem.ToString();

            // Verificar si ya está agregado
            bool existe = false;
            for (int i = 0; i < configuraciones.Count; i++)
            {
                DronConfiguracion dc = (DronConfiguracion)configuraciones.Obtener(i);
                if (dc.NombreDron == nombreDron)
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                MessageBox.Show("Este dron ya fue agregado al sistema.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DronConfiguracion nuevaConfig = new DronConfiguracion();
            nuevaConfig.NombreDron = nombreDron;
            configuraciones.Agregar(nuevaConfig);

            ActualizarListaDronesConfigurados();
        }

        private void ActualizarListaDronesConfigurados()
        {
            dgvDronesSistema.Rows.Clear();
            for (int i = 0; i < configuraciones.Count; i++)
            {
                DronConfiguracion dc = (DronConfiguracion)configuraciones.Obtener(i);
                dgvDronesSistema.Rows.Add(dc.NombreDron, "Configurar");
            }
        }

        private void dgvDronesSistema_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 1) return;

            string nombreDron = dgvDronesSistema.Rows[e.RowIndex].Cells[0].Value.ToString();
            int alturaMax = (int)numAlturaMax.Value;

            // Form para configurar alturas de este dron
            FormConfigurarDron form = new FormConfigurarDron(nombreDron, alturaMax);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Guardar configuración
                for (int i = 0; i < configuraciones.Count; i++)
                {
                    DronConfiguracion dc = (DronConfiguracion)configuraciones.Obtener(i);
                    if (dc.NombreDron == nombreDron)
                    {
                        dc.Alturas = form.AlturasConfiguradas;
                        break;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre para el sistema.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (configuraciones.Count == 0)
            {
                MessageBox.Show("Agregue al menos un dron al sistema.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SistemaDrones sistema = new SistemaDrones();
            sistema.Nombre = txtNombre.Text.Trim();
            sistema.AlturaMaxima = (int)numAlturaMax.Value;
            sistema.CantidadDrones = configuraciones.Count;
            sistema.DronesConfiguracion = configuraciones;

            GestorSistemas.Instancia.AgregarSistema(sistema);

            MessageBox.Show("Sistema creado exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

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
