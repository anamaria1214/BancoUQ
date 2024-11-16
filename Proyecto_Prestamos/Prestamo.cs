using System;

namespace Proyecto_Prestamos
{
	public class Prestamo
	{
		private String idPrestamo, idEmpleado;
		private float valorCuotas, valorTotal;
		private DateTime fechaPago;
		public Prestamo(String idPrestamo, String idEmpleado, float valorCuotas, float valorTotal, DateTime fechaPago)
		{
			this.idEmpleado=idEmpleado;
			this.idPrestamo=idPrestamo;
			this.valorCuotas= valorCuotas;
			this.valorTotal=valorTotal;
			this.fechaPago=fechaPago;
		}
	}
}
