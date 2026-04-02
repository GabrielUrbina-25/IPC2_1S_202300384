namespace Proyecto2
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInicializar = new Button();
            btnCargarXML = new Button();
            btnGestionDrones = new Button();
            btnGestionSistemas = new Button();
            btnGestionMensajes = new Button();
            btnAyuda = new Button();
            btnSalir = new Button();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnInicializar
            // 
            btnInicializar.Location = new Point(117, 81);
            btnInicializar.Margin = new Padding(4, 3, 4, 3);
            btnInicializar.Name = "btnInicializar";
            btnInicializar.Size = new Size(233, 46);
            btnInicializar.TabIndex = 1;
            btnInicializar.Text = "Inicializar Sistema";
            btnInicializar.UseVisualStyleBackColor = true;
            btnInicializar.Click += btnInicializar_Click;
            // 
            // btnCargarXML
            // 
            btnCargarXML.Location = new Point(117, 138);
            btnCargarXML.Margin = new Padding(4, 3, 4, 3);
            btnCargarXML.Name = "btnCargarXML";
            btnCargarXML.Size = new Size(233, 46);
            btnCargarXML.TabIndex = 2;
            btnCargarXML.Text = "Cargar Archivo XML";
            btnCargarXML.UseVisualStyleBackColor = true;
            btnCargarXML.Click += btnCargarXML_Click;
            // 
            // btnGestionDrones
            // 
            btnGestionDrones.Location = new Point(117, 196);
            btnGestionDrones.Margin = new Padding(4, 3, 4, 3);
            btnGestionDrones.Name = "btnGestionDrones";
            btnGestionDrones.Size = new Size(233, 46);
            btnGestionDrones.TabIndex = 3;
            btnGestionDrones.Text = "Gestión de Drones";
            btnGestionDrones.UseVisualStyleBackColor = true;
            btnGestionDrones.Click += btnGestionDrones_Click;
            // 
            // btnGestionSistemas
            // 
            btnGestionSistemas.Location = new Point(117, 254);
            btnGestionSistemas.Margin = new Padding(4, 3, 4, 3);
            btnGestionSistemas.Name = "btnGestionSistemas";
            btnGestionSistemas.Size = new Size(233, 46);
            btnGestionSistemas.TabIndex = 4;
            btnGestionSistemas.Text = "Gestión de Sistemas (Fase 2)";
            btnGestionSistemas.UseVisualStyleBackColor = true;
            btnGestionSistemas.Click += btnGestionSistemas_Click;
            // 
            // btnGestionMensajes
            // 
            btnGestionMensajes.Location = new Point(117, 312);
            btnGestionMensajes.Margin = new Padding(4, 3, 4, 3);
            btnGestionMensajes.Name = "btnGestionMensajes";
            btnGestionMensajes.Size = new Size(233, 46);
            btnGestionMensajes.TabIndex = 5;
            btnGestionMensajes.Text = "Gestión de Mensajes (Fase 2)";
            btnGestionMensajes.UseVisualStyleBackColor = true;
            btnGestionMensajes.Click += btnGestionMensajes_Click;
            // 
            // btnAyuda
            // 
            btnAyuda.Location = new Point(117, 369);
            btnAyuda.Margin = new Padding(4, 3, 4, 3);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(233, 46);
            btnAyuda.TabIndex = 6;
            btnAyuda.Text = "Ayuda";
            btnAyuda.UseVisualStyleBackColor = true;
            btnAyuda.Click += btnAyuda_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(117, 438);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(233, 46);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(126, 29);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(215, 26);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Drones";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 519);
            Controls.Add(btnSalir);
            Controls.Add(btnAyuda);
            Controls.Add(btnGestionMensajes);
            Controls.Add(btnGestionSistemas);
            Controls.Add(btnGestionDrones);
            Controls.Add(btnCargarXML);
            Controls.Add(btnInicializar);
            Controls.Add(lblTitulo);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormPrincipal";
            Text = "Proyecto 2 - IPC2";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnInicializar;
        private System.Windows.Forms.Button btnCargarXML;
        private System.Windows.Forms.Button btnGestionDrones;
        private System.Windows.Forms.Button btnGestionSistemas;
        private System.Windows.Forms.Button btnGestionMensajes;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;
    }
}