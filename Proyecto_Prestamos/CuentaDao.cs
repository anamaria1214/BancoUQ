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
    internal class CuentaDao
    {

        private Conexion cone;

        public CuentaDao(Conexion cone)
        {
            this.cone = cone;
        }

        public void agregarCuenta(Cuenta cuenta)
        {
            try
            {
                string consulta = "INSERT INTO CuentaUsuario (idCuentaUsuario, nombreUsuario, contraseña, idTipo) " +
                                  "VALUES (@idCuentaUsuario, @nombreUsuario, @contraseña, @idTipo)";

                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.Parameters.AddWithValue("@idCuentaUsuario", cuenta.IdCuentaUsuario);
                cmd.Parameters.AddWithValue("@nombreUsuario", cuenta.NombreUsuario);
                cmd.Parameters.AddWithValue("@contraseña", cuenta.Contraseña);
                //ZSZZZZZ
                // Validar idTipo (puede ser null)
                if (cuenta.IdTipo != null)
                {
                    cmd.Parameters.AddWithValue("@idTipo", cuenta.IdTipo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idTipo", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cuenta agregada exitosamente.", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cuenta: " + ex.Message, "Error");
            }
        }

    }
}
