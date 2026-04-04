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
            lblTitulo = new Label();
            btnInicializar = new Button();
            btnCargarXML = new Button();
            btnGestionDrones = new Button();
            btnGestionSistemas = new Button();
            btnGestionMensajes = new Button();
            btnGenerarXML = new Button();
            btnReportes = new Button();
            btnAyuda = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(143, 32);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(215, 26);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Drones";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnInicializar
            // 
            btnInicializar.Font = new Font("Microsoft Sans Serif", 10F);
            btnInicializar.Location = new Point(117, 92);
            btnInicializar.Margin = new Padding(4, 3, 4, 3);
            btnInicializar.Name = "btnInicializar";
            btnInicializar.Size = new Size(257, 46);
            btnInicializar.TabIndex = 2;
            btnInicializar.Text = "Inicializar Sistema";
            btnInicializar.UseVisualStyleBackColor = true;
            btnInicializar.Click += btnInicializar_Click;
            // 
            // btnCargarXML
            // 
            btnCargarXML.Font = new Font("Microsoft Sans Serif", 10F);
            btnCargarXML.Location = new Point(117, 150);
            btnCargarXML.Margin = new Padding(4, 3, 4, 3);
            btnCargarXML.Name = "btnCargarXML";
            btnCargarXML.Size = new Size(257, 46);
            btnCargarXML.TabIndex = 3;
            btnCargarXML.Text = "Cargar Archivo XML de Entrada";
            btnCargarXML.UseVisualStyleBackColor = true;
            btnCargarXML.Click += btnCargarXML_Click;
            // 
            // btnGestionDrones
            // 
            btnGestionDrones.Font = new Font("Microsoft Sans Serif", 10F);
            btnGestionDrones.Location = new Point(117, 208);
            btnGestionDrones.Margin = new Padding(4, 3, 4, 3);
            btnGestionDrones.Name = "btnGestionDrones";
            btnGestionDrones.Size = new Size(257, 46);
            btnGestionDrones.TabIndex = 4;
            btnGestionDrones.Text = "Gestión de Drones";
            btnGestionDrones.UseVisualStyleBackColor = true;
            btnGestionDrones.Click += btnGestionDrones_Click;
            // 
            // btnGestionSistemas
            // 
            btnGestionSistemas.Font = new Font("Microsoft Sans Serif", 10F);
            btnGestionSistemas.Location = new Point(117, 265);
            btnGestionSistemas.Margin = new Padding(4, 3, 4, 3);
            btnGestionSistemas.Name = "btnGestionSistemas";
            btnGestionSistemas.Size = new Size(257, 46);
            btnGestionSistemas.TabIndex = 5;
            btnGestionSistemas.Text = "Gestión de Sistemas de Drones";
            btnGestionSistemas.UseVisualStyleBackColor = true;
            btnGestionSistemas.Click += btnGestionSistemas_Click;
            // 
            // btnGestionMensajes
            // 
            btnGestionMensajes.Font = new Font("Microsoft Sans Serif", 10F);
            btnGestionMensajes.Location = new Point(117, 323);
            btnGestionMensajes.Margin = new Padding(4, 3, 4, 3);
            btnGestionMensajes.Name = "btnGestionMensajes";
            btnGestionMensajes.Size = new Size(257, 46);
            btnGestionMensajes.TabIndex = 6;
            btnGestionMensajes.Text = "Gestión de Mensajes";
            btnGestionMensajes.UseVisualStyleBackColor = true;
            btnGestionMensajes.Click += btnGestionMensajes_Click;
            // 
            // btnGenerarXML
            // 
            btnGenerarXML.Font = new Font("Microsoft Sans Serif", 10F);
            btnGenerarXML.ForeColor = Color.DarkGreen;
            btnGenerarXML.Location = new Point(117, 381);
            btnGenerarXML.Margin = new Padding(4, 3, 4, 3);
            btnGenerarXML.Name = "btnGenerarXML";
            btnGenerarXML.Size = new Size(257, 46);
            btnGenerarXML.TabIndex = 7;
            btnGenerarXML.Text = "Generar Archivo XML de Salida";
            btnGenerarXML.UseVisualStyleBackColor = true;
            btnGenerarXML.Click += btnGenerarXML_Click;
            // 
            // btnReportes
            // 
            btnReportes.Font = new Font("Microsoft Sans Serif", 10F);
            btnReportes.Location = new Point(117, 438);
            btnReportes.Margin = new Padding(4, 3, 4, 3);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(257, 46);
            btnReportes.TabIndex = 8;
            btnReportes.Text = "Reportes Consolidados";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnAyuda
            // 
            btnAyuda.Font = new Font("Microsoft Sans Serif", 10F);
            btnAyuda.Location = new Point(117, 496);
            btnAyuda.Margin = new Padding(4, 3, 4, 3);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Size = new Size(257, 46);
            btnAyuda.TabIndex = 9;
            btnAyuda.Text = "Ayuda / Acerca de";
            btnAyuda.UseVisualStyleBackColor = true;
            btnAyuda.Click += btnAyuda_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.LightCoral;
            btnSalir.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnSalir.Location = new Point(117, 565);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(257, 52);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(490, 646);
            Controls.Add(btnSalir);
            Controls.Add(btnAyuda);
            Controls.Add(btnReportes);
            Controls.Add(btnGenerarXML);
            Controls.Add(btnGestionMensajes);
            Controls.Add(btnGestionSistemas);
            Controls.Add(btnGestionDrones);
            Controls.Add(btnCargarXML);
            Controls.Add(btnInicializar);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proyecto 2 - IPC2 - Sistema de Drones";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnInicializar;
        private System.Windows.Forms.Button btnCargarXML;
        private System.Windows.Forms.Button btnGestionDrones;
        private System.Windows.Forms.Button btnGestionSistemas;
        private System.Windows.Forms.Button btnGestionMensajes;
        private System.Windows.Forms.Button btnGenerarXML;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button btnSalir;

    }
}