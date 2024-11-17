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
    public partial class PrincipalTesorero : Form
    {
        Conexion cone=Conexion.Instancia;
        SolicitudDao solicitudDao;
        public PrincipalTesorero()
        {
            this.solicitudDao= new SolicitudDao();
            InitializeComponent();
            pintarSolicitudes();
        }
        private void pintarSolicitudes()
        {
           List<Solicitud> solicitudes = solicitudDao.obtenerSolicitudesPorEstado("1");
            dataGridView1.Rows.Clear();
            foreach(var solicitud in solicitudes)
            {
                dataGridView1.Rows.Add(
                    solicitud.monto,
                    solicitud.periodoMeses,
                    solicitud.tasaInteres,
                    solicitud.fechaSolicitud.ToShortDateString(),
                    solicitud.idEmpleado,
                    solicitud.idSolicitud
                    );
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
