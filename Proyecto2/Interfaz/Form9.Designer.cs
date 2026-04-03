namespace Proyecto2
{
    partial class FormMensajes
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
            this.dgvMensajes = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantInstrucciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).BeginInit();
            this.SuspendLayout();

            // dgvMensajes
            this.dgvMensajes.AllowUserToAddRows = false;
            this.dgvMensajes.AllowUserToDeleteRows = false;
            this.dgvMensajes.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMensajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Nombre,
                this.Sistema,
                this.CantInstrucciones,
                this.VerDetalle});
            this.dgvMensajes.Location = new System.Drawing.Point(12, 60);
            this.dgvMensajes.Name = "dgvMensajes";
            this.dgvMensajes.ReadOnly = true;
            this.dgvMensajes.Size = new System.Drawing.Size(560, 250);
            this.dgvMensajes.TabIndex = 0;
            this.dgvMensajes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMensajes_CellClick);

            // Nombre
            this.Nombre.HeaderText = "Nombre del Mensaje";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 180;

            // Sistema
            this.Sistema.HeaderText = "Sistema de Drones";
            this.Sistema.Name = "Sistema";
            this.Sistema.ReadOnly = true;
            this.Sistema.Width = 150;

            // CantInstrucciones
            this.CantInstrucciones.HeaderText = "Instrucciones";
            this.CantInstrucciones.Name = "CantInstrucciones";
            this.CantInstrucciones.ReadOnly = true;
            this.CantInstrucciones.Width = 100;

            // VerDetalle
            this.VerDetalle.HeaderText = "Acción";
            this.VerDetalle.Name = "VerDetalle";
            this.VerDetalle.ReadOnly = true;
            this.VerDetalle.Text = "Ver Detalle";
            this.VerDetalle.UseColumnTextForButtonValue = true;
            this.VerDetalle.Width = 80;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 24);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Listado de Mensajes";

            // btnNuevo
            this.btnNuevo.Location = new System.Drawing.Point(12, 320);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 35);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo Mensaje";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(452, 320);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 35);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // FormMensajes
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 370);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvMensajes);
            this.Name = "FormMensajes";
            this.Text = "Gestión de Mensajes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvMensajes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantInstrucciones;
        private System.Windows.Forms.DataGridViewButtonColumn VerDetalle;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCerrar;
    }
}