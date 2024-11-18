﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
	public partial class VentanaInicio : Form
	{
		public VentanaInicio()
		{
		Conexion cone= Conexion.Instancia;
		EmpleadoDao empleadoDao;
		Empleado empleado;
		UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();

		public VentanaInicio()
		{

			this.empleadoDao = new EmpleadoDao();
			InitializeComponent();

		}
		void Label1Click(object sender, EventArgs e)
		{

		}
		void Label2Click(object sender, EventArgs e)
		{

		}
		void VentanaInicioLoad(object sender, EventArgs e)
		{

		}
		void IngresarClick(object sender, EventArgs e)
		{
			PrincipalEmpleado principalEmpl= new PrincipalEmpleado();
			principalEmpl.Show();
			string loginA, claveA;
			loginA = idUsuario.Text;
			claveA= contrasenia.Text;

			bool login = empleadoDao.login(loginA, claveA);
			if (login)
			{
                PrincipalEmpleado principalEmpl = new PrincipalEmpleado( loginA);
				principalEmpl.Show();
				MessageBox.Show("Usuario encontrado");
            }
            else
			{
				MessageBox.Show("Usuario no encontrado");
				idUsuario.Clear();
				contrasenia.Clear();
			}		}
	}
}
