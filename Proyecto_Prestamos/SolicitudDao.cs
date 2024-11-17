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

        public Solicitud obtenerSolicitudPorId(String idSolicitud)
        {
            Solicitud solicitud = null;
            string consulta = "select * from Solicitud where idSolicitud = '" + idSolicitud + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    string id = reader.GetString(0);
                    decimal monto = reader.GetDecimal(1);
                    decimal periodoMeses = reader.GetDecimal(2);
                    decimal tasaInteres = reader.GetDecimal(3);
                    DateTime fechaSolicitud = reader.GetDateTime(4);
                    string idEmpleado = reader.GetString(5);
                    string estado1 = reader.GetString(6);

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

                    Solicitud solicitud = new Solicitud(idEstado, idEmpleado, montoPedido, periodoMeses, fechaSolicitud, tasaInteres );
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





    }



}