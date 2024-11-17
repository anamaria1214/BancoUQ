using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
    public partial class PrincipalTesorero : Form
    {
        Conexion cone=Conexion.Instancia;
        SolicitudDao solicitudDao;
        private string selecSolicitud="0";
        PrestamoDao prestamoDao;
        public PrincipalTesorero()
        {
            this.solicitudDao= new SolicitudDao();
            this.prestamoDao= new PrestamoDao();
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
        private void aprobar(object sender, EventArgs e)
        {
            if (selecSolicitud.Equals("0")){
                MessageBox.Show($"No se ha seleccionado una solicitud");
            }
            else
            {

                if (solicitudDao.aprobarSolicitud(selecSolicitud))
                {
                    Solicitud solicitud = solicitudDao.obtenerSolicitudPorId(selecSolicitud);
                    solicitud.setId(selecSolicitud);
                    MessageBox.Show($"Se aprueba la solicitud: {selecSolicitud}");
                    pintarSolicitudes();
                    Prestamo prestamo = new Prestamo(solicitud.idEmpleado, solicitud.idSolicitud, 12345 , solicitud.monto, solicitud.tasaInteres, DateTime.Now, (int) solicitud.periodoMeses);
                    prestamoDao.agregarPrestamo(prestamo);
                    selecSolicitud = "0";
                }
                else
                {
                    MessageBox.Show($"Hubo un error al aprobar la solicitud: {selecSolicitud}");
                }
                
            }
        }
        private void rechazar(object sender, EventArgs e)
        {
            if (selecSolicitud.Equals("0"))
            {
                MessageBox.Show($"No se ha seleccionado una solicitud");
            }
            else
            {
               
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

     
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                selecSolicitud = filaSeleccionada.Cells[5].Value.ToString(); // Por índice
            }
        }
    }
}
