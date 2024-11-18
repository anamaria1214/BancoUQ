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
            this.auditoriaDao= new AuditoriaDao();
            InitializeComponent();
        }
        private void pintarAuditoria()
        {
            List<Auditoria> auditorias= auditoriaDao.ObtenerAuditorias();
            tablaAuditoria.Rows.Clear();
            foreach (var auditoria in auditorias)
            {
                tablaAuditoria.Rows.Add(
                    auditoria.IdCuenta,
                    auditoria.NombreEmpleado,
                    auditoria.FechaIngreso,
                    auditoria.FechaSalida
                    );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
