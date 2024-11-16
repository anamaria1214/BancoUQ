using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
	public partial class VentanaInicio : Form
	{
		public VentanaInicio()
		{
			InitializeComponent();
			
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void Label2Click(object sender, EventArgs e)
		{
	
		}
		void VentanaInicioLoad(object sender, EventArgs e)
		{
	
		}
		void IngresarClick(object sender, EventArgs e)
		{
			PrincipalEmpleado principalEmpl= new PrincipalEmpleado();
			principalEmpl.Show();
		}
	}
}
