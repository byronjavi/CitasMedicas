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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        /*******************************************************************/
        /*Este metodo es llamado por el boton ingresar para validar el ingreso*/
        private void Ingresar(object sender, EventArgs e)
        {
            if(txtUsuario.Text.Trim().Equals("") || txtPass.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tiene que llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Conexion c = new Conexion();
            c.Usuario = txtUsuario.Text.Trim();
            c.Password = txtPass.Text.Trim();
            if (c.validarIngreso(c) == 1)
            {
                
                if (c.Id_tipoUsuario == 1)
                {
                    CitasMedicasAdministrador nuevo = new CitasMedicasAdministrador();  
                    nuevo.ShowDialog();
                    this.Close();
                }
                else if(c.Id_tipoUsuario == 2)
                {
                    CitasMediasClientes nuevo = new CitasMediasClientes(c);
                    nuevo.ShowDialog();
                    Application.Exit();
                }
            }
            else
                MessageBox.Show("Error");
        }

        /********************************************************************/
        /*Este método lo utilizo para que al momento de dar enter en el textbox tambien ingrese*/
        private void darEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Ingresar(sender, e);
            }
        }

        /**********************************************************************/
        /*Este metodo al igual que el anterior, lo utilizo para ingresar desde el textbox*/
        private void darEnter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Ingresar(sender, e);
            }
        }

        /**********************************************************************/
        /*Lo utilizo para que el cursor me aparezca en el textbox Usuario*/
        private void DarFocus(object sender, EventArgs e)
        {
            txtUsuario.Focus();
            
        }
    }
}
