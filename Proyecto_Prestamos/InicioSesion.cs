using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
	public partial class VentanaInicio : Form
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
		void IngresarClick()
		{
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
			}
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
