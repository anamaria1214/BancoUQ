using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Prestamos
{
    internal class Cuenta
    {
        public string IdCuentaUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string IdTipo { get; set; } // Puede ser null

        // Constructor con todos los campos
        public Cuenta(string idCuentaUsuario, string nombreUsuario, string contraseña, string idTipo)
        {
            IdCuentaUsuario = idCuentaUsuario;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            IdTipo = idTipo;
        }

        // Constructor sin IdTipo (opcional)
        public Cuenta(string idCuentaUsuario, string nombreUsuario, string contraseña)
        {
            IdCuentaUsuario = idCuentaUsuario;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            IdTipo = null; // Por defecto null
        }
    }
}
