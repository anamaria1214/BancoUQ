namespace Proyecto_Prestamos
{
    public class Municipio
    {
        private string idMunicipio;
        private string nombreMunicipio;
        private int poblacion;

        // Constructor
        public Municipio(string idMunicipio, string nombreMunicipio, int poblacion)
        {
            this.idMunicipio = idMunicipio;
            this.nombreMunicipio = nombreMunicipio;
            this.poblacion = poblacion;
        }

        // Getters y Setters
        public string GetIdMunicipio()
        {
            return idMunicipio;
        }

        public void SetIdMunicipio(string idMunicipio)
        {
            this.idMunicipio = idMunicipio;
        }

        public string GetNombreMunicipio()
        {
            return nombreMunicipio;
        }

        public void SetNombreMunicipio(string nombreMunicipio)
        {
            this.nombreMunicipio = nombreMunicipio;
        }

        public int GetPoblacion()
        {
            return poblacion;
        }

        public void SetPoblacion(int poblacion)
        {
            this.poblacion = poblacion;
        }

        // ToString
        public override string ToString()
        {
            return nombreMunicipio;
        }
    }

}