using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Prestamos
{
    internal class Auditoria
    {
        string idCuenta;
        string nombreEmpleado;
        DateTime fechaIngreso;
        DateTime fechaSalida;
        public Auditoria(string idCuenta, string nombreEmpleado, DateTime fechaIngreso, DateTime fechaSalida) { 
            this.idCuenta = idCuenta;
            this.nombreEmpleado=nombreEmpleado;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
        }

        public string IdCuenta
        {
            get { return idCuenta; }
            set { idCuenta = value; }
        }

        public string NombreEmpleado
        {
            get { return nombreEmpleado; }
            set { nombreEmpleado = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public DateTime FechaSalida
        {
            get { return fechaSalida; }
            set { fechaSalida = value; }
        }
    


    }
}
