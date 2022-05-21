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
using System.Net;
using System.Net.Mail;

namespace MyGarage
{
    public partial class Treballadors : Form
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

        public Treballadors()
        {
            InitializeComponent();
        }

        private void Treballadors_Load(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM MECANICS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "INSERT INTO MECANICS (nom, cognom, dni_mecanic, departament, contrasenya) VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "')";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();

            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarTreballador eliminarTreballador = new EliminarTreballador();
            eliminarTreballador.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM MECANICS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditarTreballador editarTreballador = new EditarTreballador();
            editarTreballador.Show();
        }
    }
}
