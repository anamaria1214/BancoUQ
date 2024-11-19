using System;

namespace Proyecto_Prestamos
{
	public class Sucursal
	{
		public String idSucursal, nombre, direccion;
        public Municipio idMunicipio;
		
		public Sucursal(String idSucursal, String nombre, Municipio idMunicipio, String direccion)
		{
			this.idSucursal=idSucursal;
			this.nombre=nombre;
			this.idMunicipio = idMunicipio;
			this.direccion=direccion;
		}
		
		public Sucursal(){
			
		}

        public string getIdSucursal()
        {
            return idSucursal;
        }

        public string getNombre()
        {
            return nombre;
        }

        public Municipio getidMunicipio()
        {
            return idMunicipio;
        }

        public string getDireccion()
        {
            return direccion;
        }


    }
}