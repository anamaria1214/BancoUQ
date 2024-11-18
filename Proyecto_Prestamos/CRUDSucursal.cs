<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
=======
﻿/*
 * Created by SharpDevelop.
 * User: ANAMARIA
 * Date: 28/10/2024
 * Time: 8:36 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
>>>>>>> galvis
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
<<<<<<< HEAD
    public partial class CRUDSucursal : Form
    {
        Conexion cone;
        Sucursal sucursal;
        SucursalDao sucursalDao;

        public CRUDSucursal(Conexion cone)
        {
            InitializeComponent();
            this.cone = cone;
            this.sucursalDao = new SucursalDao(cone);
        }

        private void CRUDSucursal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                sucursal = new Sucursal(idSucursal.Text, nombreSucursal.Text, direccionSucursal.Text, "1");
          
                sucursalDao.agregarSucursal(sucursal);
               
            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            sucursalDao.eliminar(idSucursal.Text);

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            sucursal = new Sucursal(idSucursal.Text, nombreSucursal.Text, direccionSucursal.Text, "1");
            sucursalDao.actualizarSucursal(sucursal);
        }

        private void CargarMunicipios()
        {
            try
            {
                using (SqlConnection conn = cone.getCon())
                {
                    conn.Open();
                    string query = "SELECT NombreMunicipio FROM Municipios"; // Cambia el nombre de la tabla según tu diseño
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxMunicipio.Items.Add(reader["NombreMunicipio"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando municipios: {ex.Message}", "Error");
            }
        }
    }
    
=======
	/// <summary>
	/// Description of CRUDSucursal.
	/// </summary>
	public partial class CRUDSucursal : Form
	{
		public CRUDSucursal()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Panel1Paint(object sender, PaintEventArgs e)
		{
	
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void Label2Click(object sender, EventArgs e)
		{
	
		}
	}
>>>>>>> galvis
}
