using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitasMedicas
{
    internal interface CitasMedicas
    {
        void llenarTipo(ComboBox cbx, string tipo);
        void llenarEspecialidad(ComboBox cbx);
        void llenarMedico(ComboBox cbx, int id);
        int ingresarUsuario(Conexion c);
        int modificarUsuario(Conexion c);
        int ingresarCita(Conexion c);
        int validarIngreso(Conexion c);
        int consultarIdUsuario(Conexion c, string ced);
        int consultarUsuarioTipo(Conexion c, string tipo, string dato);
        int consultarCitaPorFechaHora(Conexion c, DateTime fecha, string hora);
        int EliminarCita(Conexion c, int id);





    }
}
