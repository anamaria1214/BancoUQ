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
        private Conexion cone;

        public SolicitudDao(Conexion cone)
        {
            this.cone = cone;
        }
        public SolicitudDao(MainForm mfo)
        {
            this.mfo = mfo;
        }
        public SolicitudDao(CRUDSolicitud solicitudForm)
        {
            this.solicitudForm = solicitudForm;
        }


        public bool agregarSolicitud(Solicitud solicitud)
        {
            try
            {
                string consulta = "Insert into Solicitud (idSolicitud, montoPedido, periodoMeses,tasaInteres, fechaSolicitud,idEmpleado, idEstado) " +
                    "Values('" + solicitud.GetIdSolicitud() + "','" + solicitud.GetMonto() + 
                    "','" + solicitud.GetPeriodoMeses() + "','" + solicitud.GetTasaInteres() + 
                    ", " + solicitud.GetFechaSolicitud() + ",'" + solicitud.GetIdSolicitud() + 
                    "','"+solicitud.GetEstado()+")";

                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());


                cmd.ExecuteNonQuery();
                MessageBox.Show("Solicitud agregada exitosamente", "Atención!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar una Solicitud: " + ex.Message, "Error");
                return false;
            }
        }

        public string obtenerSolicitudes()
        {
            string solicitudes = "";
            string consulta = "select * from Solicitud where estado= '1'";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        solicitudes += reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + "\n";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar las solicitudes: " + ex.Message, "Error");
            }
            return solicitudes;
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
            string consulta = "SELECT * FROM Solicitud WHERE estado = @estado";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.Parameters.AddWithValue("@estado", estado);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    decimal monto = reader.GetDecimal(3);
                    decimal periodoMeses = reader.GetDecimal(4);
                    decimal tasaInteres = reader.GetDecimal(5);
                    DateTime fechaSolicitud = reader.GetDateTime(5);
                    string idEmpleado = reader.GetString(2);
                    string estado1 = reader.GetString(1);    

                    Solicitud solicitud = new Solicitud(estado1, idEmpleado, monto, periodoMeses, fechaSolicitud, tasaInteres);
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