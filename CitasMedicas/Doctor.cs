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
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
            llenarEspecialidad();

        }

        /****************************************************************/
        /*Este metodo me permite llenar el combo Box especialidad*/

        public void llenarEspecialidad()
        {
            Conexion c = new Conexion();
            c.llenarEspecialidad(cbx_especialidad);
        }


        /****************************************************************/
        /*Este metodo me permite guardar un nuevo médico*/

        private void registrarMedico(object sender, EventArgs e)
        {
            int id_esp = Convert.ToInt32(cbx_especialidad.SelectedValue);
            Conexion conexion = new Conexion();
            conexion.ingresarDoctor(conexion, txt_nombre.Text.Trim(),id_esp);
        }
    }
}
