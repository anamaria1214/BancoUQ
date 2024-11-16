using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Prestamos
{
    public partial class CRUDSolicitud : Form
    {
        Solicitud Solicitud;
        SolicitudDao SolicitudDao;
        Conexion cone;
        public CRUDSolicitud(Conexion cone)
        {
            InitializeComponent();
            this.SolicitudDao = new SolicitudDao(cone);
            this.cone = cone;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal monto = decimal.Parse(montoSolicitud.Text);
            int periodo = int.Parse(periodoMeses.SelectedItem.ToString());
            decimal tasa = 0;
            switch (periodo)
            {
                case 24:
                    tasa = 7;
                    break;
                case 36:
                    tasa = (decimal)7.5;
                    break;
                case 48:
                    tasa = 8;
                    break;
                case 60:
                    tasa = (decimal)8.3;
                    break;
                case 72:
                    tasa = (decimal)8.6;
                    break;
            }
            Solicitud solicitud = new Solicitud("1", UsuarioSesion.obtenerInstancia().getEmpleado().getIdEmpleado(), monto, periodo, DateTime.Now, tasa);  
            SolicitudDao.agregarSolicitud(solicitud);
        }
    }
}
