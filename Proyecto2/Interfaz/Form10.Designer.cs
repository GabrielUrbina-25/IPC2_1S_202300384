namespace Proyecto2
{
    partial class FormDetalleMensaje
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblTiempoOptimo = new System.Windows.Forms.Label();
            this.dgvResumen = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Altura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Letra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerInstrucciones = new System.Windows.Forms.Button();
            this.btnVerCalculadora = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(12, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(90, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Mensaje: ";

            // lblSistema
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(12, 45);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(51, 13);
            this.lblSistema.TabIndex = 1;
            this.lblSistema.Text = "Sistema: ";

            // lblMensaje
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.ForeColor = System.Drawing.Color.Blue;
            this.lblMensaje.Location = new System.Drawing.Point(12, 75);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(163, 17);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "Mensaje Decodificado: ";

            // lblTiempoOptimo
            this.lblTiempoOptimo.AutoSize = true;
            this.lblTiempoOptimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTiempoOptimo.ForeColor = System.Drawing.Color.Green;
            this.lblTiempoOptimo.Location = new System.Drawing.Point(12, 105);
            this.lblTiempoOptimo.Name = "lblTiempoOptimo";
            this.lblTiempoOptimo.Size = new System.Drawing.Size(121, 17);
            this.lblTiempoOptimo.TabIndex = 3;
            this.lblTiempoOptimo.Text = "Tiempo Óptimo: ";

            // dgvResumen
            this.dgvResumen.AllowUserToAddRows = false;
            this.dgvResumen.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.No,
                this.Dron,
                this.Altura,
                this.Letra});
            this.dgvResumen.Location = new System.Drawing.Point(15, 30);
            this.dgvResumen.Name = "dgvResumen";
            this.dgvResumen.ReadOnly = true;
            this.dgvResumen.Size = new System.Drawing.Size(525, 180);
            this.dgvResumen.TabIndex = 4;

            // No
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;

            // Dron
            this.Dron.HeaderText = "Dron";
            this.Dron.Name = "Dron";
            this.Dron.ReadOnly = true;
            this.Dron.Width = 150;

            // Altura
            this.Altura.HeaderText = "Altura (m)";
            this.Altura.Name = "Altura";
            this.Altura.ReadOnly = true;
            this.Altura.Width = 100;

            // Letra
            this.Letra.HeaderText = "Letra";
            this.Letra.Name = "Letra";
            this.Letra.ReadOnly = true;
            this.Letra.Width = 100;

            // groupBox1
            this.groupBox1.Controls.Add(this.dgvResumen);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 220);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resumen de Instrucciones";

            // btnVerInstrucciones
            this.btnVerInstrucciones.Location = new System.Drawing.Point(12, 370);
            this.btnVerInstrucciones.Name = "btnVerInstrucciones";
            this.btnVerInstrucciones.Size = new System.Drawing.Size(140, 35);
            this.btnVerInstrucciones.TabIndex = 6;
            this.btnVerInstrucciones.Text = "Ver Instrucciones Detalladas";
            this.btnVerInstrucciones.UseVisualStyleBackColor = true;
            this.btnVerInstrucciones.Click += new System.EventHandler(this.btnVerInstrucciones_Click);

            // btnVerCalculadora
            this.btnVerCalculadora.Location = new System.Drawing.Point(162, 370);
            this.btnVerCalculadora.Name = "btnVerCalculadora";
            this.btnVerCalculadora.Size = new System.Drawing.Size(140, 35);
            this.btnVerCalculadora.TabIndex = 7;
            this.btnVerCalculadora.Text = "Ver Cálculo de Tiempo";
            this.btnVerCalculadora.UseVisualStyleBackColor = true;
            this.btnVerCalculadora.Click += new System.EventHandler(this.btnVerCalculadora_Click);

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(432, 370);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(140, 35);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // FormDetalleMensaje
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 420);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnVerCalculadora);
            this.Controls.Add(this.btnVerInstrucciones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTiempoOptimo);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.lblNombre);
            this.Name = "FormDetalleMensaje";
            this.Text = "Detalle del Mensaje";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblTiempoOptimo;
        private System.Windows.Forms.DataGridView dgvResumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dron;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVerInstrucciones;
        private System.Windows.Forms.Button btnVerCalculadora;
        private System.Windows.Forms.Button btnCerrar;
    }
}