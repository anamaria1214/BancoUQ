/*
 * Created by SharpDevelop.
 * User: ANAMARIA
 * Date: 24/09/2024
 * Time: 8:25 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Proyecto_Prestamos
{
	partial class VentanaSolicitud
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label x;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.x = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(369, 68);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Cornsilk;
			this.label1.Location = new System.Drawing.Point(99, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "SOLICITUD";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(13, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(238, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Número de identificación del empleado:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 127);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(368, 20);
			this.textBox1.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 169);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Monto solicitado:";
			this.label3.Click += new System.EventHandler(this.Label3Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 195);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(369, 20);
			this.textBox2.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 237);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Periodo (En meses):";
			this.label4.Click += new System.EventHandler(this.Label4Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
			"24 meses",
			"36 meses",
			"48 meses",
			"60 meses",
			"72 meses"});
			this.comboBox1.Location = new System.Drawing.Point(13, 264);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(368, 21);
			this.comboBox1.TabIndex = 6;
			// 
			// x
			// 
			this.x.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.x.Location = new System.Drawing.Point(12, 307);
			this.x.Name = "x";
			this.x.Size = new System.Drawing.Size(159, 23);
			this.x.TabIndex = 7;
			this.x.Text = "Tasa de interés a pagar:";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(334, 307);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "0.0 %";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(123, 343);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Solicitar Prestamo";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// VentanaSolicitud
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 378);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.x);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Name = "VentanaSolicitud";
			this.Text = "VentanaSolicitud";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
