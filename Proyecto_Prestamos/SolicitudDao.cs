using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms; // Incluido si necesitas usar MessageBox

namespace Proyecto_Prestamos
{
    public class SolicitudDao
    {
        private string connectionString = "Data Source=servidor;Initial Catalog=nombre_base_datos;User ID=usuario;Password=contraseña";

        public bool agregarSolicitud(Solicitud solicitud)
        {
            bool resultado = false;

            string consulta = "INSERT INTO Solicitud (idSolicitud, estado, idEmpleado, monto, periodoMeses, fechaSolicitud) " +
                              "VALUES (@idSolicitud, @estado, @idEmpleado, @monto, @periodoMeses, @fechaSolicitud)";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@idSolicitud", solicitud.GetIdSolicitud());
                    cmd.Parameters.AddWithValue("@estado", solicitud.GetEstado());
                    cmd.Parameters.AddWithValue("@idEmpleado", solicitud.GetIdEmpleado());
                    cmd.Parameters.AddWithValue("@monto", solicitud.GetMonto());
                    cmd.Parameters.AddWithValue("@periodoMeses", solicitud.GetPeriodoMeses());
                    cmd.Parameters.AddWithValue("@fechaSolicitud", solicitud.fechaSolicitud);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Solicitud agregada exitosamente", "Atención!");
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar una solicitud: " + ex.Message, "Error");
            }

            return resultado;
        }

        public string obtenerSolicitudes()
        {
            string solicitudes = "";
            string consulta = "SELECT * FROM Solicitud";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        solicitudes += $"{reader.GetString(0)} {reader.GetString(1)}\n";
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar las solicitudes: " + ex.Message, "Error");
            }

            return solicitudes;
        }

        public bool eliminarSolicitud(string idSolicitud)
        {
            bool resultado = false;
            string consulta = "DELETE FROM Solicitud WHERE idSolicitud = @idSolicitud";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);
                    cmd.ExecuteNonQuery();
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la solicitud: " + ex.Message, "Error");
            }

            return resultado;
        }

        public Solicitud obtenerSolicitudPorId(string idSolicitud)
        {
            Solicitud solicitud = null;
            string consulta = "SELECT * FROM Solicitud WHERE idSolicitud = @idSolicitud";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        string id = reader.GetString(0);
                        string estado = reader.GetString(1);
                        string idEmpleado = reader.GetString(2);
                        decimal monto = reader.GetDecimal(3);
                        int periodoMeses = reader.GetInt32(4);
                        DateTime fechaSolicitud = reader.GetDateTime(5);

                        solicitud = new Solicitud(id, estado, idEmpleado, monto, periodoMeses, fechaSolicitud);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la solicitud: " + ex.Message, "Error");
            }

            return solicitud;
        }

        public List<Solicitud> obtenerSolicitudesPorEstado(string estado)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            string consulta = "SELECT * FROM Solicitud WHERE estado = @estado";

            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string estadoDb = reader.GetString(1);
                        string idEmpleado = reader.GetString(2);
                        decimal monto = reader.GetDecimal(3);
                        int periodoMeses = reader.GetInt32(4);
                        DateTime fechaSolicitud = reader.GetDateTime(5);

                        Solicitud solicitud = new Solicitud(id, estadoDb, idEmpleado, monto, periodoMeses, fechaSolicitud);
                        solicitudes.Add(solicitud);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar solicitudes por estado: " + ex.Message, "Error");
            }

            return solicitudes;
        }
    }
}
