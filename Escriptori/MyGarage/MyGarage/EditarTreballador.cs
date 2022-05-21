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

namespace MyGarage
{
    public partial class EditarTreballador : Form
    {

        MySqlConnection sqlCon = new MySqlConnection();
        MySqlCommand sqlCmd = new MySqlCommand();
        DataTable sqlDt = new DataTable();
        String sqlQuery;
        MySqlDataAdapter DtA = new MySqlDataAdapter();
        MySqlDataReader sqlRd;

        DataSet DS = new DataSet();

        String server = "192.168.1.30";
        String database = "mygarage";
        String username = "admindb";
        String password = "Fat/3232";

        public EditarTreballador()
        {
            InitializeComponent();
        }

        private void EditarTreballador_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Indica un ID de treballador.");
            }
            else
            {
                button2.Enabled = true;
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT * FROM MECANICS WHERE id_mecanic = " + textBox1.Text;
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();
                this.textBox2.Text = sqlDt.Rows[0]["nom"].ToString();
                this.textBox3.Text = sqlDt.Rows[0]["cognom"].ToString();
                this.textBox4.Text = sqlDt.Rows[0]["dni_mecanic"].ToString();
                this.textBox5.Text = sqlDt.Rows[0]["departament"].ToString();
                this.textBox6.Text = sqlDt.Rows[0]["contrasenya"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "UPDATE MECANICS SET nom = '" + textBox2.Text + "', cognom = '" + textBox3.Text + "', dni_mecanic = '" + textBox4.Text + "', departament = '" + textBox5.Text + "', contrasenya = '" + textBox6.Text;
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            MessageBox.Show("Treballador actualitzat correctament!");
        }
    }
}
