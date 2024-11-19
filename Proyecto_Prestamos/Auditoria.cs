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

    }
}
