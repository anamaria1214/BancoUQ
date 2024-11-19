using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class Conexion
    {
        private SqlConnection con;
        
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
                String cadenaConexion = "Data Source=LAPTOP-RAEQ9FJM\\SQLEXPRESS;Initial Catalog=BancoUQ;Integrated Security=True";
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
