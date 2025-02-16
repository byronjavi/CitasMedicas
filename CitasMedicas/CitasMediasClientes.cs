using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CitasMedicas
{
    public partial class CitasMediasClientes : Form
    {
        public CitasMediasClientes()
        {
            InitializeComponent();
            configurarFecha();
            
        }


        public CitasMediasClientes(Conexion c)
        {
            InitializeComponent();
            configurarFecha();
            c.llenarEspecialidad(cbxEspecialidad);
            c.llenarMedico(cbxMedico, 1);
            c.llenarDataGridView(dgvCitasMedicas, 1);
            lblNombre.Text = "Bienvenido " + c.Nombre.Trim() + " " + c.Apellido.Trim();
            txtCedula.Text = c.NDocumento.Trim();
            txtNombre.Text = c.Nombre.Trim();
        }



        private void configurarFecha()
        {
            dtpfecha.Format = DateTimePickerFormat.Custom;
            dtpfecha.CustomFormat = "dd/MM/yyyy";
            DateTime h1 = DateTime.Now;
            DateTime h2 = DateTime.Today.AddHours(18);

            if (h1 < h2) 
                dtpfecha.MinDate = DateTime.Today;
            else
                dtpfecha.MinDate = DateTime.Today.AddDays(1);
        }

        /***********************************************/
        private void guardarCita(object sender, EventArgs e)
        {
            /*string id_user = 0;
            Conexion c = new Conexion();
            c.Id_medico = Convert.ToInt32(cbxMedico.SelectedValue);
            id_user = 
            c.Id_usuario = 
            c.Fcita = dtpfecha.Value.ToString("dd/MM/yyyy");
            c.Hcita = cbxHora.SelectedItem.ToString();
            MessageBox.Show(dtpfecha.Value.ToString("dd/MM/yyyy"));*/
            
            //Usuarios usuarios = new Usuarios();
            //usuarios.Show();
        }

        /***********************************************/
        private void llenarComboMedico(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            c.llenarMedico(cbxMedico, Convert.ToInt32(cbxEspecialidad.SelectedValue));
        }


        private void llenarDGV()
        {
            Conexion c = new Conexion();
            c.llenarDataGridView(dgvCitasMedicas, 6);
            
        }
    }
}
