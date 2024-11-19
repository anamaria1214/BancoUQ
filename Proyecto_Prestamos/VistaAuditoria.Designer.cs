namespace Proyecto_Prestamos
{
    partial class VistaAuditoria
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tablaAuditoria = new System.Windows.Forms.DataGridView();
            this.empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAuditoria)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 56);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(158, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auditoría";
            // 
            // tablaAuditoria
            // 
            this.tablaAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAuditoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empleado,
            this.fechaEntrada,
            this.fechaSalida,
            this.numCuenta});
            this.tablaAuditoria.Location = new System.Drawing.Point(12, 83);
            this.tablaAuditoria.Name = "tablaAuditoria";
            this.tablaAuditoria.Size = new System.Drawing.Size(425, 232);
            this.tablaAuditoria.TabIndex = 2;
            this.tablaAuditoria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // empleado
            // 
            this.empleado.HeaderText = "Empleado";
            this.empleado.Name = "empleado";
            // 
            // fechaEntrada
            // 
            this.fechaEntrada.HeaderText = "Fecha de entrada";
            this.fechaEntrada.Name = "fechaEntrada";
            // 
            // fechaSalida
            // 
            this.fechaSalida.HeaderText = "Fecha de entrada";
            this.fechaSalida.Name = "fechaSalida";
            // 
            // numCuenta
            // 
            this.numCuenta.HeaderText = "Cuenta";
            this.numCuenta.Name = "numCuenta";
            // 
            // VistaAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 327);
            this.Controls.Add(this.tablaAuditoria);
            this.Controls.Add(this.panel1);
            this.Name = "VistaAuditoria";
            this.Text = "VistaAuditoria";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablaAuditoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tablaAuditoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn numCuenta;
    }
}