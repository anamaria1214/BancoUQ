using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
        private Label lblCargo;
        private System.Windows.Forms.ComboBox comboBoxCargoEmpleado;
        private Label lblSucursalEmpleado;
        private Label lblMunicipioEncargado;
        private System.Windows.Forms.ComboBox comboBoxSucursal;
        private System.Windows.Forms.ComboBox comboBoxMunicipioEmpleado;
        private Label lblSalarioEmpleado;
        private System.Windows.Forms.Button btnEditarEmpleado;
        private System.Windows.Forms.Button btnEliminarEmpleado;
        private EmpleadoDao empDao;  // Objeto de tipo EmpleadoDAO para operaciones en la BD

        // Constructor de FormEmpleado que recibe una instancia de MainForm


        private Conexion conexion; // Variable para almacenar la conexión

        public FormEmpleado(MainForm mainForm)
        {
            InitializeComponent();
            this.conexion = mainForm.getConecte(); // Obtén la conexión desde MainForm
        }




        // Evento del botón para agregar un empleado
        void BtnAgregarEmpleado(object sender, EventArgs e)
        {
            String id, nombre, estado;
            id = txtId.Text;  // ID del empleado
            nombre = txtNombreEmpleado.Text;  // Nombre del empleado
            Cargo cargo = comboBoxCargoEmpleado.SelectedItem as Cargo;  // Cargo del empleado
            Sucursal sucursal = comboBoxSucursal.SelectedItem as Sucursal;  // Sucursal del empleado
            Municipio nombreMunicipio = comboBoxMunicipioEmpleado.SelectedItem as Municipio;  // Municipio del empleado
            
            emp = new Empleado(id, nombre, cargo, sucursal, nombreMunicipio, null);  // Crea un nuevo empleado
            MessageBox.Show("Empleado creado");

            empDao = new EmpleadoDao(mfo);  // Crea una instancia de EmpleadoDAO
            empDao.agregar(emp);  // Agrega el empleado a la base de datos
        }

        // Evento del botón para buscar un empleado por su ID
        void BtnBuscarEmpleado(object sender, EventArgs e)
        {
            String id = txtId.Text;
            empDao = new EmpleadoDao(mfo);
            emp = empDao.buscarEmpleado(id);

            if (emp == null)
            {
                MessageBox.Show("Empleado no encontrado");
            }
            else
            {
                txtId.Text = emp.getIdEmpleado();
                txtNombreEmpleado.Text = emp.getNombreEmpleado();
                comboBoxCargoEmpleado.SelectedItem = emp.getCargo();
                comboBoxSucursal.SelectedItem = emp.getIdSucursal();
                comboBoxMunicipioEmpleado.SelectedItem = emp.getNombreMunicipio();
             
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
        void BtnListarEmpleados(object sender, EventArgs e)
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
            this.lblCargo = new System.Windows.Forms.Label();
            this.comboBoxCargoEmpleado = new System.Windows.Forms.ComboBox();
            this.lblSucursalEmpleado = new System.Windows.Forms.Label();
            this.lblMunicipioEncargado = new System.Windows.Forms.Label();
            this.comboBoxSucursal = new System.Windows.Forms.ComboBox();
            this.comboBoxMunicipioEmpleado = new System.Windows.Forms.ComboBox();
            this.lblSalarioEmpleado = new System.Windows.Forms.Label();
            this.btnEditarEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarEmpleado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(343, 58);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(173, 22);
            this.txtId.TabIndex = 0;
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Location = new System.Drawing.Point(343, 115);
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(173, 22);
            this.txtNombreEmpleado.TabIndex = 1;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Location = new System.Drawing.Point(125, 61);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(154, 16);
            this.lblIdEmpleado.TabIndex = 2;
            this.lblIdEmpleado.Text = "Identificación Empleado:";
            this.lblIdEmpleado.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(125, 121);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(125, 16);
            this.lblNombreEmpleado.TabIndex = 3;
            this.lblNombreEmpleado.Text = "Nombre Empleado:";
            this.lblNombreEmpleado.Click += new System.EventHandler(this.lblNombreEmpleado_Click);
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(21, 316);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(141, 34);
            this.btnAgregarEmpleado.TabIndex = 4;
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.BtnAgregarEmpleado);
            // 
            // btnBuscarEmpleado
            // 
            this.btnBuscarEmpleado.Location = new System.Drawing.Point(343, 316);
            this.btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            this.btnBuscarEmpleado.Size = new System.Drawing.Size(133, 34);
            this.btnBuscarEmpleado.TabIndex = 5;
            this.btnBuscarEmpleado.Text = "Buscar Empleado";
            this.btnBuscarEmpleado.UseVisualStyleBackColor = true;
            this.btnBuscarEmpleado.Click += new System.EventHandler(this.BtnBuscarEmpleado);
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(125, 178);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(47, 16);
            this.lblCargo.TabIndex = 6;
            this.lblCargo.Text = "Cargo:";
            this.lblCargo.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // comboBoxCargoEmpleado
            // 
            this.comboBoxCargoEmpleado.FormattingEnabled = true;
            this.comboBoxCargoEmpleado.Location = new System.Drawing.Point(343, 170);
            this.comboBoxCargoEmpleado.Name = "comboBoxCargoEmpleado";
            this.comboBoxCargoEmpleado.Size = new System.Drawing.Size(173, 24);
            this.comboBoxCargoEmpleado.TabIndex = 7;
            // 
            // lblSucursalEmpleado
            // 
            this.lblSucursalEmpleado.AutoSize = true;
            this.lblSucursalEmpleado.Location = new System.Drawing.Point(125, 259);
            this.lblSucursalEmpleado.Name = "lblSucursalEmpleado";
            this.lblSucursalEmpleado.Size = new System.Drawing.Size(59, 16);
            this.lblSucursalEmpleado.TabIndex = 8;
            this.lblSucursalEmpleado.Text = "Sucursal";
            // 
            // lblMunicipioEncargado
            // 
            this.lblMunicipioEncargado.AutoSize = true;
            this.lblMunicipioEncargado.Location = new System.Drawing.Point(125, 220);
            this.lblMunicipioEncargado.Name = "lblMunicipioEncargado";
            this.lblMunicipioEncargado.Size = new System.Drawing.Size(67, 16);
            this.lblMunicipioEncargado.TabIndex = 9;
            this.lblMunicipioEncargado.Text = "Municipio:";
            this.lblMunicipioEncargado.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxSucursal
            // 
            this.comboBoxSucursal.FormattingEnabled = true;
            this.comboBoxSucursal.Location = new System.Drawing.Point(343, 251);
            this.comboBoxSucursal.Name = "comboBoxSucursal";
            this.comboBoxSucursal.Size = new System.Drawing.Size(173, 24);
            this.comboBoxSucursal.TabIndex = 10;
            // 
            // comboBoxMunicipioEmpleado
            // 
            this.comboBoxMunicipioEmpleado.FormattingEnabled = true;
            this.comboBoxMunicipioEmpleado.Location = new System.Drawing.Point(343, 212);
            this.comboBoxMunicipioEmpleado.Name = "comboBoxMunicipioEmpleado";
            this.comboBoxMunicipioEmpleado.Size = new System.Drawing.Size(173, 24);
            this.comboBoxMunicipioEmpleado.TabIndex = 11;
            // 
            // lblSalarioEmpleado
            // 
            this.lblSalarioEmpleado.AutoSize = true;
            this.lblSalarioEmpleado.Location = new System.Drawing.Point(125, 307);
            this.lblSalarioEmpleado.Name = "lblSalarioEmpleado";
            this.lblSalarioEmpleado.Size = new System.Drawing.Size(0, 20);
            this.lblSalarioEmpleado.TabIndex = 12;
            this.lblSalarioEmpleado.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // btnEditarEmpleado
            // 
            this.btnEditarEmpleado.Location = new System.Drawing.Point(183, 316);
            this.btnEditarEmpleado.Name = "btnEditarEmpleado";
            this.btnEditarEmpleado.Size = new System.Drawing.Size(136, 34);
            this.btnEditarEmpleado.TabIndex = 16;
            this.btnEditarEmpleado.Text = "Editar Empleado";
            this.btnEditarEmpleado.UseVisualStyleBackColor = true;
            this.btnEditarEmpleado.Click += new System.EventHandler(this.btnEditarEmpleado_Click);
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(498, 316);
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(136, 34);
            this.btnEliminarEmpleado.TabIndex = 17;
            this.btnEliminarEmpleado.Text = "Eliminar Empleado";
            this.btnEliminarEmpleado.UseVisualStyleBackColor = true;
            // 
            // FormEmpleado
            // 
            this.ClientSize = new System.Drawing.Size(666, 368);
            this.Controls.Add(this.btnEliminarEmpleado);
            this.Controls.Add(this.btnEditarEmpleado);
            this.Controls.Add(this.lblSalarioEmpleado);
            this.Controls.Add(this.comboBoxMunicipioEmpleado);
            this.Controls.Add(this.comboBoxSucursal);
            this.Controls.Add(this.lblMunicipioEncargado);
            this.Controls.Add(this.lblSucursalEmpleado);
            this.Controls.Add(this.comboBoxCargoEmpleado);
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
            CargarCargos();
            CargarMunicipios();
            comboBoxMunicipioEmpleado.SelectedIndexChanged += ComboBoxMunicipioEmpleado_SelectedIndexChanged;
        }

        private void CargarCargos()
        {
            try
            {
                using (SqlConnection conn = conexion.getCon())
                {
                    conn.Open();
                    string query = "SELECT NombreCargo FROM Cargos"; // Cambia el nombre de la tabla según tu diseño
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxCargoEmpleado.Items.Add(reader["NombreCargo"].ToString());
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

        private void CargarMunicipios()
        {
            try
            {
                using (SqlConnection conn = conexion.getCon())
                {
                    conn.Open();
                    string query = "SELECT NombreMunicipio FROM Municipios"; // Cambia el nombre de la tabla según tu diseño
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxMunicipioEmpleado.Items.Add(reader["NombreMunicipio"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando municipios: {ex.Message}", "Error");
            }
        }

        private void ComboBoxMunicipioEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string municipioSeleccionado = comboBoxMunicipioEmpleado.SelectedItem.ToString();
            CargarSucursales(municipioSeleccionado);
        }

        private void CargarSucursales(string municipio)
        {
            comboBoxSucursal.Items.Clear(); // Limpia el comboBox antes de cargar datos nuevos
            try
            {
                using (SqlConnection conn = conexion.getCon())
                {
                    conn.Open();
                    string query = "SELECT NombreSucursal FROM Sucursales WHERE Municipio = @Municipio";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Municipio", municipio);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxSucursal.Items.Add(reader["NombreSucursal"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando sucursales: {ex.Message}", "Error");
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
            // Obtener el ID del empleado a editar
            string idEmpleado = txtId.Text; // Asegúrate de tener un TextBox para el ID del empleado

            // Validar que el ID no esté vacío
            if (string.IsNullOrWhiteSpace(idEmpleado))
            {
                MessageBox.Show("El ID del empleado es obligatorio.", "Error");
                return;
            }

            // Obtener los datos del formulario
            string nombreEmpleado = txtNombreEmpleado.Text;
            Cargo cargo = comboBoxCargoEmpleado.SelectedItem as Cargo;  // Cargo del empleado
            Sucursal sucursal = comboBoxSucursal.SelectedItem as Sucursal;  // Sucursal del empleado
            Municipio nombreMunicipio = comboBoxMunicipioEmpleado.SelectedItem as Municipio;  // Municipio del empleado

            // Crear el objeto Empleado
            Empleado emp = new Empleado(idEmpleado, nombreEmpleado, cargo, sucursal, nombreMunicipio, null);

            // Crear una instancia de EmpleadoDao
            EmpleadoDao empleadoDao = new EmpleadoDao(this);

            // Llamar al método editar
            if (empleadoDao.editar(emp))
            {
                MessageBox.Show("Empleado editado exitosamente", "Éxito");
            }
            else
            {
                MessageBox.Show("Error al editar empleado.", "Error");
            }

            // Limpiar los campos después de editar
            LimpiarCampos();
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombreEmpleado.Clear();
            comboBoxCargoEmpleado = null;
            comboBoxSucursal = null;
            comboBoxMunicipioEmpleado = null;
        }

    }
}
