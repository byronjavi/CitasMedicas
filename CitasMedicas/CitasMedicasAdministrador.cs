﻿using System;
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
    public partial class CitasMedicasAdministrador : Form
    {
        public CitasMedicasAdministrador()
        {
            InitializeComponent();
        }

        private void ventanaUsuario(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.ShowDialog();
        }

        private void verCitas_Click(object sender, EventArgs e)
        {
            CitasAdministrador citas = new CitasAdministrador();
            citas.ShowDialog();
        }

        private void modificarUser(object sender, EventArgs e)
        {
            ModificarUsuario nuevo = new ModificarUsuario();
            nuevo.ShowDialog();
        }

        private void crearEspecialidad(object sender, EventArgs e)
        {
            Especialidad nuevo = new Especialidad();
            nuevo.ShowDialog();
        }

        private void ingresarDoctor(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            d.ShowDialog();
        }
    }
}
