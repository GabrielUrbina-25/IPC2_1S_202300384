namespace Proyecto2
{
    partial class FormNuevoSistema
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
            this.lblAlturaMax = new System.Windows.Forms.Label();
            this.numAlturaMax = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDrones = new System.Windows.Forms.Label();
            this.cmbDrones = new System.Windows.Forms.ComboBox();
            this.btnAgregarDron = new System.Windows.Forms.Button();
            this.dgvDronesSistema = new System.Windows.Forms.DataGridView();
            this.Dron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAlturaMax)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDronesSistema)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(230, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Sistema de Drones";

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

            // lblAlturaMax
            this.lblAlturaMax.AutoSize = true;
            this.lblAlturaMax.Location = new System.Drawing.Point(12, 85);
            this.lblAlturaMax.Name = "lblAlturaMax";
            this.lblAlturaMax.Size = new System.Drawing.Size(82, 13);
            this.lblAlturaMax.TabIndex = 3;
            this.lblAlturaMax.Text = "Altura Máxima:";

            // numAlturaMax
            this.numAlturaMax.Location = new System.Drawing.Point(100, 83);
            this.numAlturaMax.Maximum = new decimal(new int[] {
                100,
                0,
                0,
                0});
            this.numAlturaMax.Minimum = new decimal(new int[] {
                1,
                0,
                0,
                0});
            this.numAlturaMax.Name = "numAlturaMax";
            this.numAlturaMax.Size = new System.Drawing.Size(80, 20);
            this.numAlturaMax.TabIndex = 4;
            this.numAlturaMax.Value = new decimal(new int[] {
                8,
                0,
                0,
                0});

            // groupBox1
            this.groupBox1.Controls.Add(this.dgvDronesSistema);
            this.groupBox1.Controls.Add(this.btnAgregarDron);
            this.groupBox1.Controls.Add(this.cmbDrones);
            this.groupBox1.Controls.Add(this.lblDrones);
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 250);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración de Drones";

            // lblDrones
            this.lblDrones.AutoSize = true;
            this.lblDrones.Location = new System.Drawing.Point(15, 30);
            this.lblDrones.Name = "lblDrones";
            this.lblDrones.Size = new System.Drawing.Size(89, 13);
            this.lblDrones.TabIndex = 0;
            this.lblDrones.Text = "Dron disponible:";

            // cmbDrones
            this.cmbDrones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrones.FormattingEnabled = true;
            this.cmbDrones.Location = new System.Drawing.Point(110, 27);
            this.cmbDrones.Name = "cmbDrones";
            this.cmbDrones.Size = new System.Drawing.Size(200, 21);
            this.cmbDrones.TabIndex = 1;

            // btnAgregarDron
            this.btnAgregarDron.Location = new System.Drawing.Point(320, 25);
            this.btnAgregarDron.Name = "btnAgregarDron";
            this.btnAgregarDron.Size = new System.Drawing.Size(120, 25);
            this.btnAgregarDron.TabIndex = 2;
            this.btnAgregarDron.Text = "Agregar al Sistema";
            this.btnAgregarDron.UseVisualStyleBackColor = true;
            this.btnAgregarDron.Click += new System.EventHandler(this.btnAgregarDron_Click);

            // dgvDronesSistema
            this.dgvDronesSistema.AllowUserToAddRows = false;
            this.dgvDronesSistema.AllowUserToDeleteRows = false;
            this.dgvDronesSistema.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDronesSistema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Dron,
                this.Accion});
            this.dgvDronesSistema.Location = new System.Drawing.Point(15, 60);
            this.dgvDronesSistema.Name = "dgvDronesSistema";
            this.dgvDronesSistema.ReadOnly = true;
            this.dgvDronesSistema.Size = new System.Drawing.Size(425, 175);
            this.dgvDronesSistema.TabIndex = 3;
            this.dgvDronesSistema.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDronesSistema_CellClick);

            // Dron
            this.Dron.HeaderText = "Nombre del Dron";
            this.Dron.Name = "Dron";
            this.Dron.ReadOnly = true;
            this.Dron.Width = 250;

            // Accion
            this.Accion.HeaderText = "Configurar Alturas";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Text = "Configurar";
            this.Accion.UseColumnTextForButtonValue = true;
            this.Accion.Width = 120;

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(12, 385);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Sistema";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(352, 385);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 35);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FormNuevoSistema
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 435);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numAlturaMax);
            this.Controls.Add(this.lblAlturaMax);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormNuevoSistema";
            this.Text = "Nuevo Sistema de Drones";
            ((System.ComponentModel.ISupportInitialize)(this.numAlturaMax)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDronesSistema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblAlturaMax;
        private System.Windows.Forms.NumericUpDown numAlturaMax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDrones;
        private System.Windows.Forms.ComboBox cmbDrones;
        private System.Windows.Forms.Button btnAgregarDron;
        private System.Windows.Forms.DataGridView dgvDronesSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dron;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}