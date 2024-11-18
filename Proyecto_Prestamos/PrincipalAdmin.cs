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
    public partial class PrincipalAdmin : Form
    {
        Conexion cone;
        public PrincipalAdmin(Conexion cone)
        {
            this.cone = cone;   
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUDSucursal crudSucursal= new CRUDSucursal(cone);
            crudSucursal.Show();
        }
    }
}
