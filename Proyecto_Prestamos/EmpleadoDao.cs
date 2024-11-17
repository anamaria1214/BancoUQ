using System;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class EmpleadoDao
    {
        private MainForm mfo;
        Conexion cone;

        public EmpleadoDao(Conexion cone)
        {
            this.cone = cone;
        }

        public EmpleadoDao(MainForm mfo)
        {
            this.mfo = mfo;
        }

        public bool login(string nombreUsuario, string contraseña)
        {
            bool flag = false;
            string consulta = "SELECT * FROM CuentaUsuario WHERE nombreUsuario = "+nombreUsuario+" AND contraseña = "+contraseña;
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    flag = true;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error");
            }
            return flag;
        }




        /*public void agregar(Empleado emp)
        {
            try
            {
                SqlCommand cmd = mfo.getConecte().getCon().CreateCommand();
                cmd.CommandText = "Insert into Empleado (idEmpleado, nombreEmpleado, cargo, idSucursal, nombreMunicipio, estado) " +
                    "Values('" + emp.getIdEmpleado() + "','" + emp.getNombreEmpleado() + "','" + emp.getCargo() + "','" + emp.getIdSucursal() + "','" + emp.getNombreMunicipio() + "','" + emp.getEstado() + "')";
                cmd.Connection = mfo.getConecte().getCon();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado agregado exitosamente", "Atención!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message, "Error");
            }
        }*/

        public string buscarTodos()
        {
            string empleados = "";
            string consulta = "select * from Empleado";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empleados += reader.GetValue(0).ToString() + "   " + reader.GetValue(1).ToString() + "\n";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleados: " + ex.Message, "Error");
            }

            return empleados;
        }
        public Empleado hallarEmpleadoPorCuenta(string usuario)
        {
            Empleado emp = null;
            string consulta = "SELECT * FROM CuentaUsuario WHERE nombreUsuario = "+usuario;

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) // Solo necesitas leer una vez si esperas un único resultado
                {
                    string id = reader.GetString(0); // Usa los métodos de tipo correcto
                    string nombre = reader.GetString(1);
                    DateTime fechaNacimiento= reader.GetDateTime(2);
                    string idSucursal= reader.GetString(3);
                    string idCargo= reader.GetString(4);

                    emp = new Empleado(id, nombre, fechaNacimiento, idSucursal, idCargo);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
            }

            return emp;
        }


        public Empleado buscarEmpleado(string idEmpleado)
        {
            Empleado emp = null;
            string consulta = "select * from Empleado where idEmpleado = '" + idEmpleado + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetString(0); // Usa los métodos de tipo correcto
                    string nombre = reader.GetString(1);
                    DateTime fechaNacimiento = reader.GetDateTime(2);
                    string idSucursal = reader.GetString(3);
                    string idCargo = reader.GetString(4);

                    emp = new Empleado(id, nombre, fechaNacimiento, idSucursal, idCargo);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
            }

            return emp;
        }

        /*public bool editar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "update Empleado set nombreEmpleado = '" + emp.getNombreEmpleado() + "', cargo = '" + emp.getCargo() + "', " +
                "idSucursal = '" + emp.getIdSucursal() + "', nombreMunicipio = '" + emp.getNombreMunicipio() + "', estado = '" + emp.getEstado() + "' " +
                "where idEmpleado = '" + emp.getIdEmpleado() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar empleado: " + ex.Message, "Error");
            }

            return resultado;
        }*/

        public bool eliminar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "Delete from Empleado where idEmpleado = '" + emp.getIdEmpleado() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex.Message, "Error");
            }

            return resultado;
        }
    }
}
