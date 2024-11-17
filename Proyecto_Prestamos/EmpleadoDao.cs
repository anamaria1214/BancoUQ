using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class EmpleadoDao
    {
        private MainForm mfo;
<<<<<<< Updated upstream
        private FormEmpleado formEmpleado;

        public EmpleadoDao(MainForm mfo)
=======
        private FormEmpleado crudEmpleado;
        private Conexion cone;

        public EmpleadoDao(Conexion cone)
        {
            this.cone = cone;
        }
        public EmpleadoDao(FormEmpleado crudEmpleado)
>>>>>>> Stashed changes
        {
            this.crudEmpleado = crudEmpleado;
        }

<<<<<<< Updated upstream
        public EmpleadoDao(FormEmpleado formEmpleado)
=======

        public bool login(string nombreUsuario, string contraseña)
>>>>>>> Stashed changes
        {
            this.formEmpleado = formEmpleado;
        }

<<<<<<< Updated upstream
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
=======
        public void agregarEmpleado(Empleado emp)
        {
            try
            {
                // Crear el comando SQL
                string consulta = "INSERT INTO Empleado (idEmpleado, nombre, fechaNacimiento, idSucursal, idCargo, email) " +
                                  "VALUES (@idEmpleado, @nombre, @fechaNacimiento, @idSucursal, @idCargo, @email)";

                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());

                MessageBox.Show("Empleado email: " + emp.getEmail());
                // Asignar los parámetros al comando
                cmd.Parameters.AddWithValue("@idEmpleado", emp.getIdEmpleado());
                cmd.Parameters.AddWithValue("@nombre", emp.getNombreEmpleado());
                cmd.Parameters.AddWithValue("@fechaNacimiento", emp.getFechaNaci().ToString("yyyy-MM-dd"));  // Asegúrate de tener un getter para la fecha
                cmd.Parameters.AddWithValue("@idSucursal", emp.getIdSucursal());
                cmd.Parameters.AddWithValue("@idCargo", emp.getCargo());
                cmd.Parameters.AddWithValue("@email", emp.getEmail());

                // Ejecutar el comando
                cmd.ExecuteNonQuery();

                MessageBox.Show("Empleado agregado exitosamente.", "Atención");
>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message, "Error");
            }
        }
<<<<<<< Updated upstream


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
=======
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
=======
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
                    string email = reader.GetString(5);
                    emp = new Empleado(id, nombre, fechaNacimiento, idSucursal, idCargo, email);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
            }

            return emp;
        }

>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
                    string id = reader["idEmpleado"].ToString();
                    string nombre = reader["nombreEmpleado"].ToString();
                    string idCargo = reader["idCargo"].ToString();
                    string idSucursal = reader["idSucursal"].ToString();
                    string idMunicipio = reader["idMunicipio"].ToString();

                    emp = new Empleado(id, nombre, new Cargo(idCargo, null, 0, 0), new Sucursal(idCargo, null, null, null), new Municipio(idMunicipio, null, 0), null);
=======
                    string id = reader.GetString(0); // Usa los métodos de tipo correcto
                    string nombre = reader.GetString(1);
                    DateTime fechaNacimiento = reader.GetDateTime(2);
                    string idSucursal = reader.GetString(3);
                    string idCargo = reader.GetString(4);
                    string email = reader.IsDBNull(5) ? "na" : reader.GetString(5);

                    emp = new Empleado(id, nombre, fechaNacimiento, idSucursal, idCargo, email);
>>>>>>> Stashed changes
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
            }

            return emp;
        }
<<<<<<< Updated upstream

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
=======
        public bool editarEmpleado(Empleado emp)
        {
            bool resultado = false;
            try
            {
                string consulta = "UPDATE Empleado " +
                                  "SET nombre = @nombre, fechaNacimiento = @fechaNacimiento, idSucursal = @idSucursal, idCargo = @idCargo, email = @email " +
                                  "WHERE idEmpleado = @idEmpleado";

                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());


                cmd.Parameters.AddWithValue("@idEmpleado", emp.getIdEmpleado());
                cmd.Parameters.AddWithValue("@nombre", emp.getNombreEmpleado());
                cmd.Parameters.AddWithValue("@fechaNacimiento", emp.getFechaNaci());
                cmd.Parameters.AddWithValue("@idSucursal", emp.getIdSucursal());
                cmd.Parameters.AddWithValue("@idCargo", emp.getCargo());
                cmd.Parameters.AddWithValue("@email", emp.getEmail());
>>>>>>> Stashed changes

                cmd.ExecuteNonQuery();
                resultado = true;

                MessageBox.Show("Empleado editado exitosamente.", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar empleado: " + ex.Message, "Error");
            }

            return resultado;
        }
<<<<<<< Updated upstream
=======





>>>>>>> Stashed changes

        public bool eliminar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "DELETE FROM Empleado WHERE idEmpleado = @idEmpleado";

            try
            {
<<<<<<< Updated upstream
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                cmd.Parameters.AddWithValue("@idEmpleado", emp.getIdEmpleado());
=======
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
>>>>>>> Stashed changes
                cmd.ExecuteNonQuery();
                resultado = true;
                MessageBox.Show("Empleado eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex.Message, "Error");
            }

            return resultado;
        }
    }
}
