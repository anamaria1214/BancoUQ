using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public class AuditoriaDao
    {
        private Conexion cone;
        private List<Auditoria> auditorias = new List<Auditoria>();
        public AuditoriaDao()
        {
            this.cone = new Conexion();
        }

    }

}