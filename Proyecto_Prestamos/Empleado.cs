using System;

namespace Proyecto_Prestamos
{
	public class Empleado
	{
        private String idEmpleado, nombreEmpleado, estado;
        private Cargo cargo;
        private Sucursal idSucursal;
        private Municipio nombreMunicipio;
		public Empleado(String idEmpleado, String nombreEmpleado, Cargo cargo, Sucursal idSucursal, Municipio nombreMunicipio,String estado)
		{
			this.idEmpleado=idEmpleado;
			this.nombreEmpleado=nombreEmpleado;
			this.cargo=cargo;
			this.idSucursal=idSucursal;
			this.nombreMunicipio= nombreMunicipio;
            this.estado = estado;
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

        public Cargo getCargo()
        {
            return cargo;
        }

        public void setCargo(Cargo cargo)
        {
            this.cargo = cargo;
        }

        public Sucursal getIdSucursal()
        {
            return idSucursal;
        }

        public void setIdSucursal(Sucursal idSucursal)
        {
            this.idSucursal = idSucursal;
        }

        public Municipio getNombreMunicipio()
        {
            return nombreMunicipio;
        }

        public void setNombreMunicipio(Municipio nombreMunicipio)
        {
            this.nombreMunicipio = nombreMunicipio;
        }

        public string getEstado()
        {
            return estado;
        }

        public void setEstado(string estado)
        {
            this.estado = estado;
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
