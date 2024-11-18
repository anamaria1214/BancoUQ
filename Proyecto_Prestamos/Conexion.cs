using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class Conexion
    {
        private SqlConnection con;
        // Instancia estática privada para el patrón Singleton
        private static Conexion instancia;

        // Propiedad pública para acceder a la instancia de la clase
        public static Conexion Instancia
        {
            get
            {
                // Si la instancia es nula, la creamos
                if (instancia == null)
                {
                    instancia = new Conexion();
                }
                return instancia;
            }
        }
        // Método para obtener la conexión a la base de datos
        public SqlConnection getCon()
        {
            return con;
        }
        
        // Constructor de la clase conexión
        public Conexion()
        {
            try
            {
                // Cadena de conexión a tu base de datos SQL Server
                String cadenaConexion = "Data Source=JUANEX-DESKTOP\\SQLEXPRESS;Initial Catalog=BancoUQ;Integrated Security=True";
                con = new SqlConnection(cadenaConexion);
                
                // Abriendo la conexión
                con.Open();
                MessageBox.Show("Conectado a la base de datos", "Atención");
            }
            catch (System.Exception ex)
            {
                // Capturando cualquier error de conexión
                MessageBox.Show("ERROR: " + ex.Message);
            }
            
            MessageBox.Show("Continuando a la Aplicación", "Atención");
        }
        
    }
}
