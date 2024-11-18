using System;

namespace Proyecto_Prestamos
{
	
	public class Solicitud
	
	{
		public String idSolicitud, estado, idEmpleado;
		public int periodoMeses;
		public DateTime  fechaSolicitud;
		public decimal monto;
        //tasa de interes derivada

        public Solicitud(String idSolicitud, String estado,String idEmpleado,decimal monto, int periodoMeses, DateTime fechaSolicitud)
		{
			this.idSolicitud=idSolicitud;
			this.estado=estado;
			this.monto=monto;
			this.periodoMeses=periodoMeses;
			this.fechaSolicitud=fechaSolicitud;
			this.idEmpleado=idEmpleado;
		}
		
		public Solicitud(){
			
		}
		
		 public string GetIdSolicitud()
	    {
	        return idSolicitud;
	    }
	
	    public string GetEstado()
	    {
	        return estado;
	    }
	
	    public string GetIdEmpleado()
	    {
	        return idEmpleado;
	    }
	
	    public decimal GetMonto()
	    {
	        return monto;
	    }
	
	    public int GetPeriodoMeses()
	    {
	        return periodoMeses;
	    }
	
	    public DateTime GetFechaSolicitud()
	    {
	        return fechaSolicitud;
	    }
		}
}
