using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class EmpleadoDao
    {
        private MainForm mfo;
        private FormEmpleado crudEmpleado;
        private Conexion cone;
        private CuentaDao cuentaDao;

        public EmpleadoDao(Conexion cone)
        {
            this.cuentaDao = new CuentaDao(cone);
            this.cone = cone;
        }


        public EmpleadoDao(FormEmpleado crudEmpleado)
        {
            this.crudEmpleado = crudEmpleado;
        }


        public bool login(string nombreUsuario, string contraseña)
        {
            bool flag = false;
            string consulta = "SELECT * FROM CuentaUsuario WHERE nombreUsuario = " + nombreUsuario + " AND contraseña = " + contraseña;
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

        public string retornarTipo(string nombreUsuario)
        {
            string consulta = "select * from CuentaUsuario where nombreUsuario= " + nombreUsuario;
            string tipo = "";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    tipo = reader.GetString(3);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar el tipo de cuenta: " + ex);
            }
            return tipo;
        }

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

                string idCuentaUsuario = emp.getIdEmpleado(); // Regla: usar el mismo ID
                string nombreUsuario = emp.getEmail();
                string contraseña = emp.getIdEmpleado(); // Contraseña inicial
                string idTipo = "1"; // Por ejemplo, tipo empleado

                Cuenta cuenta = new Cuenta(idCuentaUsuario, nombreUsuario, contraseña, idTipo);
                cuentaDao.agregarCuenta(cuenta);

                MessageBox.Show("Empleado y cuenta agregados exitosamente.", "Éxito");
                MessageBox.Show("El usuario es: " + idCuentaUsuario + " Y la constraseña es: " + contraseña);

                // Ejecutar el comando
                cmd.ExecuteNonQuery();

                MessageBox.Show("Empleado agregado exitosamente.", "Atención");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message, "Error");
            }
        }

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
            string consulta = "SELECT * FROM CuentaUsuario WHERE nombreUsuario = " + usuario;

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) // Solo necesitas leer una vez si esperas un único resultado
                {
                    string id = reader.GetString(0); // Usa los métodos de tipo correcto
                    string nombre = reader.GetString(1);
                    DateTime fechaNacimiento = reader.GetDateTime(2);
                    string idSucursal = reader.GetString(3);
                    string idCargo = reader.GetString(4);
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
                    string email = reader.IsDBNull(5) ? "na" : reader.GetString(5);

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






        public bool eliminar(Empleado emp)
        {
            bool resultado = false;
            string consulta = "Delete from Empleado where idEmpleado = '" + emp.getIdEmpleado() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
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