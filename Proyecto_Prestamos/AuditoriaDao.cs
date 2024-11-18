using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class AuditoriaDao
    {
        private Conexion cone = Conexion.Instancia;

        public AuditoriaDao()
        {

        }
        public List<Auditoria> ObtenerAuditorias()
        {
            List<Auditoria> auditorias = new List<Auditoria>();
            string consulta = "SELECT idAuditoria, nombreCuenta, fechaIngreso, fechaSalida FROM Auditoria";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Mapear los valores obtenidos al objeto Auditoria
                    string idCuenta = reader.GetString(1); // nombreCuenta
                    // nombreCuenta o equivalente a nombreEmpleado
                    DateTime fechaIngreso = reader.GetDateTime(2); // fechaIngreso
                    DateTime fechaSalida = reader.GetDateTime(3); // fechaSalida

                    // Crear una nueva instancia de Auditoria y agregarla a la lista
                    Auditoria auditoria = new Auditoria(idCuenta, UsuarioSesion.obtenerInstancia().empleado.getNombreEmpleado(), fechaIngreso, fechaSalida);
                    auditorias.Add(auditoria);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener auditorías: " + ex.Message, "Error");
            }

            return auditorias;
        }
    }
    

}
