namespace Proyecto2
{
    partial class FormDetalleSistema
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
            this.lblAlturaMax = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dgvMatriz = new System.Windows.Forms.DataGridView();
            this.btnGenerarGraphviz = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriz)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(12, 15);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Sistema:";

            // lblAlturaMax
            this.lblAlturaMax.AutoSize = true;
            this.lblAlturaMax.Location = new System.Drawing.Point(12, 45);
            this.lblAlturaMax.Name = "lblAlturaMax";
            this.lblAlturaMax.Size = new System.Drawing.Size(85, 13);
            this.lblAlturaMax.TabIndex = 1;
            this.lblAlturaMax.Text = "Altura Máxima:";

            // lblCantidad
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 70);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(100, 13);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad Drones:";

            // dgvMatriz
            this.dgvMatriz.AllowUserToAddRows = false;
            this.dgvMatriz.AllowUserToDeleteRows = false;
            this.dgvMatriz.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatriz.Location = new System.Drawing.Point(12, 100);
            this.dgvMatriz.Name = "dgvMatriz";
            this.dgvMatriz.ReadOnly = true;
            this.dgvMatriz.Size = new System.Drawing.Size(560, 250);
            this.dgvMatriz.TabIndex = 3;

            // btnGenerarGraphviz
            this.btnGenerarGraphviz.Location = new System.Drawing.Point(12, 360);
            this.btnGenerarGraphviz.Name = "btnGenerarGraphviz";
            this.btnGenerarGraphviz.Size = new System.Drawing.Size(150, 35);
            this.btnGenerarGraphviz.TabIndex = 4;
            this.btnGenerarGraphviz.Text = "Generar Gráfica Graphviz";
            this.btnGenerarGraphviz.UseVisualStyleBackColor = true;
            this.btnGenerarGraphviz.Click += new System.EventHandler(this.btnGenerarGraphviz_Click);

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(422, 360);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 35);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // groupBox1
            this.groupBox1.Location = new System.Drawing.Point(6, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 270);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matriz de Configuración";

            // FormDetalleSistema
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 410);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGenerarGraphviz);
            this.Controls.Add(this.dgvMatriz);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblAlturaMax);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDetalleSistema";
            this.Text = "Detalle del Sistema de Drones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriz)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblAlturaMax;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView dgvMatriz;
        private System.Windows.Forms.Button btnGenerarGraphviz;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}