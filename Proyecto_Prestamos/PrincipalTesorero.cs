using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        Conexion cone = Conexion.Instancia;
        UsuarioSesion usuario = UsuarioSesion.obtenerInstancia();
        CorreoNotificacion correo;
        SolicitudDao solicitudDao;
        EmpleadoDao empleadoDao; 
        private string selecSolicitud = "0";
        PrestamoDao1 prestamoDao;
        public PrincipalTesorero()
        {
            this.solicitudDao = new SolicitudDao();
            this.prestamoDao = new PrestamoDao1();
            this.correo = new CorreoNotificacion();
            this.empleadoDao = new EmpleadoDao();
            InitializeComponent();
            pintarSolicitudes();
        }
        private void pintarSolicitudes()
        {
            List<Solicitud> solicitudes = solicitudDao.obtenerSolicitudesPorEstado("1");
            dataGridView1.Rows.Clear();
            foreach (var solicitud in solicitudes)
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
            if (selecSolicitud.Equals("0"))
            {
                MessageBox.Show($"No se ha seleccionado una solicitud");
            }
            else
            {

                if (solicitudDao.aprobarSolicitud(selecSolicitud))
                {
                    Solicitud solicitud = solicitudDao.obtenerSolicitudPorId(selecSolicitud);
                    Empleado empleado = empleadoDao.buscarEmpleado(solicitud.GetIdEmpleado());
                    solicitud.setId(selecSolicitud);
                    MessageBox.Show($"Se aprueba la solicitud: {selecSolicitud}");
                    pintarSolicitudes();
                    Prestamo prestamo = new Prestamo(solicitud.idEmpleado, solicitud.idSolicitud, 12345, solicitud.monto, solicitud.tasaInteres, DateTime.Now, (int)solicitud.periodoMeses);
                    prestamoDao.agregarPrestamo(prestamo);
                    selecSolicitud = "0";
                    correo.enviarCorreo(empleado.getEmail(), "Aprobación", "La solicitud con el id: "+solicitud.GetIdSolicitud()+" ha sido aprovada");
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
                if (solicitudDao.rechazarSolicitud(selecSolicitud))
                {
                    Solicitud solicitud = solicitudDao.obtenerSolicitudPorId(selecSolicitud);
                    solicitud.setId(selecSolicitud);
                    Empleado empleado = empleadoDao.buscarEmpleado(solicitud.GetIdEmpleado());
                    MessageBox.Show($"Se rechaza la solicitud: {selecSolicitud}");
                    pintarSolicitudes();
                    selecSolicitud = "0";
                    correo.enviarCorreo(empleado.getEmail(), "Rechazo del prestamo", "La solicitud con el id: " + solicitud.GetIdSolicitud() + " ha sido rechazada");
                }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}