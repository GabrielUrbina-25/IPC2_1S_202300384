using Practica2.Models;
using Practica2.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica2
{
    public partial class Form1 : Form
    {
        ColaPacientes cola = new ColaPacientes();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Medicina General");
            comboBox1.Items.Add("Pediatría");
            comboBox1.Items.Add("Ginecología");
            comboBox1.Items.Add("Dermatología");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bntAtender_Click(object sender, EventArgs e)
        {
            Paciente p = cola.Desencolar();

            if (p == null)
                MessageBox.Show("No hay pacientes en espera");
            else
                MessageBox.Show($"Atendiendo a: {p.Nombre}");

            MostrarCola();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string[] datos = cola.Mostrar().Split("->");

            foreach (string d in datos)
                listBox1.Items.Add(d);

            MostrarCola();
        }

        private void btnGraphviz_Click(object sender, EventArgs e)
        {
            try
            {
                GraphvizGenerator.Generar(cola);
                MessageBox.Show("Imagen generada: cola.png");
            }
            catch
            {
                MessageBox.Show("Error: Graphviz no configurado");
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            int edad;
            if (!int.TryParse(textBox2.Text, out edad))
            {
                MessageBox.Show("Edad inválida");
                return;
            }

            Paciente p = new Paciente(textBox1.Text, edad, comboBox1.Text);
            cola.Encolar(p);

            MessageBox.Show("Paciente agregado");

            Limpiar();
            MostrarCola();
        }
        private void MostrarCola()
        {
            listBox1.Items.Clear();

            var lista = cola.ALista();

            foreach (var p in lista)
            {
                listBox1.Items.Add(
                    $"{p.Nombre} | {p.Especialidad} | Espera: {p.TiempoEsperaEstimado} min | Total: {p.ObtenerTiempoTotal()} min"
                );
            }

            label5.Text = "Tiempo total: " + cola.ObtenerTiempoTotal() + " min";
        }

        private void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}