using Proyecto2.Interfaz;

namespace Proyecto2
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInicializar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema inicializado correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCargarXML_Click(object sender, EventArgs e)
        {
            FormCargaXML form = new FormCargaXML();
            form.ShowDialog();
        }

        private void btnGestionDrones_Click(object sender, EventArgs e)
        {
            FormDrones form = new FormDrones();
            form.ShowDialog();
        }

        private void btnGestionSistemas_Click(object sender, EventArgs e)
        {
            FormSistemas form = new FormSistemas();
            form.ShowDialog();
        }

        private void btnGestionMensajes_Click(object sender, EventArgs e)
        {
            FormMensajes form = new FormMensajes();
            form.ShowDialog();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Proyecto 2 - IPC2\n" +
                "Universidad San Carlos de Guatemala\n" +
                "Facultad de Ingeniería\n\n" +
                "Estudiante: Gabriel Eduardo Urbina Sunún\n" +
                "Carnet: 202300384\n\n" +
                "",
                "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenerarXML_Click(object sender, EventArgs e)
        {
            FormGenerarSalida form = new FormGenerarSalida();
            form.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReporteCompleto form = new FormReporteCompleto();
            form.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir del sistema?",
                "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
