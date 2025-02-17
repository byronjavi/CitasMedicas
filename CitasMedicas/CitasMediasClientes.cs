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
            cbxHora.SelectedIndex = 0;
            
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
            
            Conexion c = new Conexion();
            c.Id_medico = Convert.ToInt32(cbxMedico.SelectedValue);
            c.Id_usuario = c.consultarIdUsuario(c,txtCedula.Text.Trim());
            c.Fcita = DateTime.ParseExact(dtpfecha.Value.ToString("dd/MM/yyyy"),"dd/mm/yyyy",null);
            c.Hcita = cbxHora.SelectedItem.ToString();

            if (c.ingresarCita(c) != 0)
            {
                llenarDGV();
                MessageBox.Show("Se registro la cita correctamente");
            }
            else
                MessageBox.Show("Error al guardar cita");          
        }

        /***********************************************/
        private void llenarComboMedico(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            c.llenarMedico(cbxMedico, Convert.ToInt32(cbxEspecialidad.SelectedValue));
        }


        private void llenarDGV()
        {
            try
            {
                dgvCitasMedicas.Rows.Clear();
                Conexion c = new Conexion();
                c.llenarDataGridView(dgvCitasMedicas, 6);
            }
            catch(Exception ex) {MessageBox.Show(ex.Message); return; }
        }

        private void darFocus(object sender, EventArgs e)
        {
            cbxHora.SelectedIndex = 0;
        }

        private void seleccionarSoloUno(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda clickeada es una celda CheckBox
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCitasMedicas.Columns["Eliminar"].Index)
            {
                // Desmarcar todos los CheckBox
                foreach (DataGridViewRow row in dgvCitasMedicas.Rows)
                {
                    row.Cells["Eliminar"].Value = false;
                }

                // Marcar el CheckBox de la fila clickeada
                dgvCitasMedicas.Rows[e.RowIndex].Cells["Eliminar"].Value = true;
            }
        }

        public void recorrerDGV()
        {
            foreach (DataGridViewRow row in dgvCitasMedicas.Rows)
            {
       
                    Conexion c = new Conexion();
                    if (row.Cells["Eliminar"].Value.ToString().Trim().Equals("True"))
                    {
                        int resultado = 0;
                        c.Id_cita = int.Parse(row.Cells["ID"].Value.ToString().Trim());
                        resultado = c.EliminarCita(c, c.Id_cita);
                        if (resultado == 1)
                        {

                            MessageBox.Show("La cita se elimino exitosamente");
                            dgvCitasMedicas.Rows.Remove(row);
                        }
                        else
                        {
                            MessageBox.Show("No fue posible eliminar la cita");
                        }
                    }
                
            }
        }

        private void eliminarCita(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("¿Esta seguro que quiere eliminar la cita?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                recorrerDGV();
            }
        }

        private void modificarCita(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("¿Esta seguro que desea modificar la cita?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                recorrerDGV();
            }
        }
    }
}
