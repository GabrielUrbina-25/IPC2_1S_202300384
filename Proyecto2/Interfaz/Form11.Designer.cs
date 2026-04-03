namespace Proyecto2
{
    partial class FormInstruccionesMensaje
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvInstrucciones = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Altura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Letra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerarGraphviz = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrucciones)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Instrucciones";

            // dgvInstrucciones
            this.dgvInstrucciones.AllowUserToAddRows = false;
            this.dgvInstrucciones.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstrucciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.No,
                this.Dron,
                this.Altura,
                this.Letra,
                this.TiempoInicio,
                this.TiempoFin,
                this.Movimiento});
            this.dgvInstrucciones.Location = new System.Drawing.Point(12, 50);
            this.dgvInstrucciones.Name = "dgvInstrucciones";
            this.dgvInstrucciones.ReadOnly = true;
            this.dgvInstrucciones.Size = new System.Drawing.Size(760, 350);
            this.dgvInstrucciones.TabIndex = 1;

            // No
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;

            // Dron
            this.Dron.HeaderText = "Dron";
            this.Dron.Name = "Dron";
            this.Dron.ReadOnly = true;
            this.Dron.Width = 120;

            // Altura
            this.Altura.HeaderText = "Altura (m)";
            this.Altura.Name = "Altura";
            this.Altura.ReadOnly = true;
            this.Altura.Width = 80;

            // Letra
            this.Letra.HeaderText = "Letra";
            this.Letra.Name = "Letra";
            this.Letra.ReadOnly = true;
            this.Letra.Width = 80;

            // TiempoInicio
            this.TiempoInicio.HeaderText = "Inicio";
            this.TiempoInicio.Name = "TiempoInicio";
            this.TiempoInicio.ReadOnly = true;
            this.TiempoInicio.Width = 80;

            // TiempoFin
            this.TiempoFin.HeaderText = "Fin";
            this.TiempoFin.Name = "TiempoFin";
            this.TiempoFin.ReadOnly = true;
            this.TiempoFin.Width = 80;

            // Movimiento
            this.Movimiento.HeaderText = "Movimiento";
            this.Movimiento.Name = "Movimiento";
            this.Movimiento.ReadOnly = true;
            this.Movimiento.Width = 150;

            // btnGenerarGraphviz
            this.btnGenerarGraphviz.Location = new System.Drawing.Point(12, 415);
            this.btnGenerarGraphviz.Name = "btnGenerarGraphviz";
            this.btnGenerarGraphviz.Size = new System.Drawing.Size(150, 35);
            this.btnGenerarGraphviz.TabIndex = 2;
            this.btnGenerarGraphviz.Text = "Generar Gráfica Graphviz";
            this.btnGenerarGraphviz.UseVisualStyleBackColor = true;
            this.btnGenerarGraphviz.Click += new System.EventHandler(this.btnGenerarGraphviz_Click);

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(622, 415);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 35);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // FormInstruccionesMensaje
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 466);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGenerarGraphviz);
            this.Controls.Add(this.dgvInstrucciones);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormInstruccionesMensaje";
            this.Text = "Instrucciones Detalladas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrucciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvInstrucciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dron;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimiento;
        private System.Windows.Forms.Button btnGenerarGraphviz;
        private System.Windows.Forms.Button btnCerrar;
    }
}