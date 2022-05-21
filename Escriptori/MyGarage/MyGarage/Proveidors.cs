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
    public partial class Proveidors : Form
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

        public Proveidors()
        {
            InitializeComponent();
        }

        private void Proveidors_Load(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM PROVEIDORS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text) )
            {
                MessageBox.Show("Omple les dades del proveïdor primer!!!");
            }
            else
            {
                sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
                sqlCon.Open();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "INSERT INTO PROVEIDORS (nom, tarifa, tel_contacte) VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "')";
                sqlRd = sqlCmd.ExecuteReader();
                sqlDt.Load(sqlRd);
                sqlRd.Close();
                sqlCon.Close();

                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlCon.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" + "password=" + password + ";" + "database=" + database;
            sqlCon.Open();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "SELECT * FROM PROVEIDORS";
            sqlRd = sqlCmd.ExecuteReader();
            sqlDt.Load(sqlRd);
            sqlRd.Close();
            sqlCon.Close();
            this.dataGridView1.DataSource = sqlDt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarProveidor eliminarProveidor = new EliminarProveidor();
            eliminarProveidor.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditarProveidor editarProveidor = new EditarProveidor();
            editarProveidor.Show();
        }
    }
}
