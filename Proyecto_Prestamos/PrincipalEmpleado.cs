
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

		public PrincipalEmpleado(Conexion cone1, string nombreUusario)
		{
            this.cone = cone1;
            empleadoDao = new EmpleadoDao(cone1);
			this.empleado= empleadoDao.buscarEmpleado(nombreUusario);
            InitializeComponent();
			instanciarSingleton(nombreUusario);
			
		}
		void instanciarSingleton(string nombreUusario)
		{
                UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();
                usuario.establecerUsuario(empleado);
                usuario.establecerCuenta(nombreUusario);
                usuario.establecerFechaInicio(DateTime.Now);

        }
        void Label1Click(object sender, EventArgs e)
		{
	
		}
		void Button1Click(object sender, EventArgs e)
		{
			CRUDSolicitud solitud= new CRUDSolicitud(this.cone);
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
            String consulta = "Insert into Auditoria (idAuditoria, nombreCuenta, fechaIngreso, fechaSalida) " +
                      "Values (@idAuditoria, @nombreCuenta, @fechaIngreso, @fechaSalida)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(consulta, cone.getCon()))
                {
                    // Agregar los parámetros a la consulta
                    cmd.Parameters.AddWithValue("@idAuditoria", generarCadenaRandom(7));
                    cmd.Parameters.AddWithValue("@nombreCuenta", UsuarioSesion.obtenerInstancia().cuenta);
                    cmd.Parameters.AddWithValue("@fechaIngreso", UsuarioSesion.obtenerInstancia().fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaSalida", DateTime.Now);

                    // Ejecutar la consulta
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cerró sesión", "Atención!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar sesión: " + ex.Message, "Error");
            }
        }

        private void LlenarDataGridView()
        {
            // Obtén la lista de préstamos
            //List<Prestamo> prestamos = ObtenerPrestamosPorEmpleado(UsuarioSesion.obtenerInstancia().empleado.getIdEmpleado());

            // Asigna la lista al DataGridView
            //tablaPrestamos.DataSource = prestamos;
        }

        public static string generarCadenaRandom(int longitud)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] resultado = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                resultado[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(resultado);
        }

        /*private List<Prestamo> ObtenerPrestamosPorEmpleado(string idEmpleado)
        {
            string consulta= "SELECT * FROM Prestamo where id"
        }*/
    }
}
