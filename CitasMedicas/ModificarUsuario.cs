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
    public partial class ModificarUsuario : Form
    {
        Conexion nueva = new Conexion();
        public ModificarUsuario()
        {
            InitializeComponent();
            nueva.llenarTipo(cbxTipoDocumento, "TIPODOCUMENTO");
            nueva.llenarTipo(cbxTipoUsuario, "TIPOUSUARIO");
        }

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            cbxTipo.SelectedIndex = 0;
            cbxSexo.SelectedIndex = 0;
        }

        private void buscarUsuario(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            int resultado = c.consultarUsuarioTipo(c, cbxTipo.SelectedItem.ToString(),txtTipo.Text.Trim());
            if (resultado == 1)
            {
                txtNombre.Text = c.Nombre.ToString();
                txtApellido.Text = c.Apellido.ToString();
                txtEmail.Text = c.Email.ToString();
                txtDireccion.Text = c.Direccion.ToString();
                txtNumeroDocumento.Text = c.NDocumento.ToString();
                txtTelefono.Text = c.Telefono.ToString();
                txtUsuario.Text = c.Usuario.ToString();
                txtPassword.Text = c.Password.ToString();
                txtPassword2.Text = c.Password.ToString();
            }
        }

        private void modificarUsuario(object sender, EventArgs e)
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

            int resultado = c.modificarUsuario(c);
            if (resultado == 1)
                MessageBox.Show("El usuario de modifico exitosamente");
            else
                MessageBox.Show("Error al modificar usuario");
        }
    }
}
