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
		CorreoNotificacion correo;

        public VentanaInicio(Conexion con)
		{
			this.cone = con;
			this.empleadoDao= new EmpleadoDao();
			this.correo= new CorreoNotificacion();
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
			claveA = contrasenia.Text;
			Empleado emp = new Empleado();

			bool login = empleadoDao.login(loginA, claveA);
			
			if (login)
			{
				if (loginA == "1")
				{
					PrincipalTesorero principal = new PrincipalTesorero();
					principal.Show();
				}else if(loginA == "2")
				{
					PrincipalAdmin principal = new PrincipalAdmin(cone);	
					principal.Show();
				}
				else
				{
                    PrincipalEmpleado principalEmpl = new PrincipalEmpleado(cone, loginA);
                    principalEmpl.Show();
                    MessageBox.Show("Usuario si encontrado");
                }
                
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
