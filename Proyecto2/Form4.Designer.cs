namespace Proyecto2
{
    partial class FormSistemas
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
            dgvSistemas = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            AlturaMax = new DataGridViewTextBoxColumn();
            CantDrones = new DataGridViewTextBoxColumn();
            VerDetalle = new DataGridViewButtonColumn();
            VerGrafica = new DataGridViewButtonColumn();
            lblTitulo = new Label();
            btnNuevo = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSistemas).BeginInit();
            SuspendLayout();
            // 
            // dgvSistemas
            // 
            dgvSistemas.AllowUserToAddRows = false;
            dgvSistemas.AllowUserToDeleteRows = false;
            dgvSistemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSistemas.Columns.AddRange(new DataGridViewColumn[] { Nombre, AlturaMax, CantDrones, VerDetalle, VerGrafica });
            dgvSistemas.Location = new Point(14, 69);
            dgvSistemas.Margin = new Padding(4, 3, 4, 3);
            dgvSistemas.Name = "dgvSistemas";
            dgvSistemas.ReadOnly = true;
            dgvSistemas.Size = new Size(653, 288);
            dgvSistemas.TabIndex = 0;
            dgvSistemas.CellClick += dgvSistemas_CellClick;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre del Sistema";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 150;
            // 
            // AlturaMax
            // 
            AlturaMax.HeaderText = "Altura Máxima";
            AlturaMax.Name = "AlturaMax";
            AlturaMax.ReadOnly = true;
            // 
            // CantDrones
            // 
            CantDrones.HeaderText = "Cant. Drones";
            CantDrones.Name = "CantDrones";
            CantDrones.ReadOnly = true;
            // 
            // VerDetalle
            // 
            VerDetalle.HeaderText = "Detalle";
            VerDetalle.Name = "VerDetalle";
            VerDetalle.ReadOnly = true;
            VerDetalle.Text = "Ver";
            VerDetalle.UseColumnTextForButtonValue = true;
            VerDetalle.Width = 80;
            // 
            // VerGrafica
            // 
            VerGrafica.HeaderText = "Gráfica";
            VerGrafica.Name = "VerGrafica";
            VerGrafica.ReadOnly = true;
            VerGrafica.Text = "Graphviz";
            VerGrafica.UseColumnTextForButtonValue = true;
            VerGrafica.Width = 80;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(14, 17);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(196, 24);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Sistemas de Drones";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(14, 369);
            btnNuevo.Margin = new Padding(4, 3, 4, 3);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(140, 40);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "Nuevo Sistema";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(527, 369);
            btnCerrar.Margin = new Padding(4, 3, 4, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(140, 40);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormSistemas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 427);
            Controls.Add(btnCerrar);
            Controls.Add(btnNuevo);
            Controls.Add(lblTitulo);
            Controls.Add(dgvSistemas);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormSistemas";
            Text = "Gestión de Sistemas de Drones";
            ((System.ComponentModel.ISupportInitialize)dgvSistemas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvSistemas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlturaMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantDrones;
        private System.Windows.Forms.DataGridViewButtonColumn VerDetalle;
        private System.Windows.Forms.DataGridViewButtonColumn VerGrafica;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCerrar;
    }
}