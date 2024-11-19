using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{

    public class SolicitudDao
    {
        private MainForm mfo;
        private CRUDSolicitud solicitudForm;
        private Conexion cone = Conexion.Instancia;

        public SolicitudDao()
        {
        }

        public bool agregarSolicitud(Solicitud solicitud)
        {
            // Consulta SQL con parámetros
            string consulta = "INSERT INTO SolicitudPrestamo (idSolicitud, montoPedido, periodoMeses, tasaInteres, fechaSolicitud, idEmpleado, idEstado) " +
                              "VALUES (@idSolicitud, @montoPedido, @periodoMeses, @tasaInteres, @fechaSolicitud, @idEmpleado, @idEstado)";
            try
            {
                // Crear comando SQL y asociarlo con la conexión
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());

                // Asignar los valores de los parámetros desde el objeto 'solicitud'
                cmd.Parameters.AddWithValue("@idSolicitud", solicitud.GetIdSolicitud()); // idSolicitud del objeto
                cmd.Parameters.AddWithValue("@montoPedido", solicitud.GetMonto());       // montoPedido del objeto
                cmd.Parameters.AddWithValue("@periodoMeses", solicitud.GetPeriodoMeses()); // periodoMeses del objeto
                cmd.Parameters.AddWithValue("@tasaInteres", solicitud.GetTasaInteres()); // tasaInteres del objeto
                cmd.Parameters.AddWithValue("@fechaSolicitud", solicitud.GetFechaSolicitud()); // fechaSolicitud del objeto
                cmd.Parameters.AddWithValue("@idEmpleado", solicitud.GetIdEmpleado());   // idEmpleado del objeto
                cmd.Parameters.AddWithValue("@idEstado", solicitud.GetEstado());         // idEstado del objeto

                // Ejecutar la consulta
                cmd.ExecuteNonQuery();

                // Mostrar mensaje de éxito
                MessageBox.Show("Solicitud agregada exitosamente", "Atención!");
                return true;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MessageBox.Show("Error al agregar una Solicitud: " + ex.Message, "Error");
                return false;
            }
        }
        public bool eliminarSolicitud(String idSolicitud)
        {
            bool resultado = false;
            string consulta = "Delete from Solicitud where idSolicitud = '" + idSolicitud + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.ExecuteNonQuery();
                resultado = true;
                MessageBox.Show("Solicitud eliminada correctamente");
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
            string consulta = "SELECT * FROM SolicitudPrestamo WHERE idSolicitud = @idSolicitud"; // Usa parámetros para evitar inyecciones SQL
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                // Usamos un parámetro para evitar la inyección SQL
                cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);

                SqlDataReader reader = cmd.ExecuteReader();

                // Asegúrate de mover el cursor al primer registro
                if (reader.Read())
                {
                    string id = reader.GetString(0);  // Suponiendo que el idSolicitud es el primer campo
                    decimal monto = reader.GetDecimal(1);  // Segundo campo
                    int periodoMeses = reader.GetInt32(2);  // Tercer campo
                    decimal tasaInteres = reader.GetDecimal(3);  // Cuarto campo
                    DateTime fechaSolicitud = reader.GetDateTime(4);  // Quinto campo
                    string idEmpleado = reader.GetString(5);  // Sexto campo
                    string estado1 = reader.GetString(6);  // Séptimo campo

                    // Crear el objeto solicitud con los datos obtenidos
                    solicitud = new Solicitud(estado1, idEmpleado, monto, periodoMeses, fechaSolicitud, tasaInteres);
                }

                reader.Close();
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
            string consulta = "SELECT * FROM SolicitudPrestamo WHERE idEstado = @estado";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.Parameters.AddWithValue("@estado", estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string idSolicitud = reader.GetString(0);             // idSolicitud (nvarchar(30))
                    decimal montoPedido = reader.GetDecimal(1);           // montoPedido (decimal(18,2))
                    int periodoMeses = reader.GetInt32(2);                // periodoMeses (int)
                    decimal tasaInteres = reader.GetDecimal(3);           // tasaInteres (decimal(5,2))
                    DateTime fechaSolicitud = reader.GetDateTime(4);      // fechaSolicitud (date)
                    string idEmpleado = reader.GetString(5);              // idEmpleado (nvarchar(10))
                    string idEstado = reader.GetString(6);

                    Solicitud solicitud = new Solicitud(idEstado, idEmpleado, montoPedido, periodoMeses, fechaSolicitud, tasaInteres);
                    solicitud.setId(idSolicitud);
                    solicitudes.Add(solicitud);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la solicitud: " + ex.Message, "Error");
            }

            return solicitudes;
        }

        public bool aprobarSolicitud(string idSolicitud)
        {
            // Consulta SQL: establece idEstado a 2 para la solicitud especificada
            string consulta = "UPDATE SolicitudPrestamo SET idEstado = 2 WHERE idSolicitud = @idSolicitud";

            try
            {
                // Crear el comando SQL
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                // Agregar el parámetro para el ID
                cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);

                // Ejecutar la consulta
                int filasAfectadas = cmd.ExecuteNonQuery();

                // Verificar si se actualizó correctamente
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Estado actualizado correctamente", "Éxito");
                    return true;
                }
                else
                {
                    MessageBox.Show("No se encontró la solicitud con el ID especificado", "Atención");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                MessageBox.Show("Error al actualizar el estado: " + ex.Message, "Error");
                return false;
            }
        }
        public bool rechazarSolicitud(string idSolicitud)
        {
            // Consulta SQL: establece idEstado a 2 para la solicitud especificada
            string consulta = "UPDATE SolicitudPrestamo SET idEstado = 3 WHERE idSolicitud = @idSolicitud";

            try
            {
                // Crear el comando SQL
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                // Agregar el parámetro para el ID
                cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);

                // Ejecutar la consulta
                int filasAfectadas = cmd.ExecuteNonQuery();

                // Verificar si se actualizó correctamente
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Estado actualizado correctamente", "Éxito");
                    return true;
                }
                else
                {
                    MessageBox.Show("No se encontró la solicitud con el ID especificado", "Atención");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                MessageBox.Show("Error al actualizar el estado: " + ex.Message, "Error");
                return false;
            }
        }
    }



}