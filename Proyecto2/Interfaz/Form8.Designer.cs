namespace Proyecto2
{
    partial class FormConfigurarDron
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
            this.dgvAlturas = new System.Windows.Forms.DataGridView();
            this.Altura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Letra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblInstruccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlturas)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configurar Dron";

            // lblInstruccion
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Location = new System.Drawing.Point(12, 45);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(200, 13);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Ingrese la letra para cada altura (deje vacío si no aplica):";

            // dgvAlturas
            this.dgvAlturas.AllowUserToAddRows = false;
            this.dgvAlturas.AllowUserToDeleteRows = false;
            this.dgvAlturas.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Altura,
                this.Letra});
            this.dgvAlturas.Location = new System.Drawing.Point(12, 70);
            this.dgvAlturas.Name = "dgvAlturas";
            this.dgvAlturas.Size = new System.Drawing.Size(300, 300);
            this.dgvAlturas.TabIndex = 2;

            // Altura
            this.Altura.HeaderText = "Altura (mts)";
            this.Altura.Name = "Altura";
            this.Altura.ReadOnly = true;
            this.Altura.Width = 100;

            // Letra
            this.Letra.HeaderText = "Letra";
            this.Letra.Name = "Letra";
            this.Letra.Width = 150;

            // btnAceptar
            this.btnAceptar.Location = new System.Drawing.Point(12, 385);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(212, 385);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FormConfigurarDron
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 430);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvAlturas);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormConfigurarDron";
            this.Text = "Configurar Alturas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvAlturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Letra;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblInstruccion;
    }
}