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
    public partial class Especialidad : Form
    {
        public Especialidad()
        {
            InitializeComponent();
        }

        private void guardarEspecialidad(object sender, EventArgs e)
        {
            if(txt_especialidad.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese una especialidad","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Conexion c = new Conexion();
            c.ingresarEspecialidad(c, txt_especialidad.Text.Trim());

        }
    }
}
