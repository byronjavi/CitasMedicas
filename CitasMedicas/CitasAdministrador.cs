using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitasMedicas
{
    public partial class CitasAdministrador : Form
    {
        public CitasAdministrador()
        {
            Conexion c = new Conexion();
            InitializeComponent();
            configurarFecha();
            c.llenarEspecialidad(cbxEspecialidad);
            c.llenarMedico(cbxMedico, 1);
            llenarDGV();
        }

        private void guardarCitaMedica(object sender, EventArgs e)
        {
            if (validarCampos() == 1)
            {
                Conexion c = new Conexion();
                c.Id_medico = Convert.ToInt32(cbxMedico.SelectedValue);
                c.Id_usuario = c.consultarIdUsuario(c, txtCedula.Text.Trim());
                c.Fcita = DateTime.ParseExact(dtpfecha.Value.ToString("dd/MM/yyyy"), "dd/mm/yyyy", null);
                c.Hcita = cbxHora.SelectedItem.ToString();

                if (c.ingresarCita(c) != 0)
                {
                    llenarDGV();
                    MessageBox.Show("Se registró la cita exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error al guardar la cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Por favor, llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /****************************************************************/

        public int validarCampos()
        {
            if (txtCedula.Text.Trim().Equals("") && txtNombre.Text.Trim().Equals(""))
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }


        /***************************************************************/

        private void llenarDGV()
        {
            try
            {
                dgvCitasMedicas.Rows.Clear();
                Conexion c = new Conexion();
                c.llenarDataGridView(dgvCitasMedicas, -1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
        }

        /***************************************************************/

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

        private void llenarComboMedico(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            c.llenarMedico(cbxMedico, Convert.ToInt32(cbxEspecialidad.SelectedValue));

        }


        /********************************************************************/

        private void busrPorCedula(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            int resultado = c.consultarUsuarioTipo(c,"Cedula",txtCedula.Text.Trim());
            if (resultado == 1)
            {
                txtNombre.Text = c.Nombre;
            }
            else
            {
                MessageBox.Show("No se encontro la consulta solicitada en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        /******************************************************************/
        private void seleccionarUno(object sender, DataGridViewCellEventArgs e)
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

        /*******************************************************************/
        private void eliminarCita(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("¿Esta seguro que quiere eliminar la cita?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                recorrerDGV();
            }
        }

        /*******************************************************************/

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

                        MessageBox.Show("La cita se eliminó exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCitasMedicas.Rows.Remove(row);
                    }
                    else
                    {
                        MessageBox.Show("No fue posible eliminar la cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        /***************************************************************/
        private void cargarElementos(object sender, EventArgs e)
        {
            cbxHora.SelectedIndex = 0;
        }
    }
}
