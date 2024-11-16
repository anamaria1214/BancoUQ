using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;


namespace Proyecto_Prestamos
{


    public class SucursalDao
    {
        private MainForm mfo;
        private CRUDSucursal crudSucursal;
        private Conexion cone;

        public SucursalDao(MainForm mfo)
        {
            this.mfo = mfo;
        }
        public SucursalDao(CRUDSucursal crudSucursal)
        {
            this.crudSucursal = crudSucursal;
        }
        public SucursalDao(Conexion cone)
        {
            this.cone = cone;
        }

        public string listarMunicipios()
        {
            return "";
        }

        public bool agregarSucursal(Sucursal sucursal)
        {
            try
            {
                
                String consulta = "Insert into Sucursal (idSucursal, nombreSucursal, idMunicipio, direccion) " +
                    "Values('" + sucursal.getIdSucursal() + "','" + sucursal.getNombre() + "','" + sucursal.getidMunicipio() + "','" + sucursal.getDireccion() + "')";
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
 

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sucursal agregada exitosamente", "Atención!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar una sucursal: " + ex.Message, "Error");
                return false;
            }
        }


        public string obtenerSucursales()
        {
            string sucursales = "";
            string consulta = "select * from Sucursal";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, mfo.getConecte().getCon());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sucursales += reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + "\n";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar las sucursales: " + ex.Message, "Error");
            }
            return sucursales;
        }



        public Sucursal obtenerSucursal(string idSucursal)
        {
            Sucursal sucursal = null;
            string consulta = "SELECT * FROM Sucursal WHERE idSucursal = @idSucursal"; // Usa parámetros para evitar inyección SQL
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.Parameters.AddWithValue("@idSucursal", idSucursal); // Agregar el parámetro a la consulta
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    // Obtener los valores básicos de la sucursal
                    string id = reader.GetString(0); // idSucursal
                    string nombre = reader.GetString(1); // nombreSucursal
                    string idMunicipioStr = reader.GetString(2); // idMunicipio (como string o según el tipo en la base de datos)
                    string direccion = reader.GetString(3); // dirección

                    // Crear el objeto Municipio
                    Municipio municipio = obtenerMunicipioPorId(idMunicipioStr); // Método para buscar Municipio

                    // Crear la instancia de Sucursal
                    sucursal = new Sucursal(id, nombre, municipio, direccion);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar sucursal: " + ex.Message, "Error");
            }
            return sucursal;
        }

        public Municipio obtenerMunicipioPorId(string idMunicipio)
        {
            Municipio municipio = null;
            string consulta = "SELECT * FROM Municipio WHERE idMunicipio = @idMunicipio";

            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetString(0); // idMunicipio
                    string nombre = reader.GetString(1); // nombre del municipio
                    int poblacion = reader.GetInt16(2);

                    municipio = new Municipio(id, nombre, poblacion);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener municipio: " + ex.Message, "Error");
            }

            return municipio;
        }


        public bool actualizarSucursal(Sucursal sucursal)
        {
            bool resultado = false;
            string consulta = "update Sucursal set nombreSucursal = '" + sucursal.getNombre() + "', idMunicipio = '" + sucursal.getidMunicipio() + "', " +
            "direccion = '" + sucursal.getDireccion() +
            "' where idSucursal = '" + sucursal.getIdSucursal() + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.ExecuteNonQuery();
                resultado = true;
                MessageBox.Show("Sucursal editada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar sucursal: " + ex.Message, "Error");
            }
            return resultado;
        }

        public bool eliminar(string idSucursal)
        {
            bool resultado = false;
            string consulta = "Delete from Sucursal where idSucursal = '" + idSucursal + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                cmd.ExecuteNonQuery();
                resultado = true;
                MessageBox.Show("Sucursal eliminada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la sucursal: " + ex.Message, "Error");
            }
            return resultado;
        }
    }


}
