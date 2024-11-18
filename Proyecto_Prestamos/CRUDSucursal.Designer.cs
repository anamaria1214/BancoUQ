/*
 * Created by SharpDevelop.
 * User: ANAMARIA
 * Date: 28/10/2024
 * Time: 8:36 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Proyecto_Prestamos
{
	partial class CRUDSucursal
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
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		
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
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(339, 61);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(109, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "SUCURSAL";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "ID de la sucursal:";
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 116);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(339, 20);
			this.textBox1.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 151);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Nombre de la sucursal:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(12, 177);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(339, 20);
			this.textBox2.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 213);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(142, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Dirección de la sucursal:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(12, 239);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(339, 20);
			this.textBox3.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 272);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(142, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Municipio de la sucursal:";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 298);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(339, 21);
			this.comboBox1.TabIndex = 8;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 339);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Agregar";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(142, 339);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 10;
			this.button2.Text = "Editar";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(276, 339);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 11;
			this.button3.Text = "Eliminar";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// CRUDSucursal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 388);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Name = "CRUDSucursal";
			this.Text = "CRUDSucursal";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

<<<<<<< HEAD
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
            this.label2 = new System.Windows.Forms.Label();
            this.idSucursal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nombreSucursal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMunicipio = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.direccionSucursal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CRUD Sucursal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID de la sucursal: ";
            // 
            // idSucursal
            // 
            this.idSucursal.Location = new System.Drawing.Point(15, 115);
            this.idSucursal.Name = "idSucursal";
            this.idSucursal.Size = new System.Drawing.Size(317, 20);
            this.idSucursal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre de la sucursal: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // nombreSucursal
            // 
            this.nombreSucursal.Location = new System.Drawing.Point(12, 188);
            this.nombreSucursal.Name = "nombreSucursal";
            this.nombreSucursal.Size = new System.Drawing.Size(320, 20);
            this.nombreSucursal.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dirección de la sucursal: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Municipio: ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboBoxMunicipio
            // 
            this.comboBoxMunicipio.FormattingEnabled = true;
            this.comboBoxMunicipio.Location = new System.Drawing.Point(12, 327);
            this.comboBoxMunicipio.Name = "comboBoxMunicipio";
            this.comboBoxMunicipio.Size = new System.Drawing.Size(317, 21);
            this.comboBoxMunicipio.TabIndex = 8;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 369);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(147, 23);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(182, 369);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(147, 23);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(93, 398);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(147, 23);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // direccionSucursal
            // 
            this.direccionSucursal.Location = new System.Drawing.Point(12, 261);
            this.direccionSucursal.Name = "direccionSucursal";
            this.direccionSucursal.Size = new System.Drawing.Size(317, 20);
            this.direccionSucursal.TabIndex = 12;
            // 
            // CRUDSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 433);
            this.Controls.Add(this.direccionSucursal);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.comboBoxMunicipio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nombreSucursal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idSucursal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "CRUDSucursal";
            this.Text = "CRUDSucursal";
            this.Load += new System.EventHandler(this.CRUDSucursal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void direccionSucursal_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nombreSucursal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMunicipio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox direccionSucursal;
    }
}
=======
		}
	}
}
>>>>>>> galvis
