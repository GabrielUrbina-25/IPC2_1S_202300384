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
    public partial class FormNuevoMensaje : Form
    {
        private ListaSimple instrucciones;
        private SistemaDrones sistemaSeleccionado;

        public FormNuevoMensaje()
        {
            InitializeComponent();
            instrucciones = new ListaSimple();
            CargarSistemas();
        }

        private void CargarSistemas()
        {
            cmbSistema.Items.Clear();
            ListaSimple sistemas = GestorSistemas.Instancia.ObtenerSistemas();

            for (int i = 0; i < sistemas.Count; i++)
            {
                SistemaDrones s = (SistemaDrones)sistemas.Obtener(i);
                cmbSistema.Items.Add(s.Nombre);
            }

            if (cmbSistema.Items.Count > 0)
                cmbSistema.SelectedIndex = 0;
        }

        private void cmbSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreSistema = cmbSistema.SelectedItem.ToString();
            sistemaSeleccionado = GestorSistemas.Instancia.BuscarSistema(nombreSistema);

            cmbDron.Items.Clear();
            if (sistemaSeleccionado != null)
            {
                for (int i = 0; i < sistemaSeleccionado.DronesConfiguracion.Count; i++)
                {
                    DronConfiguracion dc = (DronConfiguracion)sistemaSeleccionado.DronesConfiguracion.Obtener(i);
                    cmbDron.Items.Add(dc.NombreDron);
                }
                if (cmbDron.Items.Count > 0)
                    cmbDron.SelectedIndex = 0;

                numAltura.Maximum = sistemaSeleccionado.AlturaMaxima;
            }
        }

        private void btnAgregarInstruccion_Click(object sender, EventArgs e)
        {
            if (cmbDron.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un dron.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dron = cmbDron.SelectedItem.ToString();
            int altura = (int)numAltura.Value;

            Instruccion inst = new Instruccion(dron, altura);
            instrucciones.Agregar(inst);

            ActualizarPreview();
        }

        private void ActualizarPreview()
        {
            dgvInstrucciones.Rows.Clear();

            for (int i = 0; i < instrucciones.Count; i++)
            {
                Instruccion inst = (Instruccion)instrucciones.Obtener(i);
                string letra = "?";

                if (sistemaSeleccionado != null)
                {
                    letra = BuscarLetra(sistemaSeleccionado, inst.NombreDron, inst.Altura);
                }

                dgvInstrucciones.Rows.Add(i + 1, inst.NombreDron, inst.Altura, letra);
            }

            // Actualizar mensaje preview
            if (sistemaSeleccionado != null)
            {
                Mensaje temp = new Mensaje();
                temp.Instrucciones = instrucciones;
                temp.NombreSistemaDrones = sistemaSeleccionado.Nombre;

                string decodificado = OptimizadorTiempo.DecodificarMensaje(temp, sistemaSeleccionado);
                lblPreview.Text = "Preview: " + decodificado;
            }
        }

        private string BuscarLetra(SistemaDrones sistema, string dron, int altura)
        {
            for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
            {
                DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                if (dc.NombreDron.Equals(dron, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = 0; j < dc.Alturas.Count; j++)
                    {
                        Altura a = (Altura)dc.Alturas.Obtener(j);
                        if (a.Valor == altura)
                            return string.IsNullOrWhiteSpace(a.Letra) ? "[ESP]" : a.Letra;
                    }
                }
            }
            return "?";
        }

        private void btnEliminarUltima_Click(object sender, EventArgs e)
        {
            if (instrucciones.Count > 0)
            {
                // Eliminar última (necesitamos implementar método en ListaSimple o recrear)
                // Por simplicidad, recreamos la lista sin el último
                ListaSimple nueva = new ListaSimple();
                for (int i = 0; i < instrucciones.Count - 1; i++)
                {
                    nueva.Agregar(instrucciones.Obtener(i));
                }
                instrucciones = nueva;
                ActualizarPreview();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre para el mensaje.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (instrucciones.Count == 0)
            {
                MessageBox.Show("Agregue al menos una instrucción.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Mensaje mensaje = new Mensaje();
            mensaje.Nombre = txtNombre.Text.Trim();
            mensaje.NombreSistemaDrones = cmbSistema.SelectedItem.ToString();
            mensaje.Instrucciones = instrucciones;

            GestorMensajes.Instancia.AgregarMensaje(mensaje);

            MessageBox.Show("Mensaje creado exitosamente.", "Éxito",
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
