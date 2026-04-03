using Proyecto2.Controladores;
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
    public partial class FormCalculadoraTiempo : Form
    {
        private Mensaje mensaje;
        private SistemaDrones sistema;

        public FormCalculadoraTiempo(Mensaje mensaje, SistemaDrones sistema)
        {
            this.mensaje = mensaje;
            this.sistema = sistema;
            InitializeComponent();
            CalcularYMostrar();
        }

        private void CalcularYMostrar()
        {
            lblTitulo.Text = "Cálculo de Tiempo Óptimo: " + mensaje.Nombre;

            ResultadoOptimizacion resultado = OptimizadorTiempo.CalcularTiempoOptimo(mensaje, sistema);

            lblTiempoTotal.Text = "TIEMPO TOTAL ÓPTIMO: " + resultado.TiempoTotal + " segundos";

            // Mostrar timeline detallado
            dgvTimeline.Rows.Clear();

            for (int i = 0; i < resultado.Acciones.Count; i++)
            {
                AccionTiempo accion = (AccionTiempo)resultado.Acciones.Obtener(i);

                // Determinar tipo de movimiento
                string tipoMov;
                if (accion.AlturaInicial < accion.AlturaObjetivo)
                    tipoMov = "SUBIR";
                else if (accion.AlturaInicial > accion.AlturaObjetivo)
                    tipoMov = "BAJAR";
                else
                    tipoMov = "ESPERAR";

                int distancia = Math.Abs(accion.AlturaObjetivo - accion.AlturaInicial);

                dgvTimeline.Rows.Add(
                    i + 1,
                    accion.Dron,
                    "T" + accion.Inicio + " - T" + (accion.Inicio + accion.TiempoMovimiento),
                    tipoMov,
                    accion.AlturaInicial + " → " + accion.AlturaObjetivo,
                    distancia + "s",
                    "T" + (accion.Inicio + accion.TiempoMovimiento) + " - T" + accion.Fin,
                    "1s",
                    accion.DuracionTotal + "s"
                );
            }

            // Agregar explicación
            txtExplicacion.Text = "EXPLICACIÓN DEL CÁLCULO:\r\n\r\n" +
                "1. Cada dron inicia en la altura 1 (suelo).\r\n" +
                "2. El tiempo de movimiento es 1 segundo por cada metro de diferencia de altura.\r\n" +
                "3. El tiempo de emisión de luz es 1 segundo por instrucción.\r\n" +
                "4. Solo un dron puede emitir luz a la vez (secuencial).\r\n" +
                "5. Los drones pueden moverse en paralelo mientras otro emite luz.\r\n\r\n" +
                "Fórmula: Tiempo = |AlturaObjetivo - AlturaActual| + 1 (emisión)\r\n" +
                "Tiempo Total = Suma acumulativa considerando disponibilidad de cada dron.";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
