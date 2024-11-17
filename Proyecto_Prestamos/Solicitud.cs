using System;

namespace Proyecto_Prestamos
{

    public class Solicitud

    {
        
        public String idSolicitud, idEstado, idEmpleado;
        public decimal monto, periodoMeses, tasaInteres;
        public DateTime fechaSolicitud;
        //tasa de interes derivada

        public Solicitud( String estado, String idEmpleado, decimal monto, decimal periodoMeses, DateTime fechaSolicitud, decimal tasaInteres)
        {
            this.idSolicitud = Guid.NewGuid().ToString().Substring(0,15);
            this.idEstado = estado;
            this.monto = monto;
            this.periodoMeses = periodoMeses;
            this.fechaSolicitud = fechaSolicitud;
            this.idEmpleado = idEmpleado;
            this.tasaInteres= tasaInteres;
        }

        public Solicitud()
        {

        }

        public string GetIdSolicitud()
        {
            
            return idSolicitud;
        }

        public string GetEstado()
        {
            return idEstado;
        }

        public string GetIdEmpleado()
        {
            return idEmpleado;
        }

        public decimal GetMonto()
        {
            return monto;
        }

        public decimal GetPeriodoMeses()
        {
            return periodoMeses;
        }

        public DateTime GetFechaSolicitud()
        {
            return fechaSolicitud;
        }

        public decimal GetTasaInteres()
        {
            return tasaInteres;
        }
    }
}
