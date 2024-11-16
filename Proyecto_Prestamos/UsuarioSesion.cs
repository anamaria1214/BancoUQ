using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Prestamos
{
    public class UsuarioSesion
    {

        private static UsuarioSesion instancia;

        public Empleado empleado { get; private set; }

        private UsuarioSesion(Empleado empleado) {
            this.empleado = empleado;
        }

        public static UsuarioSesion obtenerInstancia(Empleado emp=null)
        {
            if (instancia == null)
            {
                instancia = new UsuarioSesion(emp);
            }
            return instancia;
        }

        public void establecerUsuario(Empleado empleado)
        {
            this.empleado = empleado;
        }

        public void limpiarSesion()
        {
            this.empleado = null;
        }

        public Empleado getEmpleado()
        {
            return this.empleado;
        }
    }

}
