
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{

	public partial class PrincipalEmpleado : Form
	{
		string nombreUsuario;
		Conexion cone;
		EmpleadoDao empleadoDao;
		Empleado empleado;
        UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();

		public PrincipalEmpleado(Conexion cone)
		{
            empleadoDao = new EmpleadoDao(cone);
            InitializeComponent();
			instanciarSingleton();
			
		}
		void instanciarSingleton()
		{
                empleado = empleadoDao.hallarEmpleadoPorCuenta(nombreUsuario);
                UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();
                usuario.establecerUsuario(empleado);

        }
        void Label1Click(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			CRUDSolicitud solitud= new CRUDSolicitud(cone);
			solitud.Show();
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
