
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{

	public partial class PrincipalEmpleado : Form
	{
		string nombreUsuario;
		Conexion cone = Conexion.Instancia;
		EmpleadoDao empleadoDao;
		Empleado empleado;
        UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();

		public PrincipalEmpleado( string nombreUusario)
		{
            empleadoDao = new EmpleadoDao();
			this.empleado= empleadoDao.buscarEmpleado(nombreUusario);
            InitializeComponent();
			instanciarSingleton();
			
		}
		void instanciarSingleton()
		{
                UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();
                usuario.establecerUsuario(empleado);

        }
        void Label1Click(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			CRUDSolicitud solitud= new CRUDSolicitud();
			solitud.Show();
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Nombre empleado: " + UsuarioSesion.obtenerInstancia().empleado.getNombreEmpleado());
        }
    }
}
