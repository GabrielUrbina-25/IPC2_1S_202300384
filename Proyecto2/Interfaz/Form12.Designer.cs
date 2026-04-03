namespace Proyecto2
{
    partial class FormCalculadoraTiempo
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
            this.lblTiempoTotal = new System.Windows.Forms.Label();
            this.dgvTimeline = new System.Windows.Forms.DataGridView();
            this.Paso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DurMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoLuz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DurLuz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtExplicacion = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeline)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cálculo de Tiempo Óptimo";

            // lblTiempoTotal
            this.lblTiempoTotal.AutoSize = true;
            this.lblTiempoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTiempoTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTiempoTotal.Location = new System.Drawing.Point(12, 45);
            this.lblTiempoTotal.Name = "lblTiempoTotal";
            this.lblTiempoTotal.Size = new System.Drawing.Size(150, 24);
            this.lblTiempoTotal.TabIndex = 1;
            this.lblTiempoTotal.Text = "Tiempo Total: 0s";

            // dgvTimeline
            this.dgvTimeline.AllowUserToAddRows = false;
            this.dgvTimeline.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Paso,
                this.Dron,
                this.TiempoMov,
                this.Tipo,
                this.Ruta,
                this.DurMov,
                this.TiempoLuz,
                this.DurLuz,
                this.Total});
            this.dgvTimeline.Location = new System.Drawing.Point(12, 80);
            this.dgvTimeline.Name = "dgvTimeline";
            this.dgvTimeline.ReadOnly = true;
            this.dgvTimeline.Size = new System.Drawing.Size(860, 250);
            this.dgvTimeline.TabIndex = 2;

            // Paso
            this.Paso.HeaderText = "Paso";
            this.Paso.Name = "Paso";
            this.Paso.ReadOnly = true;
            this.Paso.Width = 50;

            // Dron
            this.Dron.HeaderText = "Dron";
            this.Dron.Name = "Dron";
            this.Dron.ReadOnly = true;
            this.Dron.Width = 100;

            // TiempoMov
            this.TiempoMov.HeaderText = "Tiempo Mov.";
            this.TiempoMov.Name = "TiempoMov";
            this.TiempoMov.ReadOnly = true;
            this.TiempoMov.Width = 110;

            // Tipo
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 80;

            // Ruta
            this.Ruta.HeaderText = "Ruta";
            this.Ruta.Name = "Ruta";
            this.Ruta.ReadOnly = true;
            this.Ruta.Width = 90;

            // DurMov
            this.DurMov.HeaderText = "Dur.";
            this.DurMov.Name = "DurMov";
            this.DurMov.ReadOnly = true;
            this.DurMov.Width = 50;

            // TiempoLuz
            this.TiempoLuz.HeaderText = "Tiempo Luz";
            this.TiempoLuz.Name = "TiempoLuz";
            this.TiempoLuz.ReadOnly = true;
            this.TiempoLuz.Width = 110;

            // DurLuz
            this.DurLuz.HeaderText = "Dur.";
            this.DurLuz.Name = "DurLuz";
            this.DurLuz.ReadOnly = true;
            this.DurLuz.Width = 50;

            // Total
            this.Total.HeaderText = "Total Paso";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 80;

            // txtExplicacion
            this.txtExplicacion.Location = new System.Drawing.Point(12, 340);
            this.txtExplicacion.Multiline = true;
            this.txtExplicacion.Name = "txtExplicacion";
            this.txtExplicacion.ReadOnly = true;
            this.txtExplicacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExplicacion.Size = new System.Drawing.Size(860, 100);
            this.txtExplicacion.TabIndex = 3;

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(722, 450);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 35);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // FormCalculadoraTiempo
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 496);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtExplicacion);
            this.Controls.Add(this.dgvTimeline);
            this.Controls.Add(this.lblTiempoTotal);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormCalculadoraTiempo";
            this.Text = "Calculadora de Tiempo Óptimo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTiempoTotal;
        private System.Windows.Forms.DataGridView dgvTimeline;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dron;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn DurMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn TiempoLuz;
        private System.Windows.Forms.DataGridViewTextBoxColumn DurLuz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox txtExplicacion;
        private System.Windows.Forms.Button btnCerrar;
    }
}