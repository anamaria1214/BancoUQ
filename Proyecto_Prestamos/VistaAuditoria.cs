using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public partial class VistaAuditoria : Form
    {
        AuditoriaDao auditoriaDao;
        public VistaAuditoria()
        {
            auditoriaDao = new AuditoriaDao();  
            InitializeComponent();
            pintarAuditoria();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
        private void pintarAuditoria()
        {
            List<Auditoria> auditorias= auditoriaDao.obtenerAuditorias();
            tablaAuditoria.Rows.Clear();
            foreach (var auditoria in auditorias)
            {
                tablaAuditoria.Rows.Add(
                    UsuarioSesion.obtenerInstancia().empleado.getNombreEmpleado(),
                    auditoria.FechaIngreso,
                    auditoria.FechaSalida,
                    auditoria.IdCuenta
                    );
            }
        }
    }
}
