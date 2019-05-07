using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace EjemploConexionBBDD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Con esta línea me conecto y uso la bbdd
            MySqlConnection conexion = new ConexionBBDD().conecta();
            
            MySqlCommand comando = new MySqlCommand(""+
                "SELECT * from usuarios WHERE " +
                "usuario = '"+ textBox1.Text +
                "' AND pass = '" + textBox2.Text +
                "';", conexion);

            MySqlDataReader resultado = comando.ExecuteReader();
            //lo que hará es intentar leer un registro
                if (resultado.Read())
                {
                    MessageBox.Show("Acceso Correcto", "USUARIO OK!");
                    this.Visible = false; //oculta la ventana Login
                VentanaPrincipal v = new VentanaPrincipal();
                v.Visible = true; 
                }
                else
                {
                MessageBox.Show("Usuario Y/O contraseña incorrecto(s)", "ERROR!");
                }
        }
    }
}
