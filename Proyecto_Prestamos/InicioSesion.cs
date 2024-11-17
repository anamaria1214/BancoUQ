using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
	public partial class VentanaInicio : Form
	{
		Conexion cone;
		EmpleadoDao empleadoDao;
		Empleado empleado;
        UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();

        public VentanaInicio(Conexion con)
		{
			cone = con;
			this.empleadoDao= new EmpleadoDao(cone);
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
			string loginA, claveA;
			loginA = idUsuario.Text;
			claveA= contrasenia.Text;

			bool login = empleadoDao.login(loginA, claveA);
			if (login)
			{
                PrincipalEmpleado principalEmpl = new PrincipalEmpleado(cone, loginA);
				principalEmpl.Show();
				MessageBox.Show("Usuario si encontrado");
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
