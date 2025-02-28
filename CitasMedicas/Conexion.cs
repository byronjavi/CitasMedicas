using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CitasMedicas
{
    public class Conexion: CitasMedicas
    {
        private string nombre, apellido, email, direccion, tipoDocumento, numDocumento, telefono, sexo, tipoUsuario, usuario, password;
        private int id_tipoDocumento, id_tipoUsuario, id_cita, id_medico, id_usuario;
        private string hcita, ecita;
        private DateTime fcita;
        private static string conn = "Data Source=SQL1002.site4now.net;Initial Catalog=db_ab2dcd_citasmedicas;User Id=db_ab2dcd_citasmedicas_admin;Password=BBcorp10;";
        //private static string conn = "Server=DESKTOP-73OL00S\\SQLEXPRESS;Database=citasMedicas;Integrated Security=True;";

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        //public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string NDocumento { get => numDocumento; set => numDocumento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string TUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public int Id_tipoDocumento { get => id_tipoDocumento; set => id_tipoDocumento = value; }
        public int Id_tipoUsuario { get => id_tipoUsuario; set => id_tipoUsuario = value; }
        public int Id_cita { get => id_cita; set => id_cita = value; }
        public DateTime Fcita { get => fcita; set => fcita = value; }
        public string Hcita { get => hcita; set => hcita = value; }
        public string Ecita { get => ecita; set => ecita = value; }
        public int Id_medico { get => id_medico; set => id_medico = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }

        public Conexion() 
        {
            this.nombre = "";
            this.apellido = "";
            this.email = "";
            this.direccion = "";
            //this.tipoDocumento = "";
            this.numDocumento = "";
            this.telefono = "";
            this.sexo = "";
            //this.tipoUsuario = "";
            this.usuario = "";
            this.password = "";
            this.id_tipoDocumento = 0;
            this.id_tipoUsuario = 0;
        }
        
        /******************************************************************/
        /*Este método nos permite conectarnos a la DB llamando al método Open()*/
        private static SqlConnection abrirConexion()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conn);
                connection.Open();
                return connection;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al conectar con la Base de Datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /*********************************************************************/
        /*Este metodo lo utilizo para llenar el ComboBox TipoUsuario*/

        public void llenarTipo(ComboBox cbx, string tipo)
        {
            try
            {
                SqlConnection conn = abrirConexion();
                string sql = "select * from "+tipo;
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbx.DataSource = dataTable;

                if (tipo.Equals("TIPODOCUMENTO"))
                {
                    cbx.DisplayMember = "NOMBRE_TIPODOCUMENTO";
                    cbx.ValueMember = "ID_TIPODOCUMENTO";
                }
                else
                {
                    cbx.DisplayMember = "NOMBRETIPOUSUARIO";
                    cbx.ValueMember = "ID_TIPOUSUARIO";
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    
        }

        /*******************************************************************/
        /*Este método lo utilizo para llenar el combo box especialidad en citas medicas*/

        public void llenarEspecialidad(ComboBox cbx)
        {
            try
            {
                SqlConnection conn = abrirConexion();
                string sql = "select * from Especialidad";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbx.DataSource = dataTable;
                
                cbx.DisplayMember = "NOMBRE_ESPECIALIDAD";
                cbx.ValueMember = "ID_ESPECIALIDAD";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /*******************************************************************/
        /*Este método lo utilizo para llenar el comboBox Medico desde la DB*/
        public void llenarMedico(ComboBox cbx, int id)
        {
            try
            {
                SqlConnection conn = abrirConexion();
                string sql = "select E.NOMBRE_ESPECIALIDAD,M.NOMBRE_MEDICO, M.ID_MEDICO, M.ESTADO_MEDICO from ESPECIALIDAD AS E INNER JOIN MEDICO AS M ON M.ID_ESPECIALIDAD = E.ID_ESPECIALIDAD WHERE E.ID_ESPECIALIDAD = "+id+";";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbx.DataSource = dataTable;

                cbx.DisplayMember = "NOMBRE_MEDICO";
                cbx.ValueMember = "ID_MEDICO";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /********************************************************************/
        /*Este método lo utilizo para registrar (guardar) los usuarios en mi DB*/
        public int ingresarUsuario(Conexion c)
        {
            int resultado = 0;
            string cadena = "INSERT INTO USUARIO(ID_TIPODOCUMENTO,ID_TIPOUSUARIO,NOMBRE_USUARIO,APELLIDO_USUARIO,EMAIL_USUARIO,DIRECCION_USUARIO,TELEFONO,SEXO,USUARIO,PASSWORD,NUMERO_DOCUMENTO) " +
                "VALUES(@ID_tipoDocumento,@ID_tipoUsuario,@Nombre,@Apellido,@Email,@Direccion,@Telefono,@Sexo,@Usuario,@Password,@Numero_Documento)";

            try
            {
                SqlConnection conn = abrirConexion();
                SqlCommand command = new SqlCommand(cadena, conn);
                command.Parameters.AddWithValue("@ID_tipoDocumento",c.Id_tipoDocumento);
                command.Parameters.AddWithValue("@ID_tipoUsuario", c.Id_tipoUsuario);
                command.Parameters.AddWithValue("@Nombre",c.Nombre);
                command.Parameters.AddWithValue("@Apellido", c.Apellido);
                command.Parameters.AddWithValue("@Email",c.Email);
                command.Parameters.AddWithValue("@Direccion",c.Direccion);
                command.Parameters.AddWithValue("@Telefono",c.Telefono);
                command.Parameters.AddWithValue("@Sexo",c.Sexo);
                command.Parameters.AddWithValue("@Usuario",c.Usuario);
                command.Parameters.AddWithValue("@Password",c.Password);
                command.Parameters.AddWithValue("@Numero_Documento",c.NDocumento);
                resultado = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }


        /********************************************************************/
        /*Este método lo utilizo para modificar los usuarios ya creados en la DB*/

        public int modificarUsuario(Conexion c)
        {
            int resultado = 0;
            string cadena = "UPDATE USUARIO SET ID_TIPODOCUMENTO = @id_tipodocumento,ID_TIPOUSUARIO=@id_tipousuario,NOMBRE_USUARIO=@nombre,APELLIDO_USUARIO=@apellido,EMAIL_USUARIO=@email,DIRECCION_USUARIO=@direccion,TELEFONO=@telefono,SEXO=@sexo,USUARIO=@usuario,PASSWORD = @pass WHERE NUMERO_DOCUMENTO = @cedula";
            //string cadena = "UPDATE USUARIO SET NOMBRE_USUARIO=@nombre,APELLIDO_USUARIO=@apellido WHERE NUMERO_DOCUMENTO = @cedula";

            try
            {
                SqlConnection conn = abrirConexion();
                SqlCommand command = new SqlCommand(cadena, conn);
                command.Parameters.AddWithValue("@id_tipodocumento", c.Id_tipoDocumento);
                command.Parameters.AddWithValue("@id_tipousuario", c.Id_tipoUsuario);
                command.Parameters.AddWithValue("@nombre", c.Nombre);
                command.Parameters.AddWithValue("@apellido", c.Apellido);
                command.Parameters.AddWithValue("@email", c.Email);
                command.Parameters.AddWithValue("@direccion", c.Direccion);
                command.Parameters.AddWithValue("@telefono", c.Telefono);
                command.Parameters.AddWithValue("@sexo", c.Sexo);
                command.Parameters.AddWithValue("@usuario", c.Usuario);
                command.Parameters.AddWithValue("@pass", c.Password);
                command.Parameters.AddWithValue("@cedula", c.NDocumento);
                resultado = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }

        /**********************************************************************/
        /*Este método lo utilizo para registrar las citas en mi DB*/

        public int ingresarCita(Conexion c)
        {
            int resultado = 0;
            string cadena = "INSERT INTO CITA(ID_MEDICO,ID_USUARIO,FECHA_CITA,HORA_CITA,ESTADO_CITA) " +
                "VALUES(@ID_MEDICO,@ID_USUARIO,@FECHA_CITA,@HORA_CITA,@ESTADO_CITA)";

            try
            {
                SqlConnection conn = abrirConexion();
                SqlCommand command = new SqlCommand(cadena, conn);
                command.Parameters.AddWithValue("@ID_MEDICO",c.Id_medico);
                command.Parameters.AddWithValue("@ID_USUARIO", c.Id_usuario);
                command.Parameters.AddWithValue("@FECHA_CITA", c.Fcita);
                command.Parameters.AddWithValue("@HORA_CITA", c.Hcita);
                command.Parameters.AddWithValue("@ESTADO_CITA", "A");
                resultado = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }

        /**********************************************************************/
        /*Este método lo utilizo para verificar si el Usuario esta registrado en DB*/
        public int validarIngreso(Conexion c)
        {
            int resultado = 0;
            try
            {
                SqlConnection conn = abrirConexion();
                string cadena = "select U.NOMBRE_USUARIO,U.APELLIDO_USUARIO,U.USUARIO,U.PASSWORD,T.NOMBRETIPOUSUARIO,U.NUMERO_DOCUMENTO, T.ID_TIPOUSUARIO, U.ID_USUARIO from USUARIO AS U INNER JOIN TIPOUSUARIO AS T ON U.ID_TIPOUSUARIO = t.ID_TIPOUSUARIO where U.USUARIO = '" + c.Usuario + "' and U.PASSWORD = '" + c.Password + "'";
                SqlCommand cmd = new SqlCommand(cadena, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c.Nombre = reader.GetString(0);
                    c.Apellido = reader.GetString(1);
                    c.Usuario = reader.GetString(2);
                    c.Password = reader.GetString(3);
                    c.TUsuario = reader.GetString(4);
                    c.NDocumento = reader.GetString(5);
                    c.id_tipoUsuario = reader.GetInt32(6);
                    c.Id_usuario = reader.GetInt32(7);
                    resultado = 1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }


        /*************************************************************************/
        /*Este m´wtodo lo utilizo para consultar un usuario en la DB*/

        public int consultarIdUsuario(Conexion c, string ced)
        {
            int resultado = 0;
            try
            {
                SqlConnection conn = abrirConexion();
                string cadena = "select ID_USUARIO FROM USUARIO WHERE NUMERO_DOCUMENTO = '" + ced+"'";
                SqlCommand cmd = new SqlCommand(cadena, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resultado = (reader.GetInt32(0));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }

        /**************************************************************************/
        /*Este método lo utilizo para consultar el tipo de usuario en DB */

        public int consultarUsuarioTipo(Conexion c, string tipo, string dato)
        {
            int resultado = 0;
            string cadena = "";
            try
            {
                if (tipo.Equals("Cedula"))
                    cadena = "select * from USUARIO where NUMERO_DOCUMENTO = '" + dato + "'";
                else if (tipo.Equals("Nombre"))
                {
                    cadena = "select * from USUARIO where NOMBRE_USUARIO = '" + dato + "'";
                }
                else
                    MessageBox.Show("No se encontraron datos asociados a la consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlConnection conn = abrirConexion();
                
                SqlCommand cmd = new SqlCommand(cadena, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c.id_usuario = (reader.GetInt32(0));
                    c.id_tipoDocumento = (reader.GetInt32(1));
                    c.id_tipoUsuario = (reader.GetInt32(2));
                    c.nombre = reader.GetString(3);
                    c.apellido = reader.GetString(4);
                    c.email = reader.GetString(5);
                    c.direccion = reader.GetString(6);
                    c.telefono = reader.GetString(7);
                    c.usuario = reader.GetString(9);
                    c.password = reader.GetString(10);
                    c.numDocumento = reader.GetString(11);
                    resultado = 1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }


        /**************************************************************************/
        /*Este método lo utilizo para consultar las citad por fecha y hora*/


        public int consultarCitaPorFechaHora(Conexion c, DateTime fecha, string hora)
        {
            int resultado = 0;
            try
            {
                SqlConnection conn = abrirConexion();
                string cadena = "select ID_CITA from CITA where FECHA_CITA = '"+fecha+"' and HORA_CITA = '"+hora+"'";
                SqlCommand cmd = new SqlCommand(cadena, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resultado = (reader.GetInt32(0));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }

        /***************************************************************************/
        /*Este metodo me permite cambiar el estado de la cita, "A" activo o "E" eliminado*/


        public int EliminarCita(Conexion c, int id)
        {
            int resultado = 0;
            try
            {
                SqlConnection conn = abrirConexion();
                string cadena = "UPDATE CITA SET ESTADO_CITA = 'I' WHERE ID_CITA = '"+id+"'";
                SqlCommand cmd = new SqlCommand(cadena, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                resultado = 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }


        /***************************************************************************/
        /*Este metodo lo utilizo para llenar el DGV en todas las ventanas*/

        public int llenarDataGridView(DataGridView dgv,int id)
        {
            string cadena = "";

            if (id == -1)
            {
                    cadena = "SELECT U.NUMERO_DOCUMENTO, U.NOMBRE_USUARIO,U.APELLIDO_USUARIO, " +
                    "E.NOMBRE_ESPECIALIDAD,M.NOMBRE_MEDICO,C.FECHA_CITA,C.HORA_CITA, C.ID_CITA FROM " +
                    "USUARIO AS U INNER JOIN CITA AS C ON U.ID_USUARIO = C.ID_USUARIO INNER JOIN " +
                    "MEDICO AS M ON M.ID_MEDICO = C.ID_MEDICO INNER JOIN ESPECIALIDAD AS E " +
                    "ON E.ID_ESPECIALIDAD = M.ID_ESPECIALIDAD WHERE C.ESTADO_CITA='A'";
            }
            else 
            {
                cadena = "SELECT U.NUMERO_DOCUMENTO, U.NOMBRE_USUARIO,U.APELLIDO_USUARIO, " +
                "E.NOMBRE_ESPECIALIDAD,M.NOMBRE_MEDICO,C.FECHA_CITA,C.HORA_CITA, C.ID_CITA FROM " +
                "USUARIO AS U INNER JOIN CITA AS C ON U.ID_USUARIO = C.ID_USUARIO INNER JOIN " +
                "MEDICO AS M ON M.ID_MEDICO = C.ID_MEDICO INNER JOIN ESPECIALIDAD AS E " +
                "ON E.ID_ESPECIALIDAD = M.ID_ESPECIALIDAD WHERE U.ID_USUARIO = '" + id + "' and C.ESTADO_CITA='A'";

            }

            int resultado = 0;
            try
            {
                SqlConnection conn = abrirConexion();
                
                SqlCommand cmd = new SqlCommand(cadena, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgv.Rows.Add(reader.GetInt32(7),reader.GetString(0).Trim(), reader.GetString(1).Trim()+" "+reader.GetString(2).Trim(),reader.GetString(3).Trim(), reader.GetString(4).Trim(), reader["FECHA_CITA"],reader.GetString(6).Trim());
                    resultado = 1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }

        /****************************************************************/
        /*Este metodo me permite guardar una nueva especialidad*/

        public int ingresarEspecialidad(Conexion c, string especialidad)
        {
            int resultado = 0;
            string cadena = "INSERT INTO ESPECIALIDAD (NOMBRE_ESPECIALIDAD,ESTADO_ESPECIALIDAD) VALUES ('"+ especialidad + "','A')";

            try
            {
                SqlConnection conn = abrirConexion();
                SqlCommand command = new SqlCommand(cadena, conn);
                command.Parameters.AddWithValue("@NOMBRE_ESPECIALIDAD", especialidad);
                resultado = command.ExecuteNonQuery();
                
                MessageBox.Show("La especialidad se guardó exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }

        /****************************************************************/
        /*Este metodo me permite guardar un nuevo médico*/

        public int ingresarDoctor(Conexion c, string doctor, int id_especialidad)
        {
            int resultado = 0;
            string cadena = "INSERT INTO MEDICO (ID_ESPECIALIDAD,NOMBRE_MEDICO,ESTADO_MEDICO) VALUES ("+id_especialidad+",'"+doctor+"','A')";

            try
            {
                SqlConnection conn = abrirConexion();
                SqlCommand command = new SqlCommand(cadena, conn);
                command.Parameters.AddWithValue("@ID_ESPECIALIDAD", id_especialidad);
                command.Parameters.AddWithValue("@NOMBRE_MEDICO", doctor);
                resultado = command.ExecuteNonQuery();

                MessageBox.Show("El doctor se guardó exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultado = 0;
            }
            return resultado;
        }
    }
}
