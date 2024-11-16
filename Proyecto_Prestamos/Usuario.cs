using System;

namespace Proyecto_Prestamos
{
	public class Usuario
	{
		private String idUsuario, password;
		private Nivel nivel;
		public Usuario(String idUsuario, String password, Nivel nivel)
		{
			this.idUsuario=idUsuario;
			this.password=password;
			this.nivel=nivel;
		}
	}
}
