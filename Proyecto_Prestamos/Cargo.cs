using System;

namespace Proyecto_Prestamos
{
    public class Cargo
    {
        private string idCargo;
        private string nombreCargo;
        private double salario;
        private double topePrestamo;

        // Constructor
        public Cargo(string idCargo, string nombreCargo, double salario, double topePrestamo)
        {
            this.idCargo = idCargo;
            this.nombreCargo = nombreCargo;
            this.salario = salario;
            this.topePrestamo = topePrestamo;
        }

        // Getters y Setters
        public string GetIdCargo()
        {
            return idCargo;
        }

        public void SetIdCargo(string idCargo)
        {
            this.idCargo = idCargo;
        }

        public string GetNombreCargo()
        {
            return nombreCargo;
        }

        public void SetNombreCargo(string nombreCargo)
        {
            this.nombreCargo = nombreCargo;
        }

        public double GetSalario()
        {
            return salario;
        }

        public void SetSalario(double salario)
        {
            this.salario = salario;
        }

        public double GetTopePrestamo()
        {
            return topePrestamo;
        }

        public void SetTopePrestamo(double topePrestamo)
        {
            this.topePrestamo = topePrestamo;
        }

        // ToString
        public override string ToString()
        {
            return nombreCargo;
        }
    }
}