using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Proyecto_Prestamos
{
    public partial class FormEmpleado : Form
    {

        Conexion cone;
        private Empleado emp;  // Objeto de tipo Empleado
        private EmpleadoDao empDao;  // Objeto de tipo EmpleadoDAO para operaciones en la BD
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.Button btnBuscarEmpleado;
        private System.Windows.Forms.Button btnEditarEmpleado;
        private System.Windows.Forms.Button btnEliminarEmpleado;
        private Label lblCargo;
        private Label lblSucursalEmpleado;
        private Label lblSalarioEmpleado;
        private Label lblIdEmpleado;
        private Label lblFechaNaci;
        private Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.TextBox txtSucursal;
        private Label lblNombreEmpleado;


        // Constructor de FormEmpleado que recibe una instancia de MainForm
        public FormEmpleado(Conexion cone)
        {
            InitializeComponent();  // Inicializa los componentes del formulario
            this.cone = cone;
            this.empDao = new EmpleadoDao(cone);

        }


        public DateTime? ConvertirFecha(string fechaTexto)
        {

            // Intenta convertir la fecha usando el formato "yyyy-MM-dd"
            if (DateTime.TryParseExact(fechaTexto, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None, out DateTime fechaConvertida))
            {
                return fechaConvertida;
            }
            else
            {
                MessageBox.Show("La fecha ingresada no es válida. Use el formato yyyy-MM-dd.", "Error");
                return null; // Retorna null si la conversión falla
            }
        }




        // Evento del botón para agregar un empleado
        void BtnAgregarEmpleado(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string nombre = txtNombreEmpleado.Text;
            string fechaTexto = txtFechaNacimiento.Text;

            // Convertir fecha
            DateTime? fechaNacimiento = ConvertirFecha(fechaTexto);


<<<<<<< HEAD
            emp = new Empleado(id, nombre, DateTime.Now, null, null);  // Crea un nuevo empleado
            MessageBox.Show("Empleado creado");

            empDao = new EmpleadoDao(mfo);  // Crea una instancia de EmpleadoDAO
            //empDao.agregar(emp);  // Agrega el empleado a la base de datos
=======
            if (fechaNacimiento == null)
            {
                MessageBox.Show("La fecha ingresada no es válida. Use el formato yyyy-MM-dd.", "Error");
                return;
            }

            string cargo = txtCargo.Text;
            string idSucursal = txtSucursal.Text;
            string email = txtEmail.Text;

            // Crear el empleado solo si todos los datos son válidos
            emp = new Empleado(id, nombre, (DateTime)fechaNacimiento, cargo, idSucursal, email);

            try
            {
                empDao.agregarEmpleado(emp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message, "Error");
            }
>>>>>>> galvis
        }


        // Evento del botón para buscar un empleado por su ID
        void BtnBuscarEmpleado(object sender, EventArgs e)
        {
            String id;
            id = txtId.Text;  // ID del empleado a buscar

            emp = empDao.buscarEmpleado(id);  // Busca el empleado en la base de datos

            if (emp == null)
            {
                MessageBox.Show("Empleado no encontrado");
            }
            else
            {
                txtId.Text = emp.getIdEmpleado();  // Muestra el ID
                txtNombreEmpleado.Text = emp.getNombreEmpleado();  // Muestra el nombre
                txtFechaNacimiento.Text = emp.getFechaNaci().ToString();
                txtEmail.Text = emp.getEmail();
                txtCargo.Text = emp.getCargo();
                txtSucursal.Text = emp.getIdSucursal();
            }
        }

        // Evento del botón para eliminar un empleado
        void BtnEliminarEmpleado(object sender, EventArgs e)
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



        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.btnBuscarEmpleado = new System.Windows.Forms.Button();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblSucursalEmpleado = new System.Windows.Forms.Label();
            this.lblSalarioEmpleado = new System.Windows.Forms.Label();
            this.btnEditarEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarEmpleado = new System.Windows.Forms.Button();
            this.lblFechaNaci = new System.Windows.Forms.Label();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(251, 91);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(173, 22);
            this.txtId.TabIndex = 0;
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Location = new System.Drawing.Point(251, 132);
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(173, 22);
            this.txtNombreEmpleado.TabIndex = 1;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Location = new System.Drawing.Point(33, 91);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(154, 16);
            this.lblIdEmpleado.TabIndex = 2;
            this.lblIdEmpleado.Text = "Identificación Empleado:";
            this.lblIdEmpleado.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(33, 132);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(125, 16);
            this.lblNombreEmpleado.TabIndex = 3;
            this.lblNombreEmpleado.Text = "Nombre Empleado:";
            this.lblNombreEmpleado.Click += new System.EventHandler(this.lblNombreEmpleado_Click);
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(474, 79);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(181, 34);
            this.btnAgregarEmpleado.TabIndex = 4;
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.BtnAgregarEmpleado);
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(474, 264);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(181, 34);
            this.btnBuscarEmpleado.TabIndex = 5;
            this.btnBuscarEmpleado.Text = "Buscar Empleado";
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.BtnBuscarEmpleado);
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(33, 272);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(47, 16);
            this.lblCargo.TabIndex = 6;
            this.lblCargo.Text = "Cargo:";
            this.lblCargo.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblSucursalEmpleado
            // 
            this.lblSucursalEmpleado.AutoSize = true;
            this.lblSucursalEmpleado.Location = new System.Drawing.Point(33, 317);
            this.lblSucursalEmpleado.Name = "lblSucursalEmpleado";
            this.lblSucursalEmpleado.Size = new System.Drawing.Size(59, 16);
            this.lblSucursalEmpleado.TabIndex = 8;
            this.lblSucursalEmpleado.Text = "Sucursal";
            // 
            // lblSalarioEmpleado
            // 
            this.lblSalarioEmpleado.Location = new System.Drawing.Point(0, 0);
            this.lblSalarioEmpleado.Name = "lblSalarioEmpleado";
            this.lblSalarioEmpleado.Size = new System.Drawing.Size(100, 23);
            this.lblSalarioEmpleado.TabIndex = 18;
            // 
            // btnEditarEmpleado
            // 
            this.btnEditarEmpleado.Location = new System.Drawing.Point(474, 199);
            this.btnEditarEmpleado.Name = "btnEditarEmpleado";
            this.btnEditarEmpleado.Size = new System.Drawing.Size(181, 34);
            this.btnEditarEmpleado.TabIndex = 16;
            this.btnEditarEmpleado.Text = "Editar Empleado";
            this.btnEditarEmpleado.UseVisualStyleBackColor = true;
            this.btnEditarEmpleado.Click += new System.EventHandler(this.btnEditarEmpleado_Click);
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(474, 132);
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(181, 34);
            this.btnEliminarEmpleado.TabIndex = 17;
            this.btnEliminarEmpleado.Text = "Eliminar Empleado";
            this.btnEliminarEmpleado.UseVisualStyleBackColor = true;
            this.btnEliminarEmpleado.Click += new System.EventHandler(this.BtnEliminarEmpleado);
            // 
            // lblFechaNaci
            // 
            this.lblFechaNaci.AutoSize = true;
            this.lblFechaNaci.Location = new System.Drawing.Point(33, 182);
            this.lblFechaNaci.Name = "lblFechaNaci";
            this.lblFechaNaci.Size = new System.Drawing.Size(135, 16);
            this.lblFechaNaci.TabIndex = 19;
            this.lblFechaNaci.Text = "Fecha de nacimiento:";
            this.lblFechaNaci.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Location = new System.Drawing.Point(251, 182);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.Size = new System.Drawing.Size(173, 22);
            this.txtFechaNacimiento.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(251, 223);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(173, 22);
            this.txtEmail.TabIndex = 22;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(251, 266);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(173, 22);
            this.txtCargo.TabIndex = 23;
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(251, 314);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(173, 22);
            this.txtSucursal.TabIndex = 24;
            // 
            // FormEmpleado
            // 
            this.ClientSize = new System.Drawing.Size(689, 403);
            this.Controls.Add(this.txtSucursal);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFechaNacimiento);
            this.Controls.Add(this.lblFechaNaci);
            this.Controls.Add(this.btnEliminarEmpleado);
            this.Controls.Add(this.btnEditarEmpleado);
            this.Controls.Add(this.lblSalarioEmpleado);
            this.Controls.Add(this.lblSucursalEmpleado);
            this.Controls.Add(this.lblCargo);
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
            //CargarCargos();

        }


        private void CargarCargos()
        {
            try
            {
                using (SqlConnection conn = cone.getCon())
                {
                    conn.Open();
                    string query = "SELECT nombreCargo FROM Cargo"; // Cambia el nombre de la tabla según tu diseño
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //comboBoxCargoEmpleado.Items.Add(reader["nombreCargo"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando cargos: {ex.Message}", "Error");
            }
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string nombre = txtNombreEmpleado.Text;
            string cargo = txtCargo.Text;
            string idSucursal = txtSucursal.Text;
            DateTime fechaNaci;
            string email = txtEmail.Text;

            if (DateTime.TryParse(txtFechaNacimiento.Text, out fechaNaci))
            {
                emp = new Empleado(id, nombre, fechaNaci, idSucursal, cargo, email);
                empDao.editarEmpleado(emp);
                MessageBox.Show("Empleado editado con éxito.");
            }
            else
            {
                MessageBox.Show("Fecha de nacimiento inválida.");
            }
            // Limpiar los campos después de editar
            LimpiarCampos();
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombreEmpleado.Clear();
            txtCargo.Clear();
            txtSucursal.Clear();
            txtFechaNacimiento.Clear();
            txtEmail.Clear();

        }



        private void label1_Click_3(object sender, EventArgs e)
        {

        }


    }
}