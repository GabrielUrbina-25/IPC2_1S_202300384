namespace Proyecto2
{
    partial class FormNuevoMensaje
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblSistema = new System.Windows.Forms.Label();
            this.cmbSistema = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminarUltima = new System.Windows.Forms.Button();
            this.dgvInstrucciones = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Altura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Letra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarInstruccion = new System.Windows.Forms.Button();
            this.numAltura = new System.Windows.Forms.NumericUpDown();
            this.lblAltura = new System.Windows.Forms.Label();
            this.cmbDron = new System.Windows.Forms.ComboBox();
            this.lblDron = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrucciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Mensaje";

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 55);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(100, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 20);
            this.txtNombre.TabIndex = 2;

            // lblSistema
            this.lblSistema.AutoSize = true;
            this.lblSistema.Location = new System.Drawing.Point(12, 85);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(47, 13);
            this.lblSistema.TabIndex = 3;
            this.lblSistema.Text = "Sistema:";

            // cmbSistema
            this.cmbSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSistema.FormattingEnabled = true;
            this.cmbSistema.Location = new System.Drawing.Point(100, 82);
            this.cmbSistema.Name = "cmbSistema";
            this.cmbSistema.Size = new System.Drawing.Size(250, 21);
            this.cmbSistema.TabIndex = 4;
            this.cmbSistema.SelectedIndexChanged += new System.EventHandler(this.cmbSistema_SelectedIndexChanged);

            // groupBox1
            this.groupBox1.Controls.Add(this.btnEliminarUltima);
            this.groupBox1.Controls.Add(this.dgvInstrucciones);
            this.groupBox1.Controls.Add(this.btnAgregarInstruccion);
            this.groupBox1.Controls.Add(this.numAltura);
            this.groupBox1.Controls.Add(this.lblAltura);
            this.groupBox1.Controls.Add(this.cmbDron);
            this.groupBox1.Controls.Add(this.lblDron);
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 300);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instrucciones";

            // lblDron
            this.lblDron.AutoSize = true;
            this.lblDron.Location = new System.Drawing.Point(15, 30);
            this.lblDron.Name = "lblDron";
            this.lblDron.Size = new System.Drawing.Size(33, 13);
            this.lblDron.TabIndex = 0;
            this.lblDron.Text = "Dron:";

            // cmbDron
            this.cmbDron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDron.FormattingEnabled = true;
            this.cmbDron.Location = new System.Drawing.Point(80, 27);
            this.cmbDron.Name = "cmbDron";
            this.cmbDron.Size = new System.Drawing.Size(150, 21);
            this.cmbDron.TabIndex = 1;

            // lblAltura
            this.lblAltura.AutoSize = true;
            this.lblAltura.Location = new System.Drawing.Point(250, 30);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(37, 13);
            this.lblAltura.TabIndex = 2;
            this.lblAltura.Text = "Altura:";

            // numAltura
            this.numAltura.Location = new System.Drawing.Point(290, 28);
            this.numAltura.Maximum = new decimal(new int[] {
                100,
                0,
                0,
                0});
            this.numAltura.Minimum = new decimal(new int[] {
                1,
                0,
                0,
                0});
            this.numAltura.Name = "numAltura";
            this.numAltura.Size = new System.Drawing.Size(80, 20);
            this.numAltura.TabIndex = 3;
            this.numAltura.Value = new decimal(new int[] {
                1,
                0,
                0,
                0});

            // btnAgregarInstruccion
            this.btnAgregarInstruccion.Location = new System.Drawing.Point(380, 25);
            this.btnAgregarInstruccion.Name = "btnAgregarInstruccion";
            this.btnAgregarInstruccion.Size = new System.Drawing.Size(80, 25);
            this.btnAgregarInstruccion.TabIndex = 4;
            this.btnAgregarInstruccion.Text = "Agregar";
            this.btnAgregarInstruccion.UseVisualStyleBackColor = true;
            this.btnAgregarInstruccion.Click += new System.EventHandler(this.btnAgregarInstruccion_Click);

            // dgvInstrucciones
            this.dgvInstrucciones.AllowUserToAddRows = false;
            this.dgvInstrucciones.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstrucciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.No,
                this.Dron,
                this.Altura,
                this.Letra});
            this.dgvInstrucciones.Location = new System.Drawing.Point(15, 60);
            this.dgvInstrucciones.Name = "dgvInstrucciones";
            this.dgvInstrucciones.ReadOnly = true;
            this.dgvInstrucciones.Size = new System.Drawing.Size(525, 190);
            this.dgvInstrucciones.TabIndex = 5;

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
            this.Altura.HeaderText = "Altura";
            this.Altura.Name = "Altura";
            this.Altura.ReadOnly = true;
            this.Altura.Width = 100;

            // Letra
            this.Letra.HeaderText = "Letra";
            this.Letra.Name = "Letra";
            this.Letra.ReadOnly = true;
            this.Letra.Width = 100;

            // btnEliminarUltima
            this.btnEliminarUltima.Location = new System.Drawing.Point(15, 260);
            this.btnEliminarUltima.Name = "btnEliminarUltima";
            this.btnEliminarUltima.Size = new System.Drawing.Size(120, 25);
            this.btnEliminarUltima.TabIndex = 6;
            this.btnEliminarUltima.Text = "Eliminar Última";
            this.btnEliminarUltima.UseVisualStyleBackColor = true;
            this.btnEliminarUltima.Click += new System.EventHandler(this.btnEliminarUltima_Click);

            // lblPreview
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreview.ForeColor = System.Drawing.Color.Blue;
            this.lblPreview.Location = new System.Drawing.Point(12, 430);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(68, 17);
            this.lblPreview.TabIndex = 6;
            this.lblPreview.Text = "Preview: ";

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(12, 460);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Mensaje";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(452, 460);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 35);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FormNuevoMensaje
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 510);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbSistema);
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormNuevoMensaje";
            this.Text = "Nuevo Mensaje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstrucciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.ComboBox cmbSistema;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDron;
        private System.Windows.Forms.ComboBox cmbDron;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.NumericUpDown numAltura;
        private System.Windows.Forms.Button btnAgregarInstruccion;
        private System.Windows.Forms.DataGridView dgvInstrucciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dron;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letra;
        private System.Windows.Forms.Button btnEliminarUltima;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}