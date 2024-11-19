﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Proyecto_Prestamos
{
    public partial class MainForm : Form
    {
        private FormEmpleado fe; // Formulario para gestionar empleados
        private Conexion conecte; // Objeto de conexión a la base de datos
        
        // Método para obtener la conexión a la base de datos
        public Conexion getConecte()
        {
            return conecte;
        }

        // Constructor de la clase MainForm
        public MainForm()
        {
            conecte = new Conexion(); // Inicializa la conexión
            InitializeComponent();
        }

   

        // Método para salir de la aplicación y cerrar la conexión
        void SalirToolStripMenuItemClick(object sender, EventArgs e)
        {
            conecte.getCon().Close(); // Cierra la conexión
            MessageBox.Show("Cerrando la aplicación...");
            Application.Exit(); // Cierra la aplicación
        }
    }
}
