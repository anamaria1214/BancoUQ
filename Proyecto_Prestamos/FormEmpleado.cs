using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Prestamos
{
    public partial class FormEmpleado : Form
    {
        private MainForm mfo;  // Referencia a MainForm para usar la conexión
        private Empleado emp;  // Objeto de tipo Empleado
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private Label lblIdEmpleado;
        private Label lblNombreEmpleado;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private EmpleadoDao empDao;  // Objeto de tipo EmpleadoDAO para operaciones en la BD

        // Constructor de FormEmpleado que recibe una instancia de MainForm
        public FormEmpleado(MainForm mf)
        {
            mfo = mf;  // Asigna la instancia de MainForm
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        

        // Evento del botón para agregar un empleado
        void BtnAgregarEmpleado(object sender, EventArgs e)
        {
            String id, nombre, cargo, idSucursal, nombreMunicipio, estado;
            id = txtId.Text;  // ID del empleado
            nombre = txtNombreEmpleado.Text;  // Nombre del empleado
            


            emp = new Empleado(id, nombre, null, null, null, null);  // Crea un nuevo empleado
            MessageBox.Show("Empleado creado");

            empDao = new EmpleadoDao(mfo);  // Crea una instancia de EmpleadoDAO
            empDao.agregar(emp);  // Agrega el empleado a la base de datos
        }

        // Evento del botón para buscar un empleado por su ID
        void BtnBuscarEmpleado(object sender, EventArgs e)
        {
            String id;
            id = txtId.Text;  // ID del empleado a buscar

            empDao = new EmpleadoDao(mfo);  // Crea una instancia de EmpleadoDAO
            emp = empDao.buscarEmpleado(id);  // Busca el empleado en la base de datos

            if (emp == null)
            {
                MessageBox.Show("Empleado no encontrado");
            }
            else
            {
                txtId.Text = emp.getIdEmpleado();  // Muestra el ID
                txtNombreEmpleado.Text = emp.getNombreEmpleado();  // Muestra el nombre
            }
        }

        // Evento del botón para eliminar un empleado
        void Button4Click(object sender, EventArgs e)
        {
            String id;

            if (txtId.Text == "")
            {
                MessageBox.Show("Busque un empleado para borrar");
            }
            else
            {
                Boolean borrado;
                id = txtId.Text;  // Toma el ID del empleado

                empDao = new EmpleadoDao(mfo);  // Crea una instancia de EmpleadoDAO
                emp = empDao.buscarEmpleado(id);  // Busca el empleado

                if (emp != null)
                {
                    DialogResult clicado = MessageBox.Show(emp.getIdEmpleado() + "   " + emp.getNombreEmpleado() + "\n\n Confirma su eliminación?", "DATOS DEL EMPLEADO", MessageBoxButtons.YesNo);
                    if (clicado == System.Windows.Forms.DialogResult.Yes)
                    {
                        borrado = empDao.eliminar(emp);  // Elimina el empleado
                        MessageBox.Show("Empleado eliminado");
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la eliminación del empleado");
                    }
                }
            }
        }

        // Evento del botón para listar todos los empleados
        void Button5Click(object sender, EventArgs e)
        {
            String todos = "";
            empDao = new EmpleadoDao(mfo);  // Crea una instancia de EmpleadoDAO
            todos = empDao.buscarTodos();  // Obtiene la lista de todos los empleados
            MessageBox.Show(todos, "Listado de todos los empleados");
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(343, 130);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(173, 22);
            this.txtId.TabIndex = 0;
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Location = new System.Drawing.Point(343, 187);
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(173, 22);
            this.txtNombreEmpleado.TabIndex = 1;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Location = new System.Drawing.Point(125, 133);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(154, 16);
            this.lblIdEmpleado.TabIndex = 2;
            this.lblIdEmpleado.Text = "Identificación Empleado:";
            this.lblIdEmpleado.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(125, 193);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(125, 16);
            this.lblNombreEmpleado.TabIndex = 3;
            this.lblNombreEmpleado.Text = "Nombre Empleado:";
            this.lblNombreEmpleado.Click += new System.EventHandler(this.lblNombreEmpleado_Click);
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(69, 375);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(181, 34);
            this.btnAgregarEmpleado.TabIndex = 4;
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.BtnAgregarEmpleado);
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(343, 375);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(181, 34);
            this.btnBuscarEmpleado.TabIndex = 5;
            this.btnBuscarEmpleado.Text = "Buscar Empleado";
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.BtnBuscarEmpleado);
            // 
            // FormEmpleado
            // 
            this.ClientSize = new System.Drawing.Size(637, 532);
            this.Controls.Add(this.btnBuscarEmpleado);
            this.Controls.Add(this.btnAgregarEmpleado);
            this.Controls.Add(this.lblNombreEmpleado);
            this.Controls.Add(this.lblIdEmpleado);
            this.Controls.Add(this.txtNombreEmpleado);
            this.Controls.Add(this.txtId);
            this.Name = "FormEmpleado";
            this.Load += new System.EventHandler(this.FormEmpleado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblNombreEmpleado_Click(object sender, EventArgs e)
        {

        }
    }
}
