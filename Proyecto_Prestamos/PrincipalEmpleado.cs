
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
        string selecSolicitud = "";

        public PrincipalEmpleado(Conexion cone1, string nombreUusario)
		{
            this.cone = cone1;
            empleadoDao = new EmpleadoDao(cone1);
			this.empleado= empleadoDao.buscarEmpleado(nombreUusario);
            LlenarDataGridView();
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
            List<Prestamo> prestamos = ObtenerPrestamosPorEmpleado(UsuarioSesion.obtenerInstancia().empleado.getIdEmpleado());

            tablaPrestamos.Rows.Clear();
            foreach (var prestamo in prestamos)
            {
                tablaPrestamos.Rows.Add(
                    prestamo.monto,
                    prestamo.periodoMeses,
                    prestamo.tasaInteres,
                    prestamo.fechaInicio.ToShortDateString(),
                    prestamo.valorCuota,
                    prestamo.idPrestamo
                    );
            }
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = tablaPrestamos.Rows[e.RowIndex];

                selecSolicitud = filaSeleccionada.Cells[5].Value.ToString(); // Por índice
            }
        }

        public List<Prestamo> ObtenerPrestamosPorEmpleado(string idEmpleado)
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            string consulta = @"
                SELECT *
                FROM Prestamo p
                JOIN SolicitudPrestamo s ON p.idSolicitud = s.idSolicitud
                WHERE s.idEmpleado = @idEmpleado";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Mapear los valores obtenidos al objeto Prestamo
                    string idPrestamo = reader.GetString(0); // idPrestamo
                    decimal monto = (decimal)reader.GetDecimal(1); // montoPedido
                    int periodoMeses = reader.GetInt32(2); // periodoMeses
                    decimal tasaInteres = (decimal)reader.GetDecimal(3); // tasaInteres
                    DateTime fechaInicio = reader.GetDateTime(4); // fechaInicio
                    float valorCuota = (float)reader.GetDecimal(5); // valorCuota
                    string idSolicitud = reader.GetString(6); // idSolicitud
                    string empleado = reader.GetString(7); // idEmpleado

                    Prestamo prestamo = new Prestamo(empleado, idSolicitud, valorCuota, monto, tasaInteres, fechaInicio, periodoMeses);
                    prestamos.Add(prestamo);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener préstamos: " + ex.Message, "Error");
            }

            return prestamos;
        }

        private void tablaPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
