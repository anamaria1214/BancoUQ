using System;

namespace Proyecto_Prestamos
{
    public class Prestamo
    {
        public string idPrestamo { get; set; }
        public string idEmpleado { get; set; }
        public string idSolicitud { get; set; }
        public float valorCuota { get; set; }
        public decimal monto { get; set; }
        public decimal tasaInteres { get; set; }
        public DateTime fechaInicio { get; set; }
        public int periodoMeses { get; set; }


        public Prestamo(
                        string idEmpleado,
                        string idSolicitud,
                        float valorCuota,
                        decimal monto,
                        decimal tasaInteres,
                        DateTime fechaInicio,
                        int periodoMeses)
        {
            this.idPrestamo = Guid.NewGuid().ToString().Substring(0, 25);
            this.idEmpleado = idEmpleado;
            this.idSolicitud = idSolicitud;
            this.valorCuota = valorCuota;
            this.monto = monto;
            this.tasaInteres = tasaInteres;
            this.fechaInicio = fechaInicio;
            this.periodoMeses = periodoMeses;
        }



    }
}