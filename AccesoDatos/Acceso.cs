using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public partial class Acceso : Form
    {
        public Acceso()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            //1. crear una conexion
            SqlConnection conexion = new SqlConnection(@"server=L-ELR-017\SQLEXPRESS; database=TI2021; integrated security = true");
            //2. Definir la operacion
            string sql = "insert into personas(cedula, apellidos, nombres, fechaNacimiento, peso)";
            sql += "values(@cedula, @apellidos, @nombres, @fechaNacimiento, @peso)";
            //3. ejecutar la operacion
            try
            {
                DateTime fecha = Dato.Value;
                SqlCommand comando = new SqlCommand(sql, conexion);
                //3.1 configurar los parametros @cedula, @apellidos, @nombres, @fechadenacimiento, @peso
                comando.Parameters.Add(new SqlParameter("@cedula", this.TxtCedula.Text));
                comando.Parameters.Add(new SqlParameter("@apellidos", this.TxtApellidos.Text));
                comando.Parameters.Add(new SqlParameter("@nombres", this.TxtNombres.Text));
                comando.Parameters.Add(new SqlParameter("@fechaNacimiento", fecha.ToString()));
                comando.Parameters.Add(new SqlParameter("@peso", this.TxtPeso.Text));
                //3.2 abrir la conexion 
                conexion.Open();
                //3.3 Insertar el registro en la Base de datos
                int res = comando.ExecuteNonQuery();
                //4 Cerrar la conexion
                conexion.Close();

                MessageBox.Show("Filas Insertadas: " + res.ToString());

            }
            catch (SqlException e1)
            {
                MessageBox.Show(e1.Message.ToString(),"INGRESAR SUS DATOS");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }

        }
    }
}
