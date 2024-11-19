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
            string consulta = "select * from Sucursal where idSucursal = '" + idSucursal + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetValue(0).ToString();
                    string nombre = reader.GetValue(1).ToString();
                    string idMunicipio = reader.GetValue(2).ToString();
                    string direccion = reader.GetValue(3).ToString();
                    sucursal = new Sucursal(id, nombre, direccion, idMunicipio);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleado: " + ex.Message, "Error");
            }
            return sucursal;
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