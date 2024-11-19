using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proyecto_Prestamos
{
    public partial class FormReporte : Form
    {

        Conexion cone;

        public FormReporte(Conexion cone)
        {
            InitializeComponent();
            this.cone = cone;
        }



        public DataTable obtenerMorosos()
        {
            DataTable tabla = new DataTable();
            string consulta = @"
        SELECT 
            p.idPrestamo,
            c.nombre AS Cliente,
            p.monto AS TotalPrestado,
            (p.monto - ISNULL(SUM(pa.montoPago), 0)) AS DeudaPendiente
        FROM 
            Prestamo p
        LEFT JOIN 
            Pagos pa ON p.idPrestamo = pa.idPrestamo
        INNER JOIN 
            Cliente c ON p.idCliente = c.idCliente
        WHERE 
            (p.monto - ISNULL(SUM(pa.montoPago), 0)) > 0
        GROUP BY 
            p.idPrestamo, c.nombre, p.monto";
            try
            {
                SqlCommand cmd = new SqlCommand(consulta, cone.getCon());
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener reporte de morosos: " + ex.Message, "Error");
            }
            return tabla;
        }


        private void llenarDataGridView(string consultaSQL)
        {
            try
            {
                // Crear el adaptador de datos
                SqlDataAdapter adaptador = new SqlDataAdapter(consultaSQL, cone.getCon());

                // Crear y llenar el DataTable
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                // Asignar el DataTable como fuente de datos del DataGridView
                dataGridView1.DataSource = tabla;

                MessageBox.Show("Datos cargados correctamente en el DataGridView.", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error");
            }
        }


        private void exportarAPDF(string nombreArchivo)
        {
            try
            {
                // Crear el documento PDF
                Document documento = new Document();
                PdfWriter.GetInstance(documento, new FileStream(nombreArchivo, FileMode.Create));

                // Abrir el documento para escritura
                documento.Open();

                // Crear una tabla en el PDF con el mismo número de columnas que el DataGridView
                PdfPTable tablaPDF = new PdfPTable(dataGridView1.ColumnCount);

                // Añadir encabezados al PDF (los nombres de las columnas)
                foreach (DataGridViewColumn columna in dataGridView1.Columns)
                {
                    tablaPDF.AddCell(new Phrase(columna.HeaderText));
                }

                // Añadir las filas del DataGridView al PDF
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (!fila.IsNewRow) // Evitar la fila vacía al final
                    {
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            tablaPDF.AddCell(celda.Value?.ToString() ?? ""); // Manejar valores nulos
                        }
                    }
                }

                // Añadir la tabla al documento PDF
                documento.Add(tablaPDF);

                // Cerrar el documento
                documento.Close();

                MessageBox.Show("PDF generado exitosamente en: " + nombreArchivo, "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error");
            }
        }

        private void BtnCargarClick_Click(object sender, EventArgs e)
        {
            string consultaSQL = "SELECT * FROM Empleado"; // Cambia la consulta según tu necesidad
            llenarDataGridView(consultaSQL);
        }

        private void BtnExportarClick_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                Title = "Guardar Reporte como PDF"
            };

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                exportarAPDF(dialogo.FileName);
            }
        }


        private void BtnReporteMorosos_Click(object sender, EventArgs e)
        {
            string consultaSQL = @"
        SELECT 
            p.idPrestamo,
            c.nombre AS Cliente,
            p.monto AS TotalPrestado,
            (p.monto - ISNULL(SUM(pa.montoPago), 0)) AS DeudaPendiente
        FROM 
            Prestamo p
        LEFT JOIN 
            Pagos pa ON p.idPrestamo = pa.idPrestamo
        INNER JOIN 
            Cliente c ON p.idCliente = c.idCliente
        WHERE 
            (p.monto - ISNULL(SUM(pa.montoPago), 0)) > 0
        GROUP BY 
            p.idPrestamo, c.nombre, p.monto"; // Cambia la consulta según tu necesidad
            llenarDataGridView(consultaSQL);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string consultaSQL = @"SELECT * FROM Municipio";
            llenarDataGridView(consultaSQL);
        }
    }
}