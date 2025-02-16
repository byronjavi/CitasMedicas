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
        }

        private void Ingresar(object sender, EventArgs e)
        {
            
            
            Conexion c = new Conexion();
            c.Usuario = txtUsuario.Text.Trim();
            c.Password = txtPass.Text.Trim();
            if (c.validarIngreso(c) == 1)
            {
                if (c.TUsuario.Equals("Administrador"))
                {
                    CitasMediasClientes nuevo = new CitasMediasClientes(c);
                    nuevo.Show();
                }
                else
                {
                    CitasMediasClientes nuevo = new CitasMediasClientes(c);
                    nuevo.Show();
                }
            }
            else
                MessageBox.Show("Error");
        }
    }
}
