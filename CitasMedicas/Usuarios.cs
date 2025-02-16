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

        private void registrarUsuario(object sender, EventArgs e)
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
            
            if(c.ingresarUsuario(c)>0)
                MessageBox.Show("Los datos fueron ingresados satisfactoriamente");
            else
                MessageBox.Show("Error al ingresar los datos");

        }
    }
}
