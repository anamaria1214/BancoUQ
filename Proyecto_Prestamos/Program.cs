using System;
using System.Windows.Forms;

namespace Proyecto_Prestamos
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		
		[STAThread]
		private static void Main(string[] args)
		{
			Conexion conexion = new Conexion();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MessageBox.Show("Exotico");
			Application.Run(new FormEmpleado(conexion));
		}
		
	}
}
