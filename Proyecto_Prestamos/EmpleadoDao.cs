using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class EmpleadoDao
    {
        private MainForm mfo;
        private FormEmpleado formEmpleado;

        public EmpleadoDao(MainForm mfo)
        {
            this.mfo = mfo;
        }

        public EmpleadoDao(FormEmpleado formEmpleado)
        {
            this.formEmpleado = formEmpleado;
        }

        public void agregar(Empleado emp)
        {
            try
            {
                SqlCommand cmd = mfo.getConecte().getCon().CreateCommand();
                cmd.CommandText = "Insert into Empleado (idEmpleado, nombreEmpleado, idCargo, idSucursal, idMunicipio) " +
                 "Values(@idEmpleado, @nombreEmpleado, @idCargo, @idSucursal, @idMunicipio)";

                cmd.Parameters.AddWithValue("@idEmpleado", emp.getIdEmpleado());
                cmd.Parameters.AddWithValue("@nombreEmpleado", emp.getNombreEmpleado());
                cmd.Parameters.AddWithValue("@idCargo", emp.getCargo().GetIdCargo());
                cmd.Parameters.AddWithValue("@idSucursal", emp.getIdSucursal().getIdSucursal());
                cmd.Parameters.AddWithValue("@idMunicipio", emp.getNombreMunicipio().GetIdMunicipio());

                cmd.ExecuteNonQuery();
                crearCuentaUsuario(emp.getIdEmpleado());
                MessageBox.Show("Empleado agregado correctamente.", "Información");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message, "Error");
            }
        }


        private void crearCuentaUsuario(string idEmpleado)
        {
            try
            {
                SqlCommand cmd = mfo.getConecte().getCon().CreateCommand();
                cmd.CommandText = "Insert into Usuario (idUsuario, contraseña) Values(@idUsuario, @contraseña)";
                cmd.Parameters.AddWithValue("@idUsuario", idEmpleado);
                cmd.Parameters.AddWithValue("@contraseña", idEmpleado);

                cmd.Connection = mfo.getConecte().getCon();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empleado agregado correctamente. numero de cuenta y contraseña es: "+idEmpleado, "Información");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear cuenta de usuario: " + ex.Message, "Error");
            }
        }

        public string buscarTodos()
        {
            string empleados = "";
            string consulta = "SELECT * FROM Empleado";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empleados += $"{reader["idEmpleado"]}   {reader["nombreEmpleado"]}\n";
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

        public Empleado buscarEmpleado(string idEmpleado)
        {
            Empleado emp = null;
            string consulta = "SELECT * FROM Empleado WHERE idEmpleado = @idEmpleado";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader["idEmpleado"].ToString();
                    string nombre = reader["nombreEmpleado"].ToString();
                    string idCargo = reader["idCargo"].ToString();
                    string idSucursal = reader["idSucursal"].ToString();
                    string idMunicipio = reader["idMunicipio"].ToString();

                    emp = new Empleado(id, nombre, new Cargo(idCargo, null, 0, 0), new Sucursal(idCargo, null, null, null), new Municipio(idMunicipio, null, 0), null);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
            }

            return emp;
        }

        public bool editar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "UPDATE Empleado SET nombreEmpleado = @nombreEmpleado, idCargo = @idCargo, " +
                              "idSucursal = @idSucursal, idMunicipio = @idMunicipio WHERE idEmpleado = @idEmpleado";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.Parameters.AddWithValue("@idEmpleado", emp.getIdEmpleado());
                cmd.Parameters.AddWithValue("@nombreEmpleado", emp.getNombreEmpleado());
                cmd.Parameters.AddWithValue("@idCargo", emp.getCargo().GetIdCargo());
                cmd.Parameters.AddWithValue("@idSucursal", emp.getIdSucursal());
                cmd.Parameters.AddWithValue("@idMunicipio", emp.getIdSucursal().getidMunicipio().GetIdMunicipio());

                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar empleado: " + ex.Message, "Error");
            }

            return resultado;
        }

        public bool eliminar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "DELETE FROM Empleado WHERE idEmpleado = @idEmpleado";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.Parameters.AddWithValue("@idEmpleado", emp.getIdEmpleado());
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
