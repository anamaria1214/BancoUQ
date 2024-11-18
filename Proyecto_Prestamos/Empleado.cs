using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Proyecto_Prestamos
{

    public class Empleado
    {
        private String idEmpleado, nombreEmpleado, cargo, idSucursal, email;
        private DateTime fechaNaci;
        //Salario derivado
        public Empleado(String idEmpleado, String nombreEmpleado, DateTime fechaNaci, String idSucursal, String cargo, String email)
        {
            this.idEmpleado = idEmpleado;
            this.nombreEmpleado = nombreEmpleado;
            this.cargo = cargo;
            this.idSucursal = idSucursal;
            this.fechaNaci = fechaNaci;
            this.email = email;
        }
        public Empleado()
        {

        }

        public string getIdEmpleado()
        {
            return idEmpleado;
        }

        public void setIdEmpleado(string idEmpleado)
        {
            this.idEmpleado = idEmpleado;
        }

        public string getNombreEmpleado()
        {
            return nombreEmpleado;
        }

        public void setNombreEmpleado(string nombreEmpleado)
        {
            this.nombreEmpleado = nombreEmpleado;
        }

        public string getCargo()
        {
            return cargo;
        }

        public void setCargo(string cargo)
        {
            this.cargo = cargo;
        }

        public string getIdSucursal()
        {
            return idSucursal;
        }

        public void setIdSucursal(string idSucursal)
        {
            this.idSucursal = idSucursal;
        }

        public string getEmail()
        {
            return email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public DateTime getFechaNaci()
        {
            return fechaNaci;
        }
        public void solicitarPrestamo(float monto, int periodo)
        {
            Console.WriteLine("Solicitud de préstamo realizada por el empleado {0} para un monto de {1} a {2} meses.", nombreEmpleado, monto, periodo);

        }

        public void verEstadoPrestamo(int idPrestamo)
        {
            Console.WriteLine("Consultando el estado del préstamo {0} para el empleado {1}.", idPrestamo, nombreEmpleado);

        }

        public void informarPagoCuota(int idPrestamo, int numCuota, DateTime fechaPago, float valor)
        {
            Console.WriteLine("Informe de pago de cuota {0} del préstamo {1} por {2}. Fecha de pago: {3}.", numCuota, idPrestamo, valor, fechaPago.ToShortDateString());

        }
    }



}