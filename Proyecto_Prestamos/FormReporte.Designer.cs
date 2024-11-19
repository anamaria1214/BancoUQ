namespace Proyecto_Prestamos
{
    partial class FormReporte
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnCargarClick = new System.Windows.Forms.Button();
            this.BtnExportarClick = new System.Windows.Forms.Button();
            this.BtnReporteMorosos = new System.Windows.Forms.Button();
            this.BtnTotalPrestadoSucursal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(769, 429);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnCargarClick
            // 
            this.BtnCargarClick.Location = new System.Drawing.Point(45, 473);
            this.BtnCargarClick.Name = "BtnCargarClick";
            this.BtnCargarClick.Size = new System.Drawing.Size(150, 34);
            this.BtnCargarClick.TabIndex = 1;
            this.BtnCargarClick.Text = "REPORTE 1";
            this.BtnCargarClick.UseVisualStyleBackColor = true;
            this.BtnCargarClick.Click += new System.EventHandler(this.BtnCargarClick_Click);
            // 
            // BtnExportarClick
            // 
            this.BtnExportarClick.Location = new System.Drawing.Point(700, 473);
            this.BtnExportarClick.Name = "BtnExportarClick";
            this.BtnExportarClick.Size = new System.Drawing.Size(114, 34);
            this.BtnExportarClick.TabIndex = 2;
            this.BtnExportarClick.Text = "PDF";
            this.BtnExportarClick.UseVisualStyleBackColor = true;
            this.BtnExportarClick.Click += new System.EventHandler(this.BtnExportarClick_Click);
            // 
            // BtnReporteMorosos
            // 
            this.BtnReporteMorosos.Location = new System.Drawing.Point(232, 473);
            this.BtnReporteMorosos.Name = "BtnReporteMorosos";
            this.BtnReporteMorosos.Size = new System.Drawing.Size(150, 34);
            this.BtnReporteMorosos.TabIndex = 3;
            this.BtnReporteMorosos.Text = "REPORTE 2";
            this.BtnReporteMorosos.UseVisualStyleBackColor = true;
            this.BtnReporteMorosos.Click += new System.EventHandler(this.BtnReporteMorosos_Click);
            // 
            // BtnTotalPrestadoSucursal
            // 
            this.BtnTotalPrestadoSucursal.Location = new System.Drawing.Point(422, 473);
            this.BtnTotalPrestadoSucursal.Name = "BtnTotalPrestadoSucursal";
            this.BtnTotalPrestadoSucursal.Size = new System.Drawing.Size(150, 34);
            this.BtnTotalPrestadoSucursal.TabIndex = 4;
            this.BtnTotalPrestadoSucursal.Text = "REPORTE 3";
            this.BtnTotalPrestadoSucursal.UseVisualStyleBackColor = true;
            this.BtnTotalPrestadoSucursal.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 549);
            this.Controls.Add(this.BtnTotalPrestadoSucursal);
            this.Controls.Add(this.BtnReporteMorosos);
            this.Controls.Add(this.BtnExportarClick);
            this.Controls.Add(this.BtnCargarClick);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormReporte";
            this.Text = "FormReporte";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnCargarClick;
        private System.Windows.Forms.Button BtnExportarClick;
        private System.Windows.Forms.Button BtnReporteMorosos;
        private System.Windows.Forms.Button BtnTotalPrestadoSucursal;
    }
}