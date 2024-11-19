using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Prestamos
{
    internal class ReporteDao
    { 

    private MainForm mfo;
    private FormReporte reporte;
    private Conexion cone;

    public ReporteDao(Conexion cone)
    {
        this.cone = cone;
    }
    public ReporteDao(FormReporte reporte)
    {
        this.reporte = reporte;
    }
    
    }
}
