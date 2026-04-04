namespace Proyecto2.Interfaz
{
    partial class FormGenerarSalida
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
            this.dgvMensajes = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionarTodos = new System.Windows.Forms.Button();
            this.btnDeseleccionarTodos = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Generar XML de Salida";

            // dgvMensajes
            this.dgvMensajes.AllowUserToAddRows = false;
            this.dgvMensajes.AllowUserToDeleteRows = false;
            this.dgvMensajes.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMensajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Seleccionar,
                this.Nombre,
                this.Sistema,
                this.Tiempo,
                this.Mensaje});
            this.dgvMensajes.Location = new System.Drawing.Point(12, 50);
            this.dgvMensajes.Name = "dgvMensajes";
            this.dgvMensajes.Size = new System.Drawing.Size(760, 300);
            this.dgvMensajes.TabIndex = 1;

            // Seleccionar
            this.Seleccionar.HeaderText = "Sel.";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Width = 40;

            // Nombre
            this.Nombre.HeaderText = "Nombre Mensaje";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;

            // Sistema
            this.Sistema.HeaderText = "Sistema Drones";
            this.Sistema.Name = "Sistema";
            this.Sistema.ReadOnly = true;
            this.Sistema.Width = 150;

            // Tiempo
            this.Tiempo.HeaderText = "Tiempo Óptimo";
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.ReadOnly = true;
            this.Tiempo.Width = 120;

            // Mensaje
            this.Mensaje.HeaderText = "Mensaje Decodificado";
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.ReadOnly = true;
            this.Mensaje.Width = 250;

            // btnSeleccionarTodos
            this.btnSeleccionarTodos.Location = new System.Drawing.Point(12, 360);
            this.btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            this.btnSeleccionarTodos.Size = new System.Drawing.Size(120, 30);
            this.btnSeleccionarTodos.TabIndex = 2;
            this.btnSeleccionarTodos.Text = "Seleccionar Todos";
            this.btnSeleccionarTodos.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodos.Click += new System.EventHandler(this.btnSeleccionarTodos_Click);

            // btnDeseleccionarTodos
            this.btnDeseleccionarTodos.Location = new System.Drawing.Point(138, 360);
            this.btnDeseleccionarTodos.Name = "btnDeseleccionarTodos";
            this.btnDeseleccionarTodos.Size = new System.Drawing.Size(140, 30);
            this.btnDeseleccionarTodos.TabIndex = 3;
            this.btnDeseleccionarTodos.Text = "Deseleccionar Todos";
            this.btnDeseleccionarTodos.UseVisualStyleBackColor = true;
            this.btnDeseleccionarTodos.Click += new System.EventHandler(this.btnDeseleccionarTodos_Click);

            // btnGenerar
            this.btnGenerar.Location = new System.Drawing.Point(502, 360);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(130, 30);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar XML";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(642, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FormGenerarSalida
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnDeseleccionarTodos);
            this.Controls.Add(this.btnSeleccionarTodos);
            this.Controls.Add(this.dgvMensajes);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormGenerarSalida";
            this.Text = "Generar Archivo XML de Salida";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvMensajes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensaje;
        private System.Windows.Forms.Button btnSeleccionarTodos;
        private System.Windows.Forms.Button btnDeseleccionarTodos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnCancelar;
    }
}