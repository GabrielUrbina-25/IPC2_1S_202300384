using Proyecto2.Controladores;
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
    public partial class FormInstruccionesMensaje : Form
    {
        private Mensaje mensaje;
        public FormInstruccionesMensaje(Mensaje mensaje)
        {
            this.mensaje = mensaje;
            InitializeComponent();
            CargarInstrucciones();
        }

        private void CargarInstrucciones()
        {
            lblTitulo.Text = "Instrucciones: " + mensaje.Nombre;

            SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(mensaje.NombreSistemaDrones);
            ResultadoOptimizacion optimizacion = null;

            if (sistema != null)
            {
                optimizacion = OptimizadorTiempo.CalcularTiempoOptimo(mensaje, sistema);
            }

            dgvInstrucciones.Rows.Clear();

            for (int i = 0; i < mensaje.Instrucciones.Count; i++)
            {
                Instruccion inst = (Instruccion)mensaje.Instrucciones.Obtener(i);

                string tiempoInicio = "-";
                string tiempoFin = "-";
                string movimiento = "-";

                if (optimizacion != null && i < optimizacion.Acciones.Count)
                {
                    AccionTiempo accion = (AccionTiempo)optimizacion.Acciones.Obtener(i);
                    tiempoInicio = "T" + accion.Inicio;
                    tiempoFin = "T" + accion.Fin;

                    if (accion.AlturaInicial < accion.AlturaObjetivo)
                        movimiento = "Subir " + (accion.AlturaObjetivo - accion.AlturaInicial) + "m";
                    else if (accion.AlturaInicial > accion.AlturaObjetivo)
                        movimiento = "Bajar " + (accion.AlturaInicial - accion.AlturaObjetivo) + "m";
                    else
                        movimiento = "Mantener";
                }

                string letra = "?";
                if (sistema != null)
                {
                    letra = BuscarLetra(sistema, inst.NombreDron, inst.Altura);
                }

                dgvInstrucciones.Rows.Add(
                    i + 1,
                    inst.NombreDron,
                    inst.Altura,
                    letra,
                    tiempoInicio,
                    tiempoFin,
                    movimiento
                );
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

        private void btnGenerarGraphviz_Click(object sender, EventArgs e)
        {
            try
            {
                SistemaDrones sistema = GestorSistemas.Instancia.BuscarSistema(mensaje.NombreSistemaDrones);
                if (sistema == null)
                {
                    MessageBox.Show("Sistema no encontrado.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ResultadoOptimizacion resultado = OptimizadorTiempo.CalcularTiempoOptimo(mensaje, sistema);

                string rutaTemp = System.IO.Path.GetTempPath();
                string rutaImagen = GeneradorGraphviz.GenerarGraficaInstrucciones(
                    mensaje, mensaje.Instrucciones, mensaje.NombreSistemaDrones, rutaTemp);

                FormVisualizadorGraphviz form = new FormVisualizadorGraphviz(rutaImagen,
                    "Instrucciones_" + mensaje.Nombre);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar gráfica: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
