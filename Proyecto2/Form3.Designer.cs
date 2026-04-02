namespace Proyecto2
{
    partial class FormDrones
    {
        private System.ComponentModel.IContainer components = null;

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
            this.dgvDrones = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtNombreDron = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblNuevo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrones)).BeginInit();
            this.SuspendLayout();

            // dgvDrones
            this.dgvDrones.AllowUserToAddRows = false;
            this.dgvDrones.AllowUserToDeleteRows = false;
            this.dgvDrones.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Nombre});
            this.dgvDrones.Location = new System.Drawing.Point(12, 50);
            this.dgvDrones.Name = "dgvDrones";
            this.dgvDrones.ReadOnly = true;
            this.dgvDrones.Size = new System.Drawing.Size(300, 200);
            this.dgvDrones.TabIndex = 0;

            // Nombre
            this.Nombre.HeaderText = "Nombre del Dron";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 250;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(156, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Listado de Drones";

            // lblNuevo
            this.lblNuevo.AutoSize = true;
            this.lblNuevo.Location = new System.Drawing.Point(12, 270);
            this.lblNuevo.Name = "lblNuevo";
            this.lblNuevo.Size = new System.Drawing.Size(95, 13);
            this.lblNuevo.TabIndex = 2;
            this.lblNuevo.Text = "Nuevo Dron:";

            // txtNombreDron
            this.txtNombreDron.Location = new System.Drawing.Point(110, 267);
            this.txtNombreDron.Name = "txtNombreDron";
            this.txtNombreDron.Size = new System.Drawing.Size(200, 20);
            this.txtNombreDron.TabIndex = 3;

            // btnAgregar
            this.btnAgregar.Location = new System.Drawing.Point(12, 300);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(145, 30);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar Dron";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(167, 300);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(145, 30);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // FormDrones
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 350);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtNombreDron);
            this.Controls.Add(this.lblNuevo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvDrones);
            this.Name = "FormDrones";
            this.Text = "Gestión de Drones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvDrones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtNombreDron;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblNuevo;
    }
}