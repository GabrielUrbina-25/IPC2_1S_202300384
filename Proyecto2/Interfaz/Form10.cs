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
        public partial class FormDetalleMensaje : Form
        {
            // Campo privado a nivel de clase
            private Mensaje mensaje;

            public FormDetalleMensaje(Mensaje mensaje)
            {
                InitializeComponent();
                this.mensaje = mensaje;
                MostrarDetalle();
            }

            private void MostrarDetalle()
            {
                lblNombre.Text = "Mensaje: " + mensaje.Nombre;
                lblSistema.Text = "Sistema: " + mensaje.NombreSistemaDrones;

                // Buscar sistema
                SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(mensaje.NombreSistemaDrones);

                if (sistema != null)
                {
                    // Decodificar mensaje completo
                    string mensajeDecodificado = OptimizadorTiempo.DecodificarMensaje(mensaje, sistema);
                    lblMensaje.Text = "Mensaje Decodificado: " + mensajeDecodificado;

                    // Calcular tiempo óptimo
                    ResultadoOptimizacion resultado = OptimizadorTiempo.CalcularTiempoOptimo(mensaje, sistema);
                    lblTiempoOptimo.Text = "Tiempo Óptimo: " + resultado.TiempoTotal + " segundos";

                    // Mostrar resumen de instrucciones
                    dgvResumen.Rows.Clear();
                    for (int i = 0; i < mensaje.Instrucciones.Count; i++)
                    {
                        Instruccion inst = (Instruccion)mensaje.Instrucciones.Obtener(i);

                        // Buscar letra para esta instrucción específica
                        string letra = BuscarLetra(sistema, inst.NombreDron, inst.Altura);

                        dgvResumen.Rows.Add(i + 1, inst.NombreDron, inst.Altura, letra);
                    }
                }
                else
                {
                    lblMensaje.Text = "Mensaje Decodificado: [Sistema no encontrado]";
                    lblTiempoOptimo.Text = "Tiempo Óptimo: [N/A]";
                }
            }

            private string BuscarLetra(SistemaDrones sistema, string nombreDron, int altura)
            {
                for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
                {
                    DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                    if (dc.NombreDron.Equals(nombreDron, StringComparison.OrdinalIgnoreCase))
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

            private void btnVerInstrucciones_Click(object sender, EventArgs e)
            {
                FormInstruccionesMensaje form = new FormInstruccionesMensaje(mensaje);
                form.ShowDialog();
            }

            private void btnVerCalculadora_Click(object sender, EventArgs e)
            {
                SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(mensaje.NombreSistemaDrones);
                if (sistema != null)
                {
                    FormCalculadoraTiempo form = new FormCalculadoraTiempo(mensaje, sistema);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontró el sistema de drones asociado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnCerrar_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
}
