﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class PrestamoDao
    {
        private Conexion cone = Conexion.Instancia;
        public PrestamoDao()
        {

        }
        public bool agregarPrestamo(Prestamo prestamo)
        {
            // Consulta SQL para verificar si el préstamo ya existe
            string consultaVerificar = "SELECT COUNT(*) FROM Prestamo WHERE idPrestamo = @idPrestamo";

            // Consulta para insertar un nuevo préstamo
            string consultaInsertar = "INSERT INTO Prestamo (idPrestamo, monto, periodoMeses, tasaInteres, fechaInicio, valorCuota, idSolicitud, idEmpleado) " +
                                      "VALUES (@idPrestamo, @monto, @periodoMeses, @tasaInteres, @fechaInicio, @valorCuota, @idSolicitud, @idEmpleado)";

            try
            {
                // Verificar si el idPrestamo ya existe
                SqlCommand cmdVerificar = new SqlCommand(consultaVerificar, cone.getCon());
                cmdVerificar.Parameters.AddWithValue("@idPrestamo", prestamo.idSolicitud);
                int existe = (int)cmdVerificar.ExecuteScalar();  // Devuelve el número de registros con el idPrestamo

                // Si ya existe, no agregamos el nuevo registro
                if (existe > 0)
                {
                    MessageBox.Show("Ya existe un préstamo con el mismo ID.", "Error");
                    return false;
                }

                // Si no existe, insertamos el nuevo préstamo
                SqlCommand cmdInsertar = new SqlCommand(consultaInsertar, cone.getCon());
                cmdInsertar.Parameters.AddWithValue("@idPrestamo", prestamo.idPrestamo);
                cmdInsertar.Parameters.AddWithValue("@monto", prestamo.monto);
                cmdInsertar.Parameters.AddWithValue("@periodoMeses", prestamo.periodoMeses);
                cmdInsertar.Parameters.AddWithValue("@tasaInteres", prestamo.tasaInteres);
                cmdInsertar.Parameters.AddWithValue("@fechaInicio", prestamo.fechaInicio);
                cmdInsertar.Parameters.AddWithValue("@valorCuota", prestamo.valorCuota);
                cmdInsertar.Parameters.AddWithValue("@idSolicitud", prestamo.idSolicitud);
                cmdInsertar.Parameters.AddWithValue("@idEmpleado", prestamo.idEmpleado);

                cmdInsertar.ExecuteNonQuery();
                MessageBox.Show("Préstamo agregado exitosamente.", "Éxito");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el préstamo: " + ex.Message, "Error");
                return false;
            }
        }

    }
}
