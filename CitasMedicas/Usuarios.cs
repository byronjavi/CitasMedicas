using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitasMedicas
{
    public partial class Usuarios : Form
    {
        Conexion nueva = new Conexion();
        public Usuarios()
        {
            InitializeComponent();
            nueva.llenarTipo(cbxTipoDocumento, "TIPODOCUMENTO");
            nueva.llenarTipo(cbxTipoUsuario, "TIPOUSUARIO");
        }

        /************************************************************/

        public int validarCampo()
        {
            if (txtNombre.Text.Trim().Equals("") || txtApellido.Text.Trim().Equals("") || txtEmail.Text.Trim().Equals("") || txtDireccion.Text.Trim().Equals("") || txtTelefono.Text.Trim().Equals("") || txtUsuario.Text.Trim().Equals("") || txtPassword.Text.Trim().Equals("") || txtPassword2.Text.Trim().Equals(""))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /******************************************************************/

        private void registrarUsuario(object sender, EventArgs e)
        {
            if (validarCampo() == 1)
            {
                Conexion c = new Conexion();
                c.Nombre = txtNombre.Text.Trim();
                c.Apellido = txtApellido.Text.Trim();
                c.Email = txtEmail.Text.Trim();
                c.Direccion = txtDireccion.Text.Trim();
                c.Telefono = txtTelefono.Text.Trim();
                c.Usuario = txtUsuario.Text.Trim();
                c.Password = txtPassword.Text.Trim();
                c.Id_tipoDocumento = int.Parse(cbxTipoDocumento.SelectedValue.ToString());
                c.NDocumento = txtNumeroDocumento.Text.Trim();
                c.Id_tipoUsuario = int.Parse(cbxTipoUsuario.SelectedValue.ToString());
                if (cbxSexo.Text.Trim().Equals("Masculino"))
                    c.Sexo = "M";
                else
                    c.Sexo = "F";

                if (c.ingresarUsuario(c) > 0)
                    MessageBox.Show("Los datos fueron ingresados satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al ingresar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos para poder guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
